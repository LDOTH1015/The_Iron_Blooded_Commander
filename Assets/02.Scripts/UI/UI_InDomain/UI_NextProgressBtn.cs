using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_NextProgressBtn : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Image btn_NextTurn;
    private Image btn_BattleTurn;
    private Image btn_ProgressTxtFrame;
    private Image btn_NextTurnTxt;
    private Image btn_BattleTurnTxt;

    protected override void Awake()
    {
        base.Awake();
        button = GetComponent<Button>();
        btn_NextTurn = transform.GetChild(0).gameObject.GetComponent<Image>();
        btn_BattleTurn = transform.GetChild(1).gameObject.GetComponent<Image>();
        btn_ProgressTxtFrame = transform.GetChild(2).gameObject.GetComponent<Image>();
        btn_NextTurnTxt = transform.GetChild(3).gameObject.GetComponent<Image>();
        btn_BattleTurnTxt = transform.GetChild(4).gameObject.GetComponent<Image>();
    }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClicked);
        LocatorManager.Instance.turnManager.playerTurnState.OnNextButtonChanged += UpdateButtonsImage;
        btn_NextTurn.enabled = true;
        btn_BattleTurn.enabled = false;
        btn_ProgressTxtFrame.enabled = false;
        btn_NextTurnTxt.enabled = false;
        btn_BattleTurnTxt.enabled = false;
    }

    private void OnDestroy()
    {
        LocatorManager.Instance.turnManager.playerTurnState.OnNextButtonChanged -= UpdateButtonsImage;
    }

    private void UpdateButtonsImage(bool isNextTurnBattle)
    {
        if (isNextTurnBattle)
        {
            btn_NextTurn.enabled = false;
            btn_BattleTurn.enabled = true;
        }
        else
        {
            btn_NextTurn.enabled = true;
            btn_BattleTurn.enabled = false;
        }
    }

    private void OnButtonClicked()
    {
        var turnManager = LocatorManager.Instance.turnManager;
        turnManager.playerTurnState.Exit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        btn_ProgressTxtFrame.enabled = true;
        
        var turnManager = LocatorManager.Instance.turnManager;
        if (turnManager.playerTurnState.IsNextTurnBattle)
        {
            btn_BattleTurnTxt.enabled = true;
            btn_NextTurnTxt.enabled = false;
        }
        else
        {
            btn_BattleTurnTxt.enabled = false;
            btn_NextTurnTxt.enabled = true;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        btn_ProgressTxtFrame.enabled = false;
        btn_NextTurnTxt.enabled = false;
        btn_BattleTurnTxt.enabled = false;
    }
}


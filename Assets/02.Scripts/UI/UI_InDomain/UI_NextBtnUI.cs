
using System;
using UnityEngine;

public class UI_NextBtnUI : UIBase
{
    private GameObject btn_TestNextTurn;
    private GameObject btn_TestBattleTurn;

    protected override void Awake()
    {
        base.Awake();
        btn_TestNextTurn = transform.GetChild(0).gameObject;
        btn_TestBattleTurn = transform.GetChild(1).gameObject;
        btn_TestBattleTurn.SetActive(false);
        btn_TestNextTurn.SetActive(true);
    }

    private void Start()
    {
        LocatorManager.Instance.turnManager.playerTurnState.OnNextButtonChanged += UpdateButtons;
    }

    private void OnDestroy()
    {
        LocatorManager.Instance.turnManager.playerTurnState.OnNextButtonChanged -= UpdateButtons;
    }

    private void UpdateButtons(bool isNextTurnBattle)
    {
        btn_TestBattleTurn.SetActive(isNextTurnBattle);
        btn_TestNextTurn.SetActive(!isNextTurnBattle);
    }
}


using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class btn_TestBattleTurn : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Outline outline;

    private void Start()
    {
        button = GetComponent<Button>();
        outline = GetComponent<Outline>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        LocatorManager.Instance.turnManager.playerTurnState.Exit();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.effectColor = Color.cyan;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.effectColor = Color.Lerp(Color.cyan, new Color(243/255, 74/255, 74/266, 145/255), 0.8f);
    }
}


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
    }
    
    private void Update()
    {
        if (LocatorManager.Instance.turnManager.playerTurnState.isNextTurnBattle)
        {
            btn_TestBattleTurn.SetActive(true);
            btn_TestNextTurn.SetActive(false);
        }
        else
        {
            btn_TestBattleTurn.SetActive(false);
            btn_TestNextTurn.SetActive(true);

        }
    }
}

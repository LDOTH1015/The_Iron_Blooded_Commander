using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTurnState : ITurnState
{
    // 씬전환이 이뤄져야함 UIManager의 HideAndTransition
    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    // 뭐 할게 있나?
    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    // TransitionToPlayerTurn 다시 플레이어턴에 가야하고 IsNextTurnBattle false로 돌려야함
    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}

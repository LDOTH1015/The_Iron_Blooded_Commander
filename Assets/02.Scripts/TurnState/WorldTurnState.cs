using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTurnState : ITurnState
{
    // 메인화면 UI전환정도?
    public void Enter()
    {
        // 현재 내용 없음
    }
    
    // 고정이벤트 타임라인에 넣기, 확률이벤트발생 시 타임라인에 넣기
    public void Execute()
    {
        // 현재 내용 없음
        Exit();
    }
    
    // TransitionToPlayerTurn
    public void Exit()
    {
        LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.playerTurnState);
    }
}
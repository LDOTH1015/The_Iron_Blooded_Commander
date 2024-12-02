using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurnState : ITurnState
{
    
    // 1. AI재화상태 업데이트
    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    // AI상태와 플레이어 상태 비교 후 침략여부 결정 -> 결정 후 타임매니저 이벤트타임라인에 추가
    // 직전에 플레이어를 침공했다면 침략여부결정 때 확률을 확 낮출 수 있는 변수 필요
    public void Execute()
    {
        throw new System.NotImplementedException();
    }

    // TransitionToWorldTurn
    public void Exit()
    {
        throw new System.NotImplementedException();
    }
}

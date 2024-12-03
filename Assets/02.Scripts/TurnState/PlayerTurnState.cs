using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : ITurnState
{
    // TimeManager로부터 받는 종료된 이벤트 ID리스트
    public List<int> completedEvents = new List<int>();
    
    public void Enter()
    {
        // TODO: 플레이어 턴 진입 시 
        // 1. 타임매니저로부터 현재시간 받아와서 현재시간 UI업데이트, 이벤트타임라인 일자수차감
        // 2. 타임매니저로부터 종료되는 이벤트 받아와서 재화상태업데이트, 완료UI팝업
        // 3. 타임매니저로부터 다음이벤트가 배틀이면 IsNextTurnBattle true업데이트해줘야함
    }

    public void Execute()
    {
        // TODO: 이벤트가 발생하면(영지에서 이벤트관련 UI버튼 눌리면) 해당 이벤트발생을 타임매니저에 전달
                
    }

    // TransitionTo BattleTurn or AITurn
    public void Exit()
    {
        
    }
}

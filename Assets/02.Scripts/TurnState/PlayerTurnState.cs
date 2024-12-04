using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : ITurnState
{
    // TimeManager로부터 받는 종료된 이벤트 리스트
    public List<EventDataTable> completedEvents = new List<EventDataTable>();
    
    
    public void Enter()
    {
        // TODO: 플레이어 턴 진입 시 
        // 0. 플레이어턴에 맞는 UI켜기
        // 1. 타임매니저로부터 현재시간 받아와서 현재날짜 UI업데이트, 이벤트타임라인 일자수차감
        LocatorManager.Instance.timeManager.UpdateTimeline();
        // 2. 타임매니저로부터 종료되는 이벤트 받아와서 재화상태업데이트, 완료UI팝업
        // -> 일단 1번에서 종료되는 이벤트는 받아왔음.
        // -> 결과값도 이미 테이블안에 담겨져 있음. 이걸 어떻게 DomainDataTable에 넣는가가 문제임
        // 3. 타임매니저로부터 다음이벤트가 배틀이면 IsNextTurnBattle true업데이트해줘야함
    }

    public void Execute()
    {
        // TODO: 이벤트가 발생하면(영지에서 이벤트관련 UI버튼 눌리면) 해당 이벤트발생을 타임매니저에 전달
        // ->해당 방법은 각 UI가 담당함 Execute가 담당할 일이 아님
        // TODO: 
                
    }

    // TransitionTo BattleTurn or AITurn
    public void Exit()
    {
        // IsNextTurnBattle == false일때,
        LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.aiTurnState);
        // IsNextTurnBattle == true일때,
        LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.battleTurnState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : ITurnState
{
    private bool isNextTurnBattle = false;
    // TimeManager로부터 받는 종료된 이벤트 리스트
    public List<Event> completedEvents = new List<Event>();
    
    
    public void Enter()
    {
        // TODO: 플레이어 턴 진입 시 
        // 0. 플레이어턴에 맞는 UI켜기
        // 1. 타임매니저로부터 현재시간 받아와서 현재날짜 UI업데이트, 이벤트타임라인 일자수차감
        LocatorManager.Instance.timeManager.UpdateTimeline();
        // 2. 타임매니저로부터 종료되는 이벤트 받아와서 재화상태업데이트, 완료UI팝업
        // -> 일단 1번에서 종료되는 이벤트는 받아왔음.
        // -> 결과값도 이미 테이블안에 담겨져 있음. 이걸 어떻게 DomainDataTable에 넣는가가 문제임
        UpdateEventsResult();
        // 3. 타임매니저로부터 다음이벤트가 배틀이면 IsNextTurnBattle true업데이트해줘야함
    }
    
    public void Execute()
    {
        // 마땅히 할 게 없음 Excute가
    }

    // TransitionTo BattleTurn or AITurn
    public void Exit()
    {
        // IsNextTurnBattle == false일때,
        if (!isNextTurnBattle)
        {
            LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.aiTurnState);
        }
        // IsNextTurnBattle == true일때,
        else
        {
            LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.battleTurnState);
        }
    }
    
    private void UpdateEventsResult()
    {
        for (int i = 0; i < completedEvents.Count; i++)
        {
            // 훈련결과 업데이트
            if (completedEvents[i].ResultType == "TrainingLevel")
            {
                LocatorManager.Instance.dataManager.unitTypeInfo.Data.UnitType[0].TrainingLevel +=
                    (int)completedEvents[i].ResultValue;
            }
            
            // 공격받았을 때의 경고 업데이트.
            if (completedEvents[i].ResultType == "WarnOfAttacked")
            {
                // 경고 유아이 팝업
                // UIManager.Instance.Show<UI_WarnOfAttacked>();
            }
            // 실제로 영지에 쳐들어옴
            if (completedEvents[i].ResultType == "UnderAttack")
            {
                isNextTurnBattle = true;
                // TODO: 턴 진행 버튼이 전투개시버튼으로 바뀌어야함
                // UIManager.Instance.Show<UI_OpenBattleField>();
                // 일반 턴진행버튼은 비활성화 하거나, 없애야 함
                // 해당 UI스크립트에는 Exit()실행시켜주면됨 짜피 EXIT에서 배틀씬으로 넘어갈건지 아닌지 구별하니까

            }
        }
    }
}

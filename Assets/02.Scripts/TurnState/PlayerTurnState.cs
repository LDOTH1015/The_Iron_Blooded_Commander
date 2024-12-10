using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnState : ITurnState
{
    // TimeManager로부터 받는 종료된 이벤트 리스트
    public List<Event> temptList = new List<Event>();
    public List<Event> completedEvents = new List<Event>();

    public bool isNextTurnBattle = false;
    public bool isLoadingOn;
    public bool isWarRumorEvent = false;
    
    
    // 이렇게 하면 문제가 있음
    // 현재 내가 만들어둔 로직대로 턴을 진행했을경우
    // BattleTurnState -> PlayerTurnState 돌아오면 여전히 시간이 진행된다 
    // BattleTurnState -> PlayerTurnState에서 BattleTurnState진입전후로 시간을 고정하는 방법을 생각해내야함
    // 아마 bool변수 하나 두고 입장시 켜고 끄고하는 방식으로 설정을 하면 될듯?
    // 아니면 그냥 똑같이 시간을 진행시키는게 차라리 더 개연성 있으려나? 이건 의논이 필요할듯하다.
        
    public void Enter()
    {
        // TODO: 플레이어 턴 진입 시 
        // 0. 플레이어턴에 맞는 UI켜기
        // 1. 타임매니저로부터 현재시간 받아와서 현재날짜 UI업데이트, 이벤트타임라인 일자수차감
        LocatorManager.Instance.timeManager.UpdateTimeline();
        foreach (Event eventDataTable in temptList)
        {
            completedEvents.Add(eventDataTable);
        }
        temptList.Clear();
        // 2. 타임매니저로부터 종료되는 이벤트 받아와서 재화상태업데이트, 완료UI팝업
        // -> 일단 1번에서 종료되는 이벤트는 받아왔음.
        // -> 결과값도 이미 테이블안에 담겨져 있음. 이걸 어떻게 DomainDataTable에 넣는가가 문제임
        UpdateEventsResult();
        // 3. 타임매니저로부터 다음이벤트가 배틀이면 IsNextTurnBattle true업데이트해줘야함
        
        // 로딩창 끄게하는 boo변수(로딩창 스크립트에서 변수를 확인하고 끔)
        isLoadingOn = false;
    }
    
    
    
    public void Execute()
    {
        // 현재 내용 없음
    }
    
    // 턴진행버튼은 Exit()랑 연결해야함
    public void Exit()
    {
        isLoadingOn = true;
        // Exit()실행 후 ai턴이나 배틀턴으로 턴 넘김
        if (!isNextTurnBattle)
        {
            UIManager.Instance.Show<pnl_Loading>();
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
            Debug.Log($"{completedEvents[i].Name} 결과 업데이트");
            // 훈련결과 업데이트
            if (completedEvents[i].ID == "4000")
            {
                LocatorManager.Instance.dataManager.userUnitTypeInfo.Data.UnitType[0].TrainingLevel +=
                    (int)completedEvents[i].ResultValue;
                UIManager.Instance.Show<UI_ResultsOfTrainUnits>();
                completedEvents.RemoveAt(i);
            }
            // 공격받았을 때의 경고 업데이트.
            else if (completedEvents[i].ID == "4500")
            {
                // 소문이벤트인지 분기점을 잡는 bool변수
                isWarRumorEvent = true;
                // 경고 유아이 팝업
                UIManager.Instance.Show<UI_WarnOfAttacked>();
                Debug.Log("UI떳냐? 안떴으면 버그난거임");
                completedEvents.RemoveAt(i);
            }
            // 실제로 영지에 쳐들어옴
            else if (completedEvents[i].ID == "4501")
            {
                isNextTurnBattle = true;
                // TODO: 턴 진행 버튼이 전투개시버튼으로 바뀌어야함
                // 해당 UI스크립트에는 Exit()실행시켜주면됨 짜피 EXIT에서 배틀씬으로 넘어갈건지 아닌지 구별하니까
                Debug.Log("전투개시 떳냐? 안떴으면 버그난거임");
                completedEvents.RemoveAt(i);
            }
        }
    }
}

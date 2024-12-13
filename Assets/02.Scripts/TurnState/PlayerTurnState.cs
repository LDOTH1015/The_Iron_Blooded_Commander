using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTurnState : ITurnState
{
    // TimeManager로부터 받는 종료된 이벤트 리스트
    public List<EventData> temptList = new List<EventData>();
    public List<EventData> completedEvents = new List<EventData>();
    public Dictionary<string, IEventHandler> eventHandlers;
    
    // 해당 턴에 종료된 이벤트 갯수 UI에 표현하기 위한 변수
    public int completedEventsCount;

    public bool isLoadingOn;
    public bool isWarRumorEvent = false;

    public event Action OnDomainChanged;
    
    public event Action<bool> OnNextButtonChanged;
    private bool isNextTurnBattle;
    public bool IsNextTurnBattle
    {
        get => isNextTurnBattle;
        set
        {
            if (isNextTurnBattle != value && SceneManager.GetActiveScene().name == "Test_SOLS")
            {
                isNextTurnBattle = value;
                OnNextButtonChanged?.Invoke(isNextTurnBattle);
            }
            else if (isNextTurnBattle != value)
            {
                isNextTurnBattle = value;
            }
        }
    }
    
    // 완료이벤트 딕셔너리를 위한 생성자
    public PlayerTurnState()
    {
        eventHandlers = new Dictionary<string, IEventHandler>
        {
            { "evd000", new EventResult_evd000() },
            { "evai000", new EventResult_evai000() },
            { "evai001", new EventResult_evai001() }
        };
    }
    
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
        UIManager.Instance.Show<UI_Domain>();
        UIManager.Instance.Show<UI_NextProgressBtn>();
    }
    
    
    
    public void Execute()
    {
        // 1. 타임매니저로부터 현재시간 받아와서 현재날짜 UI업데이트, 이벤트타임라인 일자수차감
        LocatorManager.Instance.timeManager.UpdateTimeline();
        foreach (EventData eventDataTable in temptList)
        {
            completedEvents.Add(eventDataTable);
        }
        temptList.Clear();
        // 2. 타임매니저로부터 종료되는 이벤트 받아와서 재화상태업데이트, 완료UI팝업
        // -> 일단 1번에서 종료되는 이벤트는 받아왔음.
        // -> 결과값도 이미 테이블안에 담겨져 있음. 이걸 어떻게 DomainDataTable에 넣는가가 문제임
        // 로딩창 끄게하는 bool변수(로딩창 스크립트에서 변수를 확인하고 끔)
        isLoadingOn = false;
        // 3. 타임매니저로부터 다음이벤트가 배틀이면 IsNextTurnBattle true업데이트해줘야함
        UpdateEventsResult();
    }
    
    // 턴진행버튼은 Exit()랑 연결해야함
    public void Exit()
    {
        isLoadingOn = true;
        // Exit()실행 후 ai턴이나 배틀턴으로 턴 넘김
        if (!IsNextTurnBattle)
        {
            UIManager.Instance.Show<pnl_Loading>();
            UIManager.Instance.Hide<UI_Domain>();
            UIManager.Instance.Hide<UI_NextProgressBtn>();
            LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.aiTurnState);
            
        }
        // IsNextTurnBattle == true일때,
        else
        {
            UIManager.Instance.Hide<UI_Domain>();
            UIManager.Instance.Hide<UI_NextProgressBtn>();
            LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.battleTurnState);
        }
    }
    
    private void UpdateEventsResult()
    {
        int tempCount = completedEvents.Count;
        completedEventsCount = tempCount;
        
        for (int i = completedEvents.Count - 1; i >= 0; i--)
        {
            if (completedEvents.Count == 0)
                break;
            EventData currentEvent = completedEvents[i];
            if (eventHandlers.TryGetValue(currentEvent.ID, out IEventHandler handler))
            {
                handler.Handle(currentEvent);
                completedEvents.RemoveAt(i);
                OnDomainChanged?.Invoke();
            }
        }
    }
}

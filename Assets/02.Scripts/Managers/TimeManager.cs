using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class TimeManager : IManager
{
    [Header("Date Variables")]
    private int playerCurrentDate;
    
    [HideInInspector]
    public int currentYear;
    public int currentMonth;
    public int currentDay;

    // 이벤트데이터테이블
    private EventInfo eventInfo; 
    
    
    [HideInInspector]
    // 대기열 컬렉션 만들기
    public List<EventData> scheduledEvents;
    
    public void Initialize()
    {
        // 일단 0으로 초기화하는데, 만약에 저장된 플레이어데이터가 존재한다면
        // 불러오기여부확인 후 새게임일경우 0, 불러오기일 경우 플레이어데이터에서 캐싱해오기
        // 대기열 컬렉션의 경우에도 저장하기, 불러오기 생각해서 캐싱해올 방법 생각해두기
        playerCurrentDate = 0;
        currentYear = 1;
        currentMonth = 1;
        currentDay = 1;
        scheduledEvents = new List<EventData>();
        eventInfo = LocatorManager.Instance.dataManager.eventInfo;
    }

    // scheduledEvent에 이벤트를 등록하는 모든행위에 반드시 수반되어야 하는 메서드
    public void AddEventToTimeline(string eventID)
    {
        // TODO: 타임라인 리스트?딕셔너리?에 이벤트발생 시 해당이벤트 넣어주는 로직. param을 뭐로 설정할지 헷갈림
        // TODO: DueDate랑 같이 해당 이벤트 대기열 컬렉션에 삽입해줘야댐
        AddEventWithDueDate(eventID); // 이 메서드 하나로 TODO둘 다 충족함
        
        SortTimelineEvent();
    }
    
    // 타임라인을 종료예정일순DueDate으로 정렬하는 메서드
    private void SortTimelineEvent()
    {
        //퀵 정렬을 사용해서 정렬시도
        QuickSort(scheduledEvents, 0, scheduledEvents.Count - 1);
    }
    
    // 플레이어가 이벤트 발생 시 스케쥴이벤트리스트에 등록및 예정종료일을 결정하는 메서드
    private void AddEventWithDueDate(string eventID)
    {
        int? _dueDate = null;
        
        for (int i = 0; i < eventInfo.Data.Event.Count; i++)
        {
            // 이벤트ID를 기준으로 전체 이벤트 데이터테이블에서 인덱싱
            if (eventInfo.Data.Event[i].ID == eventID.ToString())
            {
                // // 예정된 이벤트 대기열에 eventID에 맞는 이벤트를 추가
                // scheduledEvents.Add(eventInfo.Data.EventDataTable[i]);
                // Debug.Log($"{scheduledEvents.Count}");
                // // UI팝업용 DueDate설정
                // _dueDate = Random.Range(eventInfo.Data.EventDataTable[i].MinClearTime, eventInfo.Data.EventDataTable[i].MaxClearTime);
                // eventInfo.Data.EventDataTable[i].DueDate = _dueDate.Value;
                // break;
                
                // 수정 구분선
                
                string jsonString = JsonConvert.SerializeObject(eventInfo.Data.Event[i]);
                EventData newEvent = JsonConvert.DeserializeObject<EventData>(jsonString);
                _dueDate = Random.Range(newEvent.MinClearTime, newEvent.MaxClearTime);
                newEvent.DueDate = _dueDate.Value;
                scheduledEvents.Add(newEvent);
                break;
            }
        }

        // // 추가한 이벤트 스케쥴이벤트리스트에서 DueDate수정
        // if (_dueDate.HasValue)
        // {
        //     for (int i = 0; i < scheduledEvents.Count; i++)
        //     {
        //         if (scheduledEvents[i].ID == eventID)
        //         {
        //             scheduledEvents[i].DueDate = _dueDate.Value;
        //             break;
        //         }
        //     }    
        // }
        
    }
    
    // 플레이어 턴 시작 시? 아님 종료 시? 날짜 변경 시 타임라인이벤트들의 남은기간들을 일제히 차감하는 메서드
    // Player State의 Enter()에 들어갈듯
    // 예정된 이벤트들의 결과를 UI에 표시해주기(이건 여기서 할 일아님, PlayerState나 UI로직에서 구현)
    public void UpdateTimeline()
    {
        if (scheduledEvents.Count > 0)
        {
            // [0]번째 이벤트의 DueDate만큼 playerCurrentDate를 더해주기
            var elapsedTime = scheduledEvents[0].DueDate;
            playerCurrentDate += elapsedTime;
            Debug.Log($"지난 경과일 {elapsedTime}. 업데이트경과일{playerCurrentDate}");
            // 더한 날짜를 기준으로 년월일 정보 업데이트
            UpdateDateForUI(playerCurrentDate);
            
            for (int i = scheduledEvents.Count-1; i>=0 ; i--)
            {
                // 스케쥴이벤트리스트의 [0]번째 이벤트의 DueDate만큼 해당리스트 모든 원소의 DueDate를 차감
                scheduledEvents[i].DueDate -= elapsedTime;
                
                // DueDate가 ==0인 애들의 ID를 모두 PlayerState에 넘겨주기
                // DueDate가 ==0인 이벤트들을 대기열 리스트에서 제거
                if (scheduledEvents[i].DueDate <= 0)
                {
                    LocatorManager.Instance.turnManager.playerTurnState.temptList.Add(scheduledEvents[i]);
                    Debug.Log($"{scheduledEvents[i].ID}이벤트 tempList로 전달");
                    scheduledEvents.RemoveAt(i);
                }
            }
        }
    }
    
    // 표시 날짜 계산 메서드
    private void UpdateDateForUI(int currentDate)
    {
        // 년 계산(일단 1년차부터 시작)
        currentYear = (currentDate / 365) + 1;
        
        // 현재 남은 일 수
        // _remainingDays가 0이면 1월1일 364면 12월31일임
        int _remainingDays = currentDate % 365;
        // 각 월별 일자 수 
        int[] _daysInMonths = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
        
        // 월,일 계산
        int month = 1; //1월로 시작
        for (int i = 0; i < _daysInMonths.Length; i++)
        {
            if (_remainingDays < _daysInMonths[i])
            {
                // _remainingDays가 해당 월 일자 수보다 낮으면 월이 결정됨
                break;
            }
            
            _remainingDays -= _daysInMonths[i];
            month++;
        }
        currentMonth = month;
        int day = _remainingDays + 1; // 1일부터 시작, 위에서 일자계산 까지 되있어서 +1만해주면됨
        currentDay = day;
    }
    
    // 아래는 퀵정렬을 위한 메서드들임 Partion~QuickSort까지
    private int Partion(List<EventData> events, int low, int high)
    {
        EventData pivot = events[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (events[j].DueDate <= pivot.DueDate)
            {
                i++;
                Swap(events, i, j);
            }
        }
        Swap(events, i+1, high);
        return i + 1;
    }

    private void Swap(List<EventData> events, int i, int j)
    {
        EventData temp = events[i];
        events[i] = events[j];
        events[j] = temp;
    }

    private void QuickSort(List<EventData> events, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partion(events, low, high);
            QuickSort(events, low, pivotIndex-1);
            QuickSort(events, pivotIndex+1, high);
        }
    }
}

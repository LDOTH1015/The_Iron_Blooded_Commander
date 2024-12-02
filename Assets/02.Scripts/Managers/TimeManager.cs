using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : IManager
{
    [Header("Date Variables")]
    private int playerCurrentDate;

    private int currentYear;
    private int currentMonth;
    private int currentDay;
    
    // 이벤트데이터테이블
    private EventInfo eventInfo = LocatorManager.Instance.dataManager.eventData;
    
    
    public void Initialize()
    {
        // 일단 0으로 초기화하는데, 만약에 저장된 플레이어데이터가 존재한다면
        // 불러오기여부확인 후 새게임일경우 0, 불러오기일 경우 플레이어데이터에서 캐싱해오기
        playerCurrentDate = 0;
        
    }

    public void AddEvenetToTimeline(int ID)
    {
        // TODO: 타임라인 리스트?딕셔너리?에 이벤트발생 시 해당이벤트 넣어주는 로직. param을 뭐로 설정할지 헷갈림
        
        
        UpdateTimelineEvent();
    }
    
    // 타임라인을 종료예정일순으로 정렬하는 메서드
    private void UpdateTimelineEvent()
    {
        
    }
    
    // 플레이어 턴 시작 시? 아님 종료 시? 날짜 변경 시 타임라인이벤트들의 남은기간들을 일제히 차감하는 메서드
    // 각 Player State의 Enter()에 들어갈듯
    public void UpdateTimelineDate()
    {
        
    }
    
    // 플레이어가 이벤트 발생 시 예정종료일을 결정하는 로직
    private void DecideEventDueDate()
    {
        
    }
    
    // 표시 날짜 계산 메서드
    private void UpdateCurrentDay(int currentDate)
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
}

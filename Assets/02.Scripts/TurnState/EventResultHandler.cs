using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventHandler
{
    void Handle(EventData e);
}

public class EventResult_evd000 : IEventHandler
{
    public void Handle(EventData e)
    {
        if (LocatorManager.Instance.dataManager.userUnitTypeInfo.Data.UserUnitType[0].ID == "uUnTp001" &&
            LocatorManager.Instance.dataManager.userUnitTypeInfo.Data.UserUnitType[0].DomainID == "do007" )
        {
            LocatorManager.Instance.dataManager.userUnitTypeInfo.Data.UserUnitType[0].TrainingLevel += (int)e.ResultValue;
            UIManager.Instance.Show<UI_ResultsOfTrainUnits>();
        }
        else
        {
            Debug.Log("훈련미완료. 뭔가 문제생김 디버깅필요");
        }
    }
}

public class EventResult_evai000 : IEventHandler
{
    public void Handle(EventData e)
    {
        LocatorManager.Instance.turnManager.playerTurnState.isWarRumorEvent = true;
        UIManager.Instance.Show<UI_WarnOfAttacked>();
    }
}

public class EventResult_evai001 : IEventHandler
{
    public void Handle(EventData e)
    {
        LocatorManager.Instance.turnManager.playerTurnState.IsNextTurnBattle = true;
        Debug.Log("전투개시 떳냐? 안떴으면 버그난거임");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventHandler
{
    void Handle(Event e);
}

public class EventResult_4000 : IEventHandler
{
    public void Handle(Event e)
    {
        LocatorManager.Instance.dataManager.userUnitTypeInfo.Data.UserUnitType[0].TrainingLevel += (int)e.ResultValue;
        UIManager.Instance.Show<UI_ResultsOfTrainUnits>();
    }
}

public class EventResult_4500 : IEventHandler
{
    public void Handle(Event e)
    {
        LocatorManager.Instance.turnManager.playerTurnState.isWarRumorEvent = true;
        UIManager.Instance.Show<UI_WarnOfAttacked>();
    }
}

public class EventResult_4501 : IEventHandler
{
    public void Handle(Event e)
    {
        LocatorManager.Instance.turnManager.playerTurnState.IsNextTurnBattle = true;
        Debug.Log("전투개시 떳냐? 안떴으면 버그난거임");

    }
}
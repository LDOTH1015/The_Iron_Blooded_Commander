using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class UI_CurrentDate : UIBase
{
    TextMeshProUGUI currentDateText;
    

    protected override void Awake()
    {
        base.Awake();
        currentDateText = GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        currentDateText.text = $"{LocatorManager.Instance.timeManager.currentYear}년{LocatorManager.Instance.timeManager.currentMonth}월{LocatorManager.Instance.timeManager.currentDay}일";
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class pnl_CheckTryDrill : UIBase
{
    private Button confirmBtn;
    private Button cancelBtn;
    private TextMeshProUGUI checkTryDrillText;

    protected override void Awake()
    {
        base.Awake();
        InitUI();
    }

    private void InitUI()
    {
        confirmBtn = transform.GetChild(0).gameObject.GetComponent<Button>();
        cancelBtn = transform.GetChild(1).gameObject.GetComponent<Button>();
        checkTryDrillText = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        confirmBtn.onClick.AddListener(OnConfirmBtnClicked);
        cancelBtn.onClick.AddListener(OnCancelBtnClicked);
    }

    private void Start()
    {
        var eventData = LocatorManager.Instance.dataManager.eventInfo.Data;
        checkTryDrillText.text =
            $"{eventData.Event[0].Description}\n\n예상일:{eventData.Event[0].MinClearTime}일 ~ {eventData.Event[0].MaxClearTime}일";
    }

    private void OnConfirmBtnClicked()
    {
        LocatorManager.Instance.timeManager.AddEventToTimeline(4000);
        // 결과값 미리 계산해서 sceduledEvents에 집어넣기
        CalculateResultValue();
        Hide();
    }

    private void OnCancelBtnClicked()
    {
        Hide();
    }

    private void CalculateResultValue()
    {
        for (int i = 0; i < LocatorManager.Instance.timeManager.scheduledEvents.Count; i++)
        {
            if (LocatorManager.Instance.timeManager.scheduledEvents[i].ResultType == "TrainingLevel")
            {
                LocatorManager.Instance.timeManager.scheduledEvents[i].ResultValue = 1.0f;
            }
        }
    }
}

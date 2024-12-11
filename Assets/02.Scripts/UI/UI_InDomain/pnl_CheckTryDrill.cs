using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pnl_CheckTryDrill : UIBase
{
    private Button confirmBtn;
    private Button cancelBtn;

    protected override void Awake()
    {
        base.Awake();
        InitUI();
    }

    private void InitUI()
    {
        confirmBtn = transform.GetChild(0).gameObject.GetComponent<Button>();
        cancelBtn = transform.GetChild(1).gameObject.GetComponent<Button>();
        confirmBtn.onClick.AddListener(OnConfirmBtnClicked);
        cancelBtn.onClick.AddListener(OnCancelBtnClicked);
    }

    private void OnConfirmBtnClicked()
    {
        LocatorManager.Instance.timeManager.AddEventToTimeline(4000);
        // 결과값 미리 계산해서 sceduledEvents에 집어넣기
        CalculateResultValue();
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

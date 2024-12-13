using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using TMPro;
using UnityEngine;

public class UI_DomainStateBar : UIBase
{
    private TextMeshProUGUI textDate;
    private TextMeshProUGUI textPopulation;
    private TextMeshProUGUI textPublicOpinion;
    private TextMeshProUGUI textFame;
    private TextMeshProUGUI textGold;
    private TextMeshProUGUI textSteel;
    private TextMeshProUGUI textFood;
    private TextMeshProUGUI textCaptivity;

    protected override void Awake()
    {
        base.Awake();
        InitStateBar();
    }

    private void InitStateBar()
    {
        textDate = transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>();
        textPopulation = transform.GetChild(3).gameObject.GetComponent<TextMeshProUGUI>();
        textPublicOpinion = transform.GetChild(4).gameObject.GetComponent<TextMeshProUGUI>();
        textFame = transform.GetChild(5).gameObject.GetComponent<TextMeshProUGUI>();
        textGold = transform.GetChild(6).gameObject.GetComponent<TextMeshProUGUI>();
        textSteel = transform.GetChild(7).gameObject.GetComponent<TextMeshProUGUI>();
        textFood = transform.GetChild(8).gameObject.GetComponent<TextMeshProUGUI>();
        textCaptivity = transform.GetChild(9).gameObject.GetComponent<TextMeshProUGUI>();
        
        var timeManager = LocatorManager.Instance.timeManager;
        timeManager.OnDateChanged += UpdateTextDate;
        UpdateTextDate();
        
        var turnManager = LocatorManager.Instance.turnManager;
        turnManager.playerTurnState.OnDomainChanged += UpdateDomainState;
        UpdateDomainState();
    }

    private void OnDestroy()
    {
        if(LocatorManager.Instance != null)
            LocatorManager.Instance.timeManager.OnDateChanged -= UpdateTextDate;
        
        if(LocatorManager.Instance != null)
            LocatorManager.Instance.turnManager.playerTurnState.OnDomainChanged -= UpdateDomainState;
    }

    private void UpdateTextDate()
    {
        var timeManager = LocatorManager.Instance.timeManager;
        textDate.text = $"{timeManager.currentYear}년{timeManager.currentMonth}월{timeManager.currentDay}일";
    }

    private void UpdateDomainState()
    {
        var dataManager = LocatorManager.Instance.dataManager;
        if (dataManager.domainInfo.Data.Domain[6].State == "Player")
        {
            textPopulation.text = $"{dataManager.domainInfo.Data.Domain[6].Population}";
            textPublicOpinion.text = $"{dataManager.domainInfo.Data.Domain[6].PublicOpinion}";
            textFame.text = $"{dataManager.domainInfo.Data.Domain[6].Fame}";
            textGold.text = $"{dataManager.domainInfo.Data.Domain[6].Gold}";
            textSteel.text = $"{dataManager.domainInfo.Data.Domain[6].Steel}";
            textFood.text = $"{dataManager.domainInfo.Data.Domain[6].Food}";
            textCaptivity.text = $"{dataManager.domainInfo.Data.Domain[6].Captivity}";
        }
        else
        {
            Debug.Log("스테이트 바 도메인 인덱싱 잘못됨");
        }
    }
}

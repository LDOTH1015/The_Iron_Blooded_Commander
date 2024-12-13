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

    private void Start()
    {
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
    }

    private void OnDestroy()
    {
        var timeManager = LocatorManager.Instance.timeManager;
        timeManager.OnDateChanged -= UpdateTextDate;
    }

    private void UpdateTextDate()
    {
        var timeManager = LocatorManager.Instance.timeManager;
        textDate.text = $"{timeManager.currentYear}년{timeManager.currentMonth}월{timeManager.currentDay}일";
    }
}

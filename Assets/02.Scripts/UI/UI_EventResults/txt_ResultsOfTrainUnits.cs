using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

public class txt_ResultsOfTrainUnits : UIBase
{
    private TextMeshProUGUI resultsText;
    StringBuilder earlyText = new StringBuilder();
    StringBuilder lateText = new StringBuilder();


    protected override void Awake()
    {
        base.Awake();
        resultsText = GetComponent<TextMeshProUGUI>();
        ShowUIText();
    }

    private void ShowUIText()
    {
        earlyText.Append(LocatorManager.Instance.dataManager.eventInfo.Data.Event[0].EarlyCompletionPhrase);
        lateText.Append(LocatorManager.Instance.dataManager.eventInfo.Data.Event[0].DelayedCompletionPhrase);

        
        resultsText.text = earlyText.ToString();
        
        
    }
}

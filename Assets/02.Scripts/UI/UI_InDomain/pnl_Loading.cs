
using System;
using System.Collections;
using UnityEngine;

public class pnl_Loading : UIBase
{
    private WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(2.0f);
    
    private void Update()
    {
        if (!LocatorManager.Instance.turnManager.playerTurnState.IsLoadingOn)
            StartCoroutine(HideUI());
    }

    private IEnumerator HideUI()
    {
        yield return  waitForSecondsRealtime;
        Hide();
    }
}

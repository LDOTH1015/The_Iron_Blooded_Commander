
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class pnl_Loading : UIBase
{
    private WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(2.0f);
    private WaitWhile waitWhileLoading = new WaitWhile(() => LocatorManager.Instance.turnManager.playerTurnState.isLoadingOn);
        
    // private void Update()
    // {
    //     if (!LocatorManager.Instance.turnManager.playerTurnState.isLoadingOn)
    //         StartCoroutine(HideUI());
    // }
    //
    // private IEnumerator HideUI()
    // {
    //     yield return waitForSecondsRealtime;
    //     Hide();
    // }

    protected override void Awake()
    {
        StartCoroutine(Hide2UI());
    }

    private IEnumerator Hide2UI()
    {
        yield return waitWhileLoading;
        yield return waitForSecondsRealtime;
        Hide();
    }
}

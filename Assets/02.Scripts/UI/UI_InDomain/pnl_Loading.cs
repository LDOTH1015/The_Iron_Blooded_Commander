
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class pnl_Loading : UIBase
{
    private WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(2.0f);
    private WaitWhile waitWhileLoading = new WaitWhile(() => LocatorManager.Instance.turnManager.playerTurnState.isLoadingOn);

    protected override void Awake()
    {
        base.Awake();
        StartCoroutine(Hide2UI());
    }

    private void Start()
    {
        canvas.sortingOrder = 30;
    }

    private IEnumerator Hide2UI()
    {
        yield return waitForSecondsRealtime;
        yield return waitWhileLoading;
        Hide();
    }
}

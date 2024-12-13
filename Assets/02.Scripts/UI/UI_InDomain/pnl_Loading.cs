
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pnl_Loading : UIBase
{
    private WaitForSecondsRealtime waitForSecondsRealtime = new WaitForSecondsRealtime(2.0f);
    private WaitForSeconds textloadingtime = new WaitForSeconds(0.4f);
    private Image loadingImage;
    private TextMeshProUGUI loadingText;
    
    protected override void Awake()
    {
        base.Awake();
        loadingImage = GetComponent<Image>();
        loadingText = transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        ChooseImages();
    }

    private void ChooseImages()
    {
        var resourcesImages = Resources.LoadAll<Sprite>("Image/IMG_Loading/");
        if(resourcesImages.Length == 0)
            Debug.Log("로딩 파일 경로 설정 다시");
        
        var randomIndex = UnityEngine.Random.Range(0, resourcesImages.Length);
        loadingImage.sprite = resourcesImages[randomIndex];
    }

    private void Start()
    {
        StartCoroutine(Hide2UI());
        canvas.sortingOrder = 30;
    }

    private IEnumerator Hide2UI()
    {
        string baseText = "Now Loading";
        int dotCount = 0;
        int maxDots = 3;

        while(LocatorManager.Instance.turnManager.playerTurnState.isLoadingOn)
        {
            loadingText.text = baseText + new string('.', dotCount);
            dotCount = (dotCount + 1) % (maxDots+1);
            yield return textloadingtime;
        }
        yield return waitForSecondsRealtime;
        Hide();
        
    }
}

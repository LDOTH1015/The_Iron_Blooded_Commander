using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICastleButton : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject uiCastleOutLine;

    private void Start()
    {
        uiCastleOutLine = transform.GetChild(0).gameObject;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiCastleOutLine.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiCastleOutLine.SetActive(false);
    }
}

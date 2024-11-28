using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UICastleButton : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private GameObject uiCastleOutLine;
    private Button button;
    private void Start()
    {
        uiCastleOutLine = transform.GetChild(0).gameObject;
        button = transform.GetChild(1).gameObject.GetComponent<Button>();
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

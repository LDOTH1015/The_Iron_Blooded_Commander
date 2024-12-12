using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Castle : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiCastleOutLine;
    private Button button;
    private void Start()
    {
        uiCastleOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        button = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiCastleOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiCastleOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiCastleOutLine.enabled = false;
    }
}
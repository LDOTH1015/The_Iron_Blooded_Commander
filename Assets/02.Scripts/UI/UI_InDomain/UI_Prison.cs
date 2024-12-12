using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Prison : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiPrisonOutLine;
    private Button prisonButton;
    private void Start()
    {
        uiPrisonOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        prisonButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiPrisonOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiPrisonOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiPrisonOutLine.enabled = false;
    }
}

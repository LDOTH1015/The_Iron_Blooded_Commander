using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Market : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiMarketOutLine;
    private Button marketButton;
    private void Start()
    {
        uiMarketOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        marketButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiMarketOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiMarketOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiMarketOutLine.enabled = false;
    }
}


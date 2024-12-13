using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Farm : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiFarmOutLine;
    private Button farmButton;
    private void Start()
    {
        uiFarmOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        farmButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiFarmOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiFarmOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiFarmOutLine.enabled = false;
    }
}

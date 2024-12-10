using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_WarnOfAttacked : UIBase, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Outline outline;

    protected override void Awake()
    {
        base.Awake();
        outline = transform.GetChild(0).gameObject.GetComponent<Outline>();
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hide();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }
}

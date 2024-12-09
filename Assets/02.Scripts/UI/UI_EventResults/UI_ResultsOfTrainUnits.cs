using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ResultsOfTrainUnits : UIBase , IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Outline outline;

    protected override void Awake()
    {
        base.Awake();
        outline = transform.GetChild(0).gameObject.GetComponent<Outline>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        outline.enabled = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Hide();
    }
}

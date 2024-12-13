using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Barrack : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiBarrackOutLine;
    private Button barrackButton;
    private void Start()
    {
        uiBarrackOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        barrackButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiBarrackOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiBarrackOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiBarrackOutLine.enabled = false;
    }
}

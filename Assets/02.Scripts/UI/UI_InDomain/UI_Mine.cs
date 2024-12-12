using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Mine : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiMineOutLine;
    private Button mineButton;
    private void Start()
    {
        uiMineOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        mineButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiMineOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiMineOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiMineOutLine.enabled = false;
    }
}

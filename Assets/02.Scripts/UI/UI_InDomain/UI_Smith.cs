using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Smith : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiSmithOutLine;
    private Button smithButton;
    private void Start()
    {
        uiSmithOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        smithButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiSmithOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiSmithOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiSmithOutLine.enabled = false;
    }
}

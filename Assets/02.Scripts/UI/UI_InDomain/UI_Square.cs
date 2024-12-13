using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Square : UIBase, IPointerEnterHandler, IPointerExitHandler
{
    private Image uiSquareOutLine;
    private Button squareButton;
    private void Start()
    {
        uiSquareOutLine = transform.GetChild(0).gameObject.GetComponent<Image>();
        squareButton = transform.GetChild(1).gameObject.GetComponent<Button>();
        
        uiSquareOutLine.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiSquareOutLine.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        uiSquareOutLine.enabled = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_TestBarrack : UIBase
{
    private Button testBarrackBtn;
    private Button tryDrillBtn;
    
    private GameObject btn_CheckCurrentUnit;
    private GameObject btn_TryDrill;

    
    protected override void Awake()
    {
        base.Awake();
        InitUI();
    }

    private void InitUI()
    {
        testBarrackBtn = GetComponent<Button>();
        testBarrackBtn.onClick.AddListener(OnBarrackBtnClicked);
        
        btn_CheckCurrentUnit = transform.GetChild(1).gameObject;
        btn_TryDrill = transform.GetChild(2).gameObject;
        
        btn_CheckCurrentUnit.SetActive(false);
        btn_TryDrill.SetActive(false);
        
    }

    private void OnBarrackBtnClicked()
    {
        if (!btn_CheckCurrentUnit.activeSelf)
        {
            btn_CheckCurrentUnit.SetActive(true);
            btn_TryDrill.SetActive(true);
        }
        else
        {
            btn_CheckCurrentUnit.SetActive(false);
            btn_TryDrill.SetActive(false);
        }
    }
    
}
    
    


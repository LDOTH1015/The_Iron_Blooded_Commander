using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_TryDrill : UIBase
{
    private Button tryDrillBtn;
    
    private GameObject btn_SwordMen;
    private GameObject btn_ShieldMen;
    private GameObject btn_CrossBowMen;

    protected override void Awake()
    {
        base.Awake();
        InitUI();
    }

    private void InitUI()
    {
        tryDrillBtn = GetComponent<Button>();
        tryDrillBtn.onClick.AddListener(OnTryDrillBtnClicked);
        
        btn_SwordMen = transform.GetChild(1).gameObject;
        btn_CrossBowMen = transform.GetChild(2).gameObject;
        btn_ShieldMen = transform.GetChild(3).gameObject;
        
        btn_SwordMen.SetActive(false);
        btn_CrossBowMen.SetActive(false);
        btn_ShieldMen.SetActive(false);
    }

    private void OnTryDrillBtnClicked()
    {
        if (!btn_SwordMen.activeSelf)
        {
            btn_SwordMen.SetActive(true);
            btn_CrossBowMen.SetActive(true);
            btn_ShieldMen.SetActive(true);
        }
        else
        {
            btn_SwordMen.SetActive(false);
            btn_CrossBowMen.SetActive(false);
            btn_ShieldMen.SetActive(false);
        }
    }
}

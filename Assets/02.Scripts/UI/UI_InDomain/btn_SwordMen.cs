using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_SwordMen : UIBase
{
    Button swordMenBtn;

    protected override void Awake()
    {
        base.Awake();
        swordMenBtn = GetComponent<Button>();
        swordMenBtn.onClick.AddListener(OnClickSwordMenBtn);
    }

    private void OnClickSwordMenBtn()
    {
        if(UIManager.Instance)
        UIManager.Instance.Show<pnl_CheckTryDrill>();
    }
}

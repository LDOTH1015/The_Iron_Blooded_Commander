using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class btn_EndBattle : UIBase
{
    Button button;
    protected override void Awake()
    {
        base.Awake();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        LocatorManager.Instance.turnManager.battleTurnState.Execute();
    }
}

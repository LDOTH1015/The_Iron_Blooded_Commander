using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_KnightChange : UIBase
{
    protected override void Awake()
    {
        canvasType = "canvasForCameraMoving";
        base.Awake();
    }

    public override void Hide()
    {
        base.Hide();
    }
    public void UI_KnightChangeCheckOn()
    {
        UIManager.Instance.Show<UI_KnightChangeCheck>();
    }
}

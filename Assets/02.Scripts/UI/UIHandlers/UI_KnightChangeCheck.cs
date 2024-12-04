using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_KnightChangeCheck : UIBase
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
}

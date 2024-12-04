using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_UnitDivisionInfo : UIBase
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

    public void ChangeKnightInventoryOn()
    {
        UIManager.Instance.Show<UI_KnightChange>();
    }
    public void UI_MissionSelectOn()
    {
        UIManager.Instance.Show<UI_MissionSelect>();
    }
    public void UI_UnitDivisionSelectOn()
    {
        UIManager.Instance.Show<UI_UnitDivisionSelect>();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Domain : UIBase
{
    private void Start()
    {
        UIManager.Instance.Show<UI_NextProgressBtn>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PopupBattleStart : UIBase
{
    public void OnClickYes()
    {
        this.gameObject.SetActive(false);
        // TODO : 전투 시작으로 넘어감
    }
    public void OnClickNo()
    {
        this.gameObject.SetActive(false);
    }
}

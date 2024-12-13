using UnityEngine;

public class btn_DeployedKnight : MonoBehaviour
{

    public void OnClickBtn()
    {
        UIManager.Instance.Show<UI_PopupKnightInfo>();
    }
}

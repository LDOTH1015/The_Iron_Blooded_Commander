using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class btn_OwnedKnight : UIContent<KnightDefault>
{
    [SerializeField] private Image thumbnailKnight;
    [SerializeField] private TMP_Text txtKnightName;
    

    public void OnClickBtn()
    {
        UIManager.Instance.Show<UI_PopupKnightInfo>();
    }

    public override void SetData(KnightDefault inputData)
    {
        base.SetData(inputData);
        //thumbnailKnight = data.Thumbnail;
        txtKnightName.text = data.NameKr;
    }
}

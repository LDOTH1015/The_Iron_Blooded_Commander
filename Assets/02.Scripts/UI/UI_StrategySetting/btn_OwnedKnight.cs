using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class btn_OwnedKnight : UIContent<KnightDefault>
{
    [SerializeField] UI_StrategySetting uIStrategySetting;

    [SerializeField] private Image thumbnailKnight;
    [SerializeField] private TMP_Text txtKnightName;

    protected override void Awake()
    {
        base.Awake();
        
    }

    public void OnClickBtn()
    {
        uIStrategySetting.OnClickBtnKnight(data);
    }

    public override void SetData(KnightDefault inputData)
    {
        base.SetData(inputData);
        //thumbnailKnight = data.Thumbnail;
        txtKnightName.text = data.NameKr;
    }
}

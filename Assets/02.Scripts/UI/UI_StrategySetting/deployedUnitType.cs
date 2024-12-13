using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class deployedUnitType : UIContent<UnitType>
{
    [SerializeField] private Image thumbnailUnitType;
    [SerializeField] private TMP_Text txtUnitTypeName;
    [SerializeField] private TMP_Text txtUnitTypeCount;
    [SerializeField] private TMP_Text txtUnitTypeTrainingLevel;
    [SerializeField] private TMP_Text txtUnitTypeExperience;


    public override void SetData(UnitType inputData)
    {
        base.SetData(inputData);
        //thumbnailUnitType = data.Thumbnail;
        txtUnitTypeName.text = data.NameKr;
        txtUnitTypeCount.text = data.UnitTypeCount.ToString();
        txtUnitTypeTrainingLevel.text = $"훈련도: {data.TrainingLevel}";
        txtUnitTypeExperience.text = $"경험: {data.Experience}";
    }
}
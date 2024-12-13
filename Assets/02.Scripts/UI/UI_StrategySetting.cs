using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StrategySetting : MonoBehaviour
{
    [SerializeField] private GameObject mapInspectionCamera;
    [SerializeField] private GameObject strategySettingCamera;
    [SerializeField] private GameObject uiMapInspection;
    [SerializeField] private GameObject uiStrategySetting;

    [SerializeField] private GameObject uiPopupBattleStart;

    Camera cameraMapInspectionCamera;

    [SerializeField] scrollView_OwnedKnights scrollViewOwnedKnights;
    [SerializeField] scrollView_DeployedKnights scrollViewDeployedKnights;
    UI_PopupKnightInfo uiPopupKnightInfo;
    [SerializeField] scrollView_DeployedUnitTypes scrollViewDeployedUnitTypes;



    private void Start()
    {
        cameraMapInspectionCamera = mapInspectionCamera.GetComponent<Camera>();
    }

    public void OnClickBattleStart()
    {
        uiPopupBattleStart.SetActive(true);
        //UIManager.Instance.Show<UI_PopupBattleStart>();
    }

    public void OnClickReturnToMapInspection()
    {
        mapInspectionCamera.SetActive(true);
        strategySettingCamera.SetActive(false);
        uiMapInspection.SetActive(true);
        uiStrategySetting.SetActive(false);
        DragAndDropManager.Instance.SetWorldDragCamera(cameraMapInspectionCamera);
    }

    public void SetOwnedKnightData(List<KnightDefault> knightDataLists)
    {
        scrollViewOwnedKnights.SetScrollView(knightDataLists);
    }
    public void SetDeployedKnightData(List<KnightDefault> knightDataLists)
    {
        scrollViewDeployedKnights.SetScrollView(knightDataLists);
    }
    public void SetDeployedUnitTypeData(List<UnitType> unitTypeDataLists)
    {
        scrollViewDeployedUnitTypes.SetScrollView(unitTypeDataLists);
    }

    public void OnClickBtnKnight(KnightDefault knightData)
    {
        uiPopupKnightInfo = UIManager.Instance.Show<UI_PopupKnightInfo>();
        uiPopupKnightInfo.SetKnightInfoData(knightData);
    }
}

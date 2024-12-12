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
}

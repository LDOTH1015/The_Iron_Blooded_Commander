using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MapInspection : MonoBehaviour
{
    [SerializeField] private GameObject mapInspectionCamera;
    [SerializeField] private GameObject strategySettingCamera;
    [SerializeField] private GameObject uiMapInspection;
    [SerializeField] private GameObject uiStrategySetting;

    [SerializeField] private GameObject uiPopupBattleStart;

    public void OnClickBattleStart()
    {
        uiPopupBattleStart.SetActive(true);
        //UIManager.Instance.Show<UI_PopupBattleStart>();
    }

    public void OnClickStrategySetting()
    {
        strategySettingCamera.SetActive(true);
        mapInspectionCamera.SetActive(false);
        uiStrategySetting.SetActive(true);
        uiMapInspection.SetActive(false);
    }

}

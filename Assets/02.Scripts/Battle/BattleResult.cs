using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleResult : MonoBehaviour
{
    // 배틀 결과 화면 출력
    public GameObject enemyResultPrefab;
    public Transform enemyContentParent;
    public GameObject rewordResultPrefab;
    public Transform rewordContentParent;

    private List<GameObject> activeUIObjects = new List<GameObject>();

    //for문을 사용하여 몬스터 데이터와 보상 데이터를 미리 화면에 생성
    public void CreateUI(List<EnemyData> enemyDatas)
    {
        ClearUI();
        foreach (var monsterData in enemyDatas)
        {
            GameObject resultItem = Instantiate(enemyResultPrefab, enemyContentParent);
            activeUIObjects.Add(resultItem);
            Image iconImage = resultItem.transform.Find("Icon").GetComponent<Image>();
            Text nameText = resultItem.transform.Find("Name").GetComponent<Text>();
            //아이콘 이미지 변경 코드
            nameText.text = monsterData.Name + " * " + monsterData.Num;
        }
    }

    //몬스터 데이터와 동일하게 for 문을 통하여 데이터를 화면에 띄우며 Domain데이터에 보상 값 추가
    public void ShowReword(int StageID)
    {
        ClearUI();


        foreach (var rewardData in LocatorManager.Instance.dataManager.rewardInfo.Data.KnightDataTable)
        {
            GameObject resultItem = Instantiate(rewordResultPrefab, rewordContentParent);
            activeUIObjects.Add(resultItem); // 생성된 오브젝트를 리스트에 추가

            // UI 요소 설정
            Image iconImage = resultItem.transform.Find("Icon").GetComponent<Image>();
            Text nameText = resultItem.transform.Find("Name").GetComponent<Text>();

            nameText.text = rewardData.ItemType + " x " + rewardData.RewardNum;
        }
    }

    public void ShowMain()
    {
        ClearUI();
        //메인씬으로 가는 코드
    }

    private void ClearUI()
    {
        foreach (var uiObject in activeUIObjects)
        {
            Destroy(uiObject);
        }

        activeUIObjects.Clear();
    }
}

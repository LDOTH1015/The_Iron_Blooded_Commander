using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleResult : MonoBehaviour
{
    // ��Ʋ ��� ȭ�� ���
    public GameObject enemyResultPrefab;
    public Transform enemyContentParent;
    public GameObject rewordResultPrefab;
    public Transform rewordContentParent;

    private List<GameObject> activeUIObjects = new List<GameObject>();

    //for���� ����Ͽ� ���� �����Ϳ� ���� �����͸� �̸� ȭ�鿡 ����
    public void CreateUI(List<EnemyData> enemyDatas)
    {
        ClearUI();
        foreach (var monsterData in enemyDatas)
        {
            GameObject resultItem = Instantiate(enemyResultPrefab, enemyContentParent);
            activeUIObjects.Add(resultItem);
            Image iconImage = resultItem.transform.Find("Icon").GetComponent<Image>();
            Text nameText = resultItem.transform.Find("Name").GetComponent<Text>();
            //������ �̹��� ���� �ڵ�
            nameText.text = monsterData.Name + " * " + monsterData.Num;
        }
    }

    //���� �����Ϳ� �����ϰ� for ���� ���Ͽ� �����͸� ȭ�鿡 ���� Domain�����Ϳ� ���� �� �߰�
    public void ShowReword(int StageID)
    {
        ClearUI();

        /*
        foreach (var rewardData in LocatorManager.Instance.dataManager.rewardInfo.Data.KnightDataTable)
        {
            GameObject resultItem = Instantiate(rewordResultPrefab, rewordContentParent);
            activeUIObjects.Add(resultItem); // ������ ������Ʈ�� ����Ʈ�� �߰�

            // UI ��� ����
            Image iconImage = resultItem.transform.Find("Icon").GetComponent<Image>();
            Text nameText = resultItem.transform.Find("Name").GetComponent<Text>();

            nameText.text = rewardData.ItemType + " x " + rewardData.RewardNum;
        }
        */
    }

    public void ShowMain()
    {
        ClearUI();
        //���ξ����� ���� �ڵ�
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

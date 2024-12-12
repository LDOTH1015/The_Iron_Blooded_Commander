using System.Collections.Generic;
using UnityEngine;

public abstract class UIScrollView<T> : MonoBehaviour where T : IData
{
    protected List<T> dataList;

    [SerializeField] protected Transform uiContentParent;
    [SerializeField] protected UIContent<T> uiContentPrefab;

    // 생성된 UIContent 인스턴스 목록 (Pooling): +생성된 UIContent제어
    private List<UIContent<T>> uiContentPool = new List<UIContent<T>>();

    /// <summary>
    /// ScrollView를 설정합니다.
    /// </summary>
    public void SetScrollView(List<T> newDataList)
    {
        // 데이터 리스트 업데이트
        dataList = newDataList;

        // 기존 UIContent 재사용 또는 초기화
        for (int i = 0; i < dataList.Count; i++)
        {
            UIContent<T> uiContent;

            // Pool에 이미 생성된 UIContent가 있으면 재사용
            if (i < uiContentPool.Count)
            {
                uiContent = uiContentPool[i];
                uiContent.gameObject.SetActive(true); // 활성화
            }
            else
            {
                // Pool에 없는 경우 새로 생성
                uiContent = Instantiate(uiContentPrefab, uiContentParent);
                uiContentPool.Add(uiContent);
            }

            // 데이터 설정
            uiContent.SetData(dataList[i]);
        }

        // 사용되지 않는 Pool 객체 비활성화
        for (int i = dataList.Count; i < uiContentPool.Count; i++)
        {
            uiContentPool[i].gameObject.SetActive(false); // 비활성화
        }
    }

    /// <summary>
    /// ScrollView를 초기화하여 모든 데이터를 제거합니다.
    /// </summary>
    public void ClearScrollView()
    {
        // Pool에 있는 모든 UIContent 비활성화
        foreach (var uiContent in uiContentPool)
        {
            uiContent.gameObject.SetActive(false);
        }

        // 데이터 리스트 초기화
        dataList.Clear();
    }

}
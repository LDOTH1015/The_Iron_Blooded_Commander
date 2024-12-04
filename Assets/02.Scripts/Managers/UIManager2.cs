using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager2 : MonoSingleton<UIManager2>
{
    [SerializeField] private Canvas canvas; // 기본으로 사용할 메인 Canvas

    [Header("Canvas Scaler Size")]
    public static float screenWidth = 1980;
    public static float screenHeight = 1080;

    private List<UIBase> uiList = new List<UIBase>();

    private new void Awake()
    {
        if (canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
        }
    }

    public T Show<T>(string canvasType = "canvas") where T : UIBase
    {
        string uiName = typeof(T).ToString();
        if (uiList.Exists(ui => ui.name == uiName)) // 이미 소환되어 있으면 반환
        {
            return null;
        }
        UIBase prefab = Resources.Load<UIBase>("Prefabs/UI/" + uiName);
        var ui = Load<T>(prefab, uiName, canvasType);
        uiList.Add(ui);

        // 필요하면 실행 애니메이션 실행 bb

        return (T)ui;
    }

    private T Load<T>(UIBase prefab, string uiName, string canvasType) where T : UIBase
    {
        UIBase uiInstance = Instantiate(prefab);

        uiInstance.SetCanvasType(canvasType);

        uiInstance.name = uiName.Replace("(Clone)", "");

        return (T)uiInstance;
    }

    private void Hide<T>() where T : UIBase
    {
        string uiName = typeof(T).ToString();
        Hide(uiName);
    }

    public void Hide(string uiName)
    {
        UIBase uiToHide = uiList.Find(obj => obj.name == uiName);
        uiList.Remove(uiToHide);
        Destroy(uiToHide.gameObject); // 캔버스는 유지 하고 본인만 삭제
    }

    public void HideAndRotateScene(string uiName, string sceneName)
    {
        Hide(uiName);
        SceneManager.LoadScene(sceneName);
    }
}

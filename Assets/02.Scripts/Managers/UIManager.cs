using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Transform canvas;
    
    [Header("Canvas Scaler Size")]
    public static float screenWidth = 1980;
    public static float screenHeight = 1080;
    
    private List<UIBase> uiList = new List<UIBase>();
    
    public T Show<T>() where T : UIBase
    {
        string uiName = typeof(T).ToString();
        UIBase go = Resources.Load<UIBase>("Prefabs/UI/" + uiName);
        var ui = Load<T>(go, uiName);
        uiList.Add(ui);
        // 밑에 UI애니메이션을 추가할거면 아래와 같이 UIBase에 있는 기본 팝업애니메이션메서드를 실행
        // ui.PopUpAnimation();
        
        return (T)ui;
    }

    private T Load<T>(UIBase prefab, string uiName) where T : UIBase
    {
        GameObject _newCanvas = new GameObject($"{uiName}Canvas");
        
        // 아래는 새로운 캔버스를 생성한 뒤 컴포넌트들 붙이는 내용임. 만약 다른 설정을 원하는 UI 예외처리해줘야함.
        // 아마 전투관련 UI에 이런 것들에 대한 조정이 들어갈 것 같음
        var _canvas = _newCanvas.AddComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        
        var _canvasScaler = _newCanvas.AddComponent<CanvasScaler>();
        _canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        // 필드에 깔아둔게 여기서 쓰임. 캔버스 스케일러 기준 크기
        _canvasScaler.referenceResolution = new Vector2(screenWidth, screenHeight);
        // 아래는 해상도 변경 시 가로를 기준으로 할 것인가, 세로를 기준으로 할 것인가. 0에가까울수록 가로, 1에 가까울수록 세로
        // canvasScaler.matchWidthOrHeight = 0f;
        
        _newCanvas.AddComponent<GraphicRaycaster>();
        
        UIBase _ui = Instantiate(prefab, _newCanvas.transform);// 새로 생성한 캔버스의 자식으로 UI오브젝트 생성

        _ui.name = uiName.Replace("(Clone)", "");// Instantiate시 이름앞에 클론 붙는거 제거
        _ui.canvas = _canvas;
        _ui.canvas.sortingOrder = uiList.Count + 1; // UI가 생성되는 데 안 보이면 해당 코드에 +1 해주기 

        return (T)_ui; // 해당 UI의 형태로 형변환 반환타입 챙겨주는거 
    }

    private void Hide<T>() where T : UIBase
    {
        string _uiName = typeof(T).ToString();
        Hide(_uiName);
    }

    public void Hide(string uiName)
    {
        UIBase _go = uiList.Find(obj => obj.name == uiName);
        uiList.Remove(_go);
        Destroy(_go.canvas.gameObject); // 해당 캔버스와 같이 지워주기
    }

    // UI없애는 것과 씬전환이 동시에 실행될 경우 아래 메서드 사용
    // 따로 씬관리를 하지 않는다고 가정을하고 지금은 씬매니져로 넘김.
    // 만약 따로 씬관리를 한다면 해당 클래스를 통해서 씬전환 시도해야함.
    public void HideAndRotateScene(string uiName, string sceneName)
    {
        Hide(uiName);
        SceneManager.LoadScene(sceneName);
    }
    
    
}

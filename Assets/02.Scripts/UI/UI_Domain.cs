using UnityEngine;

public class UI_Domain : UIBase
{
    UIManager uiManager = UIManager.Instance;
    
    protected override void Awake()
    {
        base.Awake();
        InitializeDomainUI();
    }

    private void InitializeDomainUI()
    {
        // DomainScene초기화 -> 해당 씬의 모든 UI버튼들 불러오기
        uiManager.Show<UI_CastleButton>();
    }
}

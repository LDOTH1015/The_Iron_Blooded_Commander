using UnityEngine;

public class UIDomain : UIBase
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
        uiManager.Show<UICastleButton>();
    }
}

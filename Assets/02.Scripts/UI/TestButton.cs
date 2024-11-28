using UnityEngine;
using UnityEngine.UI;

public class TestButton : UIBase
{
    private Button testButton;

    protected override void Awake()
    {
        base.Awake();
        testButton = GetComponent<Button>();
        testButton.onClick.AddListener(Hide);
    }
}

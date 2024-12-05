
using UnityEngine.UI;

public class btn_TestNextTurn : UIBase
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        LocatorManager.Instance.turnManager.playerTurnState.Exit();
    }
}

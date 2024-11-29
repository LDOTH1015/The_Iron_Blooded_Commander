using UnityEngine;

public class ShowObject : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.Show<TestButton>();
    }
}

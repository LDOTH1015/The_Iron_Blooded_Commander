using UnityEngine;

// UI들은 UIBase를 상속받아야합니다.
// UI오브젝트 이름이랑 해당 오브젝트이 붙일 스크립트이름이랑 같아야합니다. 
public class UIBase : MonoBehaviour
{
    public Canvas canvas;

    protected virtual void Awake()
    {
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }
    }

    public virtual void Hide()
    {
        UIManager.Instance.Hide(gameObject.name);
    }

    public virtual void PopUpAnimation()
    {
        
    }

    public virtual void CloseAnimation()
    {
        
    }
}

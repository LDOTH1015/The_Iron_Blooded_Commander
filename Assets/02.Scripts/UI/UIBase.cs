using UnityEngine;

// UI들은 UIBase를 상속받아야합니다.
// UI오브젝트 이름이랑 해당 오브젝트이 붙일 스크립트이름이랑 같아야합니다. 
public class UIBase : MonoBehaviour
{
    public Canvas canvas;

    protected string canvasType = "canvas";
    public void SetCanvasType(string type)
    {
        canvasType = type;
    }

    protected virtual void Awake()
    {
        //Origin
        if (canvas == null)
        {
            canvas = GetComponent<Canvas>();
        }

        //if (canvas == null)
        //{
        //    canvas = UICanvasManager.Instance?.GetCanvas(canvasType);
        //}
        //
        //if (canvas != null)
        //{
        //    transform.SetParent(canvas.transform, false);
        //}
    }

    public virtual void Hide()
    {
        UIManager.Instance.Hide(gameObject.name);
        //UIManager2.Instance.Hide(gameObject.name);
    }

    public virtual void PopUpAnimation()
    {
        
    }

    public virtual void CloseAnimation()
    {
        
    }
}

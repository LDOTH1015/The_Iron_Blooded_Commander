using UnityEngine;

public class DraggableWorldObject : MonoBehaviour
{
    private void OnMouseDown()
    {
        DragAndDropManager.Instance.BeginWorldDrag(gameObject);
    }

    private void OnMouseDrag()
    {
        DragAndDropManager.Instance.Drag(null); // 이벤트 데이터가 필요 없음
    }

    private void OnMouseUp()
    {
        DragAndDropManager.Instance.EndDrag(null); // 이벤트 데이터가 필요 없음
    }
}
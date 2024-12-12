using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public DraggableContent draggableContent; // 연결된 콘텐츠 설정

    public void OnBeginDrag(PointerEventData eventData)
    {
        DragAndDropManager.Instance.BeginDrag(draggableContent, eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        DragAndDropManager.Instance.Drag(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragAndDropManager.Instance.EndDrag(eventData);
    }
}

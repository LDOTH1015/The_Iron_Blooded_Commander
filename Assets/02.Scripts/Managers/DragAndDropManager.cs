using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropManager : MonoSingleton<DragAndDropManager>
{

    private GameObject draggedObject; // 현재 드래그 중인 오브젝트
    private DraggableContent draggableContent; // UI에서 드래그된 콘텐츠
    private bool isDragging = false; // 드래그 상태
    private Canvas currentCanvas; // UI 캔버스
    private Camera mainCamera; // 월드 드래그를 위한 카메라
    public LayerMask groundLayer; // 바닥 지형에 사용할 LayerMask
    private Renderer draggedRenderer; // 드래그된 오브젝트의 Renderer

    private Color defaultColor = Color.white; // 기본 색상
    private Color validColor = Color.green;   // DropZone 안의 색상
    private Color invalidColor = Color.red;   // DropZone 밖의 색상

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // 월드 드래그를 위한 카메라 설정
    public void SetWorldDragCamera(Camera worldDragCamera)
    {
        mainCamera = worldDragCamera;
    }

    // 드래그 시작 (UI 콘텐츠)
    public void BeginDrag(DraggableContent content, PointerEventData eventData)
    {
        draggableContent = content;

        if (content.prefab == null)
        {
            Debug.LogError("드래그할 Prefab이 설정되지 않았습니다!");
            return;
        }

        currentCanvas = eventData.pointerPress?.GetComponentInParent<Canvas>();
        if (currentCanvas == null)
        {
            Debug.LogError("Canvas를 식별할 수 없습니다!");
            return;
        }

        // 드래그 미리보기 프리팹 생성
        draggedObject = Instantiate(content.prefab, GetWorldPosition(eventData), Quaternion.identity);
        draggedRenderer = draggedObject.GetComponent<Renderer>();

        if (draggedRenderer != null)
        {
            defaultColor = draggedRenderer.material.color; // 원래 색상 저장
            draggedRenderer.material.color = invalidColor; // 드래그 시작 시 빨간색
        }

        draggedObject.SetActive(true);
        isDragging = true;
    }

    // 드래그 시작 (월드 오브젝트)
    public void BeginWorldDrag(GameObject worldObject)
    {
        draggedObject = worldObject;
        draggedRenderer = draggedObject.GetComponent<Renderer>();
        isDragging = true;
    }

    // 드래그 중
    public void Drag(PointerEventData eventData)
    {
        if (!isDragging || draggedObject == null)
            return;

        if (draggableContent != null)
        {
            // UI → 월드 드래그
            // Drag동안 추가할 작업 있으면 추가
        }
        else
        {
            // 월드 → 월드 드래그
            // Drag동안 추가할 작업 있으면 추가
        }
        // drag동안 위치에 따라 DragZone감지 후 색 변화
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
        {
            draggedObject.transform.position = hitInfo.point;
            UpdateObjectColor(); // 드래그 중 색상 업데이트
        }
    }

    // 드래그 종료
    public void EndDrag(PointerEventData eventData)
    {
        if (!isDragging || draggedObject == null)
            return;

        if (draggableContent != null)
        {
            // UI → 월드 드래그 종료
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
            {
                if (hitInfo.collider.CompareTag("DropZone"))
                {
                    Debug.Log($"Dropped {draggedObject.name} in {hitInfo.collider.name}");
                    draggedObject.transform.position = hitInfo.point;
                    ResetObjectColor();
                }
                else
                {
                    Destroy(draggedObject); // 드롭 실패 시 제거
                    // TODO : 없어진 content가 원래 있던 ui로 돌아감
                }
            }
        }
        else
        {
            // 월드 → 월드 드래그 종료
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
            {
                if (hitInfo.collider.CompareTag("DropZone"))
                {
                    Debug.Log($"Dropped {draggedObject.name} at {hitInfo.point}");
                    ResetObjectColor();
                }
                else
                {
                    Destroy(draggedObject); // 드롭 실패 시 제거
                    // TODO : 없어진 content가 원래 있던 ui로 돌아감
                }
            }
        }

        draggedObject = null;
        draggableContent = null;
        isDragging = false;
    }

    // UI 좌표 → 월드 좌표 변환
    private Vector3 GetWorldPosition(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToWorldPointInRectangle(
            currentCanvas.GetComponent<RectTransform>(),
            eventData.position,
            mainCamera,
            out Vector3 worldPosition
        );
        return worldPosition;
    }

    // 지형에 따라 Y값 업데이트
    private void UpdateObjectPositionWithGround(Vector3 position)
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
        {
            position.y = hitInfo.point.y; // 지형 충돌 위치의 Y값으로 업데이트
        }
        draggedObject.transform.position = position;
    }
    // 드래그 중 색상 업데이트
    private void UpdateObjectColor()
    {
        if (draggedRenderer == null)
            return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, groundLayer))
        {
            if (hitInfo.collider.CompareTag("DropZone"))
            {
                draggedRenderer.material.color = validColor; // 초록색
            }
            else
            {
                draggedRenderer.material.color = invalidColor; // 빨간색
            }
        }
    }

    // 드래그 종료 시 색상 초기화
    private void ResetObjectColor()
    {
        if (draggedRenderer != null)
        {
            draggedRenderer.material.color = defaultColor; // 원래 색상으로 복구
        }
    }
}
using UnityEngine;

[CreateAssetMenu(menuName = "Draggable Content")]
public class DraggableContent : ScriptableObject
{
    public GameObject prefab; // 드래그 후 생성할 프리팹
    public string contentName; // 콘텐츠 이름
    public Sprite icon; // UI 아이콘
    public string additionalData; // 추가 데이터 (설명 등)
}
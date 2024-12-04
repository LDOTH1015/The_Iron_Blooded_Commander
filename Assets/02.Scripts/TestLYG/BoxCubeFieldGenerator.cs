using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCubeFieldGenerator : MonoBehaviour
{
    public GameObject cubePrefab; // 복사할 Cube 프리팹
    public int rows = 10; // 행 개수
    public int columns = 20; // 열 개수
    public float spacing = 1.0f; // Cube 간의 간격
    public Vector3 cubeScale = new Vector3(1, 1, 1); // Cube의 크기 (Scale)
    public float heightVariation = 0.0f; // 높이 변화량
    public Color cubeColor = Color.white; // 큐브 색상

    void Start()
    {
        GenerateField();
    }

    void GenerateField()
    {
        if (cubePrefab == null)
        {
            Debug.LogError("Cube Prefab is not assigned!");
            return;
        }

        // Spawner의 위치를 가져옵니다.
        Vector3 spawnerPosition = transform.position;

        // 필드의 중앙을 계산 (스포너 위치 기준)
        Vector3 centerOffset = new Vector3((columns - 1) * spacing / 2, 0, (rows - 1) * spacing / 2);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // 각 Cube의 위치
                Vector3 position = spawnerPosition + new Vector3(j * spacing, heightVariation, i * spacing) - centerOffset; // XZ 평면, 높이 heightVariation
                // Cube 생성
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity, transform);
                // Cube의 Scale 설정
                cube.transform.localScale = cubeScale;
                // Cube의 색상 설정
                Renderer renderer = cube.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material.color = cubeColor;
                }
            }
        }
    }
}

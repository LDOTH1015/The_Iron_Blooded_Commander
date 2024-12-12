using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class AIUnitStats
{
    public float detectionRange = 10f;
    public float retreatRange = 5f;
    public int initialHealth = 100;
    public float attackPower = 20f;
}

public class AIManager : MonoSingleton<AIManager>
{
    [SerializeField]
    private AIUnitStats unitStats;

    public Transform leaderUnit;

    public List<AIController> allAIUnits = new List<AIController>();


    public float detectionRange = 10f;
    public float retreatRange = 5f;
    public int initialHealth = 100;
    public float attackPower = 20f;

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        //InitializeAIUnits();
    }

    public void InitializeAIUnits()
    {
        for (int i = 0; i < 5; i++)
        {
            CreateDummyUnit(i);
            Debug.Log($"{i}");
        }
    }

    private void CreateDummyUnit(int index)
    {
        GameObject soldierPrefab = Resources.Load<GameObject>("Prefabs/Units/SoldierPrefab");

        if (soldierPrefab != null)
        {
            GameObject unitObject = Instantiate(soldierPrefab);
            AIController aiController = unitObject.GetComponent<AIController>();

            // 초기 데이터 설정
            aiController.Initialize(
                $"Unit_{index}", // 이름
                initialHealth,  // 체력
                attackPower     // 공격력
            );

            RegisterAIUnit(aiController);
        }
    }

    public void RegisterAIUnit(AIController unit)
    {
        if (!allAIUnits.Contains(unit))
        {
            allAIUnits.Add(unit);
        }
    }
    public void UnregisterAIUnit(AIController unit)
    {
        if (allAIUnits.Contains(unit))
        {
            allAIUnits.Remove(unit);
        }
    }

    public void CommandFollowLeader()
    {
        foreach (var unit in allAIUnits)
        {
            unit.SetState(AIController.AIState.FollowLeader);
        }
    }
}

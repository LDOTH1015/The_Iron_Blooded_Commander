using UnityEngine;

public class AIController : MonoBehaviour
{
    public enum AIState { Idle, FollowLeader, EngageEnemy, Retreat, Hit, Death }
    private AIState currentState;

    public string unitName; // 유닛 이름
    public int health;      // 체력
    public float attackPower; // 공격력
    private void Start()
    {
        AIManager.Instance.RegisterAIUnit(this);
    }

    private void OnDestroy()
    {
        AIManager.Instance.UnregisterAIUnit(this);
    }

    public void Initialize(string name, int initialHealth, float attack)
    {
        unitName = name;
        health = initialHealth;
        attackPower = attack;
    }

    public void SetState(AIState newState)
    {
        currentState = newState;
    }
}

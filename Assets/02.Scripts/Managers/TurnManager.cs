
using System.Collections;
using UnityEngine;

public class TurnManager : IManager
{
    public PlayerTurnState playerTurnState;
    public AITurnState aiTurnState;
    public WorldTurnState worldTurnState;
    public BattleTurnState battleTurnState;

    private ITurnState currentTurnState;
    private ITurnState previousTurnState;
    private ITurnState nextTurnState;
    
    private WaitForSeconds waitForSeconds = new WaitForSeconds(0.5f);

    public TurnManager()
    {
        playerTurnState = new PlayerTurnState();
        aiTurnState = new AITurnState();
        worldTurnState = new WorldTurnState();
        battleTurnState = new BattleTurnState();
    }
    
    public void Initialize()
    {
        InitTurn(playerTurnState);
    }

    private void InitTurn(ITurnState currentTurn)
    {
        if (currentTurnState == null)
        {
            currentTurnState = currentTurn;
        }
        currentTurnState = currentTurn;
        
        currentTurnState.Enter();
        LocatorManager.Instance.StartCoroutine(ExecuteTurnWithDelay(currentTurn));
    }

    private IEnumerator ExecuteTurnWithDelay(ITurnState currentTurn)
    {
        yield return waitForSeconds;
        ExecuteTurn(currentTurn);
    }
    
    private void ExecuteTurn(ITurnState currentTurn)
    {
        if (currentTurnState == currentTurn)
        {
            currentTurn.Execute();
        }
    }
    
    public void TransitionTo(ITurnState nextTurn)
    {
        nextTurnState = nextTurn;
        //현재 턴이 플레이어 턴일 경우 배틀이벤트 존재 확인 여부 후 nextTurn을 배틀로 갈지 말지 결정
        InitTurn(nextTurn);
    }
}

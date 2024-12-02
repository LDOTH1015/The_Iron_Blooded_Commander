
public class TurnManager : IManager
{
    PlayerTurnState playerTurnState;
    AITurnState aiTurnState;
    WorldTurnState worldTurnState;
    BattleTurnState battleTurnState;

    private ITurnState currentTurnState;
    private ITurnState previousTurnState;
    private ITurnState nextTurnState;
    
    
    public void Initialize()
    {
        playerTurnState = new PlayerTurnState();
        aiTurnState = new AITurnState();
        worldTurnState = new WorldTurnState();
        battleTurnState = new BattleTurnState();
        
        InitTurn(playerTurnState);
    }

    private void InitTurn(ITurnState currentTurn)
    {
        if (currentTurnState != null)
        {
            previousTurnState = currentTurnState;
        }
        currentTurnState = currentTurn;
        currentTurnState.Enter();
        ExecuteTurn(currentTurnState);
    }

    private void ExecuteTurn(ITurnState currentTurn)
    {
        if (currentTurnState == currentTurn)
        {
            currentTurn.Execute();
        }
        else
        {
            InitTurn(currentTurn);
        }
    }
    
    public void TransitionTo(ITurnState nextTurn)
    {
        nextTurnState = nextTurn;
        currentTurnState.Exit();
        
        //배틀이벤트 존재 확인 여부 후 nextTurn을 배틀로 갈지 말지 결정
        InitTurn(nextTurn);
    }
}

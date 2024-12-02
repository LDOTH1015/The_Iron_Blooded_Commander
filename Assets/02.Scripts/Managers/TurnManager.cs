
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
    
    private void TransitionTo(ITurnState nextTurn)
    {
        nextTurnState = nextTurn;
        currentTurnState.Exit();
        InitTurn(nextTurn);
    }
}

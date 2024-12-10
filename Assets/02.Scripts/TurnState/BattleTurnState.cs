using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleTurnState : ITurnState
{
    // 씬전환이 이뤄져야함 UIManager의 HideAndTransition
    public void Enter()
    {
        //씬전환
        SceneManager.LoadScene("Test_BattleForTurn");
        //일단 시간정지
        Time.timeScale = 0.0f;
    }

    // 뭐 할게 있나?
    public void Execute()
    {
        // 현재내용없음
    }
    
    public void Exit()
    {
        // TransitionToPlayerTurn 다시 플레이어턴에 가야하고 IsNextTurnBattle false로 돌려야함
        LocatorManager.Instance.turnManager.playerTurnState.isNextTurnBattle = false;
        LocatorManager.Instance.StartCoroutine(WaitForSceneTransition());
        UIManager.Instance.Show<pnl_Loading>();
        LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.playerTurnState);
    }

    private IEnumerator WaitForSceneTransition()
    {
        SceneManager.LoadScene("Test_SOLS");
        yield return new WaitForSeconds(3.0f);
    }
}

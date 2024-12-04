using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITurnState : ITurnState
{
    
    // 1. AI재화상태 업데이트
    public void Enter()
    {
        AIDomainStateUpdate();
        // 디버그는 ai영지상태 업데이트 체크용
        Debug.Log($"{LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[1].Gold}");
        Debug.Log($"{LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[2].Gold}");
        Debug.Log($"{LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[3].Gold}");
    }
    
    // AI상태와 플레이어 상태 비교 후 침략여부 결정 -> 결정 후 타임매니저 이벤트타임라인에 추가
    // 직전에 플레이어를 침공했다면 침략여부결정 때 확률을 확 낮출 수 있는 변수 필요
    public void Execute()
    {
        ConsiderToAttackPlayer();
    }
    
    // TransitionToWorldTurn
    public void Exit()
    {
        throw new System.NotImplementedException();
    }
    
    private void AIDomainStateUpdate()
    {
        DomainArray _aiDomainTable = LocatorManager.Instance.dataManager.domainInfo.Data;
        for (int i = 1; i < _aiDomainTable.DomainDataTable.Count; i++)
        {
            // 식량
            _aiDomainTable.DomainDataTable[i].Food += Random.Range(-100, 100);
            _aiDomainTable.DomainDataTable[i].Gold += Random.Range(-100, 100);
            _aiDomainTable.DomainDataTable[i].Population += Random.Range(-50, 50);
            _aiDomainTable.DomainDataTable[i].Steel += Random.Range(-50, 50);
            _aiDomainTable.DomainDataTable[i].Fame += Random.Range(-10, 10);
        }
    }
    
    private void ConsiderToAttackPlayer()
    {
        // 비교 후 침공결정 ->이벤트 두개 연달아 등록
        
        // 비교 후 아니다->Exit()실행
    }


}

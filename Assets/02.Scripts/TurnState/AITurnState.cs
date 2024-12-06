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
        Exit();
    }
    
    // TransitionToWorldTurn
    public void Exit()
    {
        // Exit()실행 후 월드턴으로 턴넘김
        LocatorManager.Instance.turnManager.TransitionTo(LocatorManager.Instance.turnManager.worldTurnState);
    }
    
    private void AIDomainStateUpdate()
    {
        for (int i = 1; i < LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable.Count; i++)
        {
            LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[i].Food += Random.Range(-100, 100);
            LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[i].Gold += Random.Range(-100, 100);
            LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[i].Population += Random.Range(-50, 50);
            LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[i].Steel += Random.Range(-50, 50);
            LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[i].Fame += Random.Range(-10, 10);
        }
    }
    
    private void ConsiderToAttackPlayer()
    {
        // 비교 후 침공을 결정함 ->(만약 침공을 결정했다면)이벤트 두개 연달아 등록 (침공을 결정한 ai의 DomainID를 ResultValue)
        // 1. 플레이어와 ai영지의 명성을 비교합니다. → 플레이어 영지의 명성이 더 높다면 가중치부여(그 명성은 내것이 되어야하니까) 
        // 2. 플레이어와 ai영지의 골드를 비교합니다. → 플레이어 영지의 명성이 더 높다면 가중치부여(돈이 많으면 뺏고싶으니까)
        // 3. 플레이어와 ai영지의 병력수를 비교합니다. → ai영지의 병력수가 플레이어 영지의 병력수의 70%이상이면 가중치부여 (해볼만하니까)
        // 4. 플레이어의 명성이 플레이어를 제외한 모든 영지들의 평균보다 낮다면 가중치 부여 (민심이 박았네? 뺏어도 할 말 없네? 왜냐면 인민은 날 더 좋아해)
        // 5. 가중치확률Random.Range(0, 0.4)매직넘버이긴한데 가중치도 좀 랜덤하게 줄 생각입니다.
        // 6. 가중치가 1을 넘으면 주사위굴리기 → Random.Range(0.4, 1) 돌려서 값이 0.5를 넘어가면 침략결정!
        // 7. 영주의 전쟁민감도→아주 좋은 아이디어
        // 8. 침략이 결정이 되면 이벤트 두개 연속등록(경고이벤트와 실제침공이벤트)

        for (int i = 1; i < LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable.Count; i++)
        {
            // 가중치(이게 1.0을 넘어가면 침략결정 주사위굴림)
            float _weightFactor = 1.0f;
            // 결정팩터(이게 0.5를 넘어가면 침략함)
            float? _decisionFactor = null;
            
            // 현재 가중치 비교로직은 미구현
            
            // 6. 가중치가 1을 넘으면 주사위굴리기 → Random.Range(0.4, 1) 돌려서 값이 0.5를 넘어가면 침략결정!
            if (_weightFactor >= 1.0f)
            {
                _decisionFactor = Random.Range(0.4f, 1.0f);
                
                // 8. 침략이 결정이 되면 이벤트 두개 연속등록(경고이벤트와 실제침공이벤트)
                if (_decisionFactor >= 0.5f)
                {
                    LocatorManager.Instance.timeManager.AddEventToTimeline(4500);
                    LocatorManager.Instance.timeManager.AddEventToTimeline(4501);
                    Debug.Log($"{LocatorManager.Instance.dataManager.domainInfo.Data.DomainDataTable[i].Name}가 침략이벤트 리스트에 넣엇음");
                }
            }
        }
    }


}

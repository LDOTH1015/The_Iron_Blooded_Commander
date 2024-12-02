using System.Collections;
using UnityEngine;

public interface ITurnState
{
    // 처음 진입할 때 실행됨. UI의 변경같은걸 표현하면 될듯.
    // 플레이어 턴 진입 시
    // -> 1. 타임매니저로부터 현재시간 받아와서 현재시간 UI업데이트.
    // 2. 타임매니저로부터 종료되는 이벤트 받아와서 재화상태업데이트, 완료UI팝업
    // 3. 타임매니저로부터 다음이벤트가 배틀이면 IsNextTurnBattle true업데이트해줘야함
    
    // AI턴 진입 시
    // 1. AI재화상태 업데이트
    // 2. AI상태와 플레이어 상태 비교 후 
    public void Enter();
    
    // 각 상태의 실행 중 로직 적는 곳
    // PlayerTurn => 가장 최근 이벤트종료 시점. 이벤트 발생하면 해당 이벤트를 이벤트 매니저에 전달
    // AITurn => AI가 가진 현재 재화상태 업데이트, 플레이어와 재화, 병사상태 비교후 침공 결정
    // WorldTurn => 고정이벤트 확률계산 후 이벤트 매니저에 전달.
    public void Execute(); 
    
    // BattleTurn으로 전환이 일어날때는 씬전환이 일어날 것을 염두.
    // PlayerTurn일 때, IsNextTurnBattle 여부 확인-> true면 BattleTurnState false면AITurnState로 Transition
    public void Exit(); 
}

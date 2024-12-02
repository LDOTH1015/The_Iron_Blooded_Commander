using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public interface IManager
{
    // LocatorManager를 제외한 각 매니저들은 IManager를 상속받아야함
    public void Initialize();
}

public class LocatorManager : MonoSingleton<LocatorManager>
{
    DataManager dataManager = new DataManager();
    TurnManager turnManager = new TurnManager();
    BattleManager battleManager = new BattleManager();
    SoundManager soundManager = new SoundManager();
    
    public override void Awake()
    {
        base.Awake();
        
        // 여기서 각 매니저들 초기화 순서 관리가능
        // dataManager.Initialize();
        // soundManager.Initialize();
        // turnManager.Initialize();
        // battleManager.Initialize();
    }
    
    // 각 매니저들은 MonoBehaviour를 상속받고있지 않으므로 MonoBehaviour에 관한 함수들은 
    // 로케이터매니저에서 대신 만든다음 로케이터를 통해 실행해줘야함.
    // 아래의 StartCoRoutines함수가 예시임. 
    // 다른매니저에서 코루틴 사용은 LocaterManager.Instance.StartCoRoutines(사용할코루틴);
    
    // StartCoroutine과 구별하기위해 이름을 살짝 바꿈.
    public void StartCoRoutines(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
    
}

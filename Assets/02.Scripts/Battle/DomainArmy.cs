using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 군 전체 정보
public class DomainArmy : MonoBehaviour
{
    // 기사리스트
    // 병종리스트
    // 전략리스트
    // 부대임무리스트

    // 전략 세팅 시스템

}
// 기사
public class Knight : MonoBehaviour
{
    // KnightDataTable 기사 정보

}
// 병종
public class UnitType : MonoBehaviour
{
    // UnitTypeDataTable 병종 정보

}
// 전략
public class Strategy : MonoBehaviour
{
    // 전략 데이터 테이블

}
// 전략 설정 시스템
public class StrategySettingSystem : MonoBehaviour
{
    // 전략리스트 
    // 부대임무리스트

    // UI의 반응과 연계하여 전략 설정 및 저장
}
// 부대
public class UnitDivision : MonoBehaviour
{
    // UnitDivisionDataTable 부대 정보
    // UnitDivisionRoleDataTable 부대 임무 정보
}
// 부대 배치
public class UnitDivisionPosition : MonoBehaviour
{
    // 부대 배치 데이터 테이블 - 부대(UnitDivision), 위치(Position), 회전(Rotation)

    // 부대의 병종과 수, 위치, 방향에 맞게 병사와 기사를 필드에 생성해주는 로직
}
// 병사
public class Soldier : MonoBehaviour
{
    // 부대의 UnitType의 데이터를 참조해서, 병사들이 전투중에 행동하는 로직에 사용

}
using UnityEngine;
// 전략
public class ArmyStrategy : MonoBehaviour
{
    // 전략 정보
    Strategy strategyData;

    public Strategy StrategyData
    {
        get { return strategyData; }
        private set { strategyData = value; }
    }

    public void SetStrategyData(Strategy inputStrategyData)
    {
        strategyData = inputStrategyData;
    }
}

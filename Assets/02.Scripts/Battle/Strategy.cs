using UnityEngine;
// 전략
public class Strategy : MonoBehaviour
{
    // 전략 정보
    StrategyDataTable strategyData;

    public StrategyDataTable StrategyData
    {
        get { return strategyData; }
        private set { strategyData = value; }
    }

    public void SetStrategyData(StrategyDataTable inputStrategyData)
    {
        strategyData = inputStrategyData;
    }
}

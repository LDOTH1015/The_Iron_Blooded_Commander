using UnityEngine;

public class ArmyLord : MonoBehaviour
{
    Lord lordData;

    public Lord LordData
    {
        get { return lordData; }
        private set { lordData = value; }
    }

    public void SetLordData(Lord inputLordData)
    {
        lordData = inputLordData;
    }
}
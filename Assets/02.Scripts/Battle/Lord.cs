using UnityEngine;

public class Lord : MonoBehaviour
{
    LordDataTable lordData;

    public LordDataTable LordData
    {
        get { return lordData; }
        private set { lordData = value; }
    }

    public void SetLordData(LordDataTable inputLordData)
    {
        lordData = inputLordData;
    }
}
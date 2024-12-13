using UnityEngine;

public abstract class UIContent<T> : MonoBehaviour where T : IData
{
    protected string dataID;

    protected T data;

    // 상속받는 content에서 override해서
    // content의 ui들에 데이터 삽입해서 사용
    public virtual void SetData(T inputData)
    {
        data = inputData;
        dataID = data.ID;
    }
}

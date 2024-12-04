using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TestUICreate : MonoBehaviour
{
    public string uiName;

    // Start is called before the first frame update
    void Start()
    {
        UIBase go = Resources.Load<UIBase>("Prefabs/UI/" + uiName);

        UIBase _ui = Instantiate(go);// 새로 생성한 캔버스의 자식으로 UI오브젝트 생성

        _ui.name = uiName.Replace("(Clone)", "");// Instantiate시 이름앞에 클론 붙는거 제거
        //_ui.canvas = _canvas;
        //_ui.canvas.sortingOrder = uiList.Count; // UI가 생성되는 데 안 보이면 해당 코드에 +1 해주기 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

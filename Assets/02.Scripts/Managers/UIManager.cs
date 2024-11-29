using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Transform canvas;
    
    [Header("Canvas Scaler Size")]
    public static float screenWidth;
    public static float screenHeight;
    
    private List<UIBase> uiList = new List<UIBase>();
    
    // public T Show<T>() where T : UIBase
    // {
    //     
    //     return (T)ui;
    // }
}

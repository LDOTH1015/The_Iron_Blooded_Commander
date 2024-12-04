using System.Collections.Generic;
using UnityEngine;

public class UICanvasManager : MonoBehaviour
{
    public static UICanvasManager Instance { get; private set; }

    [SerializeField] private Canvas canvas;
    [SerializeField] private Canvas canvasForCameraMoving;

    private Dictionary<string, Canvas> canvasDictionary;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (canvas == null)
        {
            canvas = FindObjectOfType<Canvas>();
        }

        canvasDictionary = new Dictionary<string, Canvas>
        {
            { "canvas", canvas },
            { "canvasForCameraMoving", canvasForCameraMoving }
        };
    }
    public Canvas GetCanvas(string canvasType)
    {
        if (canvasDictionary.TryGetValue(canvasType, out var canvas))
        {
            return canvas;
        }

        return null;
    }
}
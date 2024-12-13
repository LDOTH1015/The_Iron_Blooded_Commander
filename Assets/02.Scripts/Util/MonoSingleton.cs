using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static bool isApplicationQuitting = false;

    public static T Instance
    {
        get
        {
            if (isApplicationQuitting)
            {
                return null;
            }
            
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();

                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }

    public virtual void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log($"{typeof(T).Name} instance created.");
        }
        else
        {
            Debug.LogWarning($"{typeof(T).Name} instance already exists. Destroying duplicate.");
            Destroy(this.gameObject);
        }
    }

    private void OnApplicationQuit()
    {
        isApplicationQuitting = true;
    }
}

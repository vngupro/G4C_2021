using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSave : MonoBehaviour
{
    private static CanvasSave _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }
}

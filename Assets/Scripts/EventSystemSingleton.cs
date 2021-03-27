using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystemSingleton : MonoBehaviour
{
    private static EventSystemSingleton _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

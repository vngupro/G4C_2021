using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    private MaskSlot[] realSlot = new MaskSlot[3];
    private MaskSlot[] fakeSlot = new MaskSlot[3];

    private static Mask _instance;
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

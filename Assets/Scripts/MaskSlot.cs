using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSlot : MonoBehaviour
{
    public Attribute attribute;
    public Badge badge;
    public bool hasBadge = false;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if(hasBadge)
        {
            Debug.Log("Apply Badge");

        }
        else
        {
            Debug.Log("Do not Apply Badge");
        }
    }
}

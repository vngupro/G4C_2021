using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeSlot : MonoBehaviour
{
    public Badge badge;
    public bool hasBadge = false;
    public Vector2 originPos;

    private void Start()
    {
        originPos = transform.position; 
    }
}

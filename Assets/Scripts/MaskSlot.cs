using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSlot : MonoBehaviour
{
    public Attribute attribute { get; set; }

    public bool hasItemInHand = false;
    private void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && hasItemInHand)
        {
            RaycastHit2D hasClickOnSlot = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("UI"));
            if (hasClickOnSlot)
            {
                Debug.Log("mouse click in mask slot");
            }
        }
    }
}

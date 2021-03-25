using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public int maxCourage = 100;
    public int currentCourage;

    public CourageBar couragebar;
    // Start is called before the first frame update
    void Start()
    {
        currentCourage = maxCourage;
        couragebar.SetMaxCourage(maxCourage);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            TakeDammage(20);
        }
    }

    void TakeDammage (int damage) 
    {
        currentCourage -= damage;

        couragebar.SetCourage(currentCourage);
    }
}

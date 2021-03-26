using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageBar: MonoBehaviour
{
    public float maxCourage = 100.0f;
    public float startCourage = 80.0f;
    public float currentCourage;
    public CourageBarUI couragebar;

    private void Awake()
    {
        //NPC.cs
        LevelEvent.onNoMask.AddListener(TakeDamage);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCourage = startCourage;
        couragebar.SetMaxCourage(maxCourage);
        couragebar.SetCourage(currentCourage);
    }

    void TakeDamage (float damage) 
    {
        currentCourage += damage;
        couragebar.SetCourage(currentCourage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourageBar: MonoBehaviour
{
    public float maxCourage = 100;
    public float currentCourage;
    public CourageBarUI couragebar;

    private void Awake()
    {
        LevelEvent.onNoMask.AddListener(TakeDamage);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentCourage = maxCourage;
        couragebar.SetMaxCourage(maxCourage);
    }

    void TakeDamage (float damage) 
    {
        currentCourage += damage;
        couragebar.SetCourage(currentCourage);
    }
}

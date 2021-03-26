using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using System;

public class CourageBar: MonoBehaviour
{
    public float maxCourage = 100.0f;
    public float startCourage = 80.0f;
    public float currentCourage;
    public CourageBarUI couragebar;
    public Image redScreen;
    public Image greenScreen;
    public float fadeScreenFactor = 0.1f;

    private CinemachineImpulseSource source;

    private void Awake()
    {
        //NPC.cs
        LevelEvent.onNoMask.AddListener(TakeDamage);
        LevelEvent.onCollide.AddListener(TakeDamage);

        //sceneloader.cs
        LevelEvent.onGetToLastScene.AddListener(ChangeSceneCost);
        source = GetComponent<CinemachineImpulseSource>();
    }

    private void ChangeSceneCost()
    {
        currentCourage -= 20;
        couragebar.SetCourage(currentCourage);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCourage = startCourage;
        couragebar.SetMaxCourage(maxCourage);
        couragebar.SetCourage(currentCourage);

        greenScreen.enabled = false;
        redScreen.enabled = false;
    }

    void Update()
    {
        if (redScreen.enabled)
        {
            Color color = redScreen.color;
            color.a -= fadeScreenFactor;
            if(color.a <= 0f)
            {
                redScreen.enabled = false;
            }
        }

        if (greenScreen.enabled)
        {
            Color color = greenScreen.color;
            color.a -= fadeScreenFactor;

            if (color.a <= 0f)
            {
                greenScreen.enabled = false;
            }
        }
    }
    void TakeDamage(float damage)
    {
        currentCourage += damage;
        couragebar.SetCourage(currentCourage);
        if(damage < 0f)
        {
            source.GenerateImpulse();
            redScreen.enabled = true;
            FindObjectOfType<SoundManager>().PlaySound("Damage");

        }
        else
        {
            greenScreen.enabled = true;
            FindObjectOfType<SoundManager>().PlaySound("Heal");
            Debug.Log("Heal");
        }
        
        if(currentCourage <= 0f)
        {
            //sceneLoader.cs
            LevelEvent.onDefeat.Invoke();
        }

        if(currentCourage >= maxCourage)
        {
            currentCourage = maxCourage;
            //sceneLoader.cs
            LevelEvent.gotMaxCourage.Invoke();
        }
    }
}

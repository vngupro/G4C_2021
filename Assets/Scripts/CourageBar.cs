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
    public CanvasGroup redScreen;
    public CanvasGroup greenScreen;
    public float fadeScreenFactor = 0.1f;
    private bool mFaded = false;
    public float duration = 0.4f;

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


    // Start is called before the first frame update
    void Start()
    {
        ResetParameters();
    }
    public void ResetParameters()
    {
        currentCourage = startCourage;
        couragebar.SetMaxCourage(maxCourage);
        couragebar.SetCourage(currentCourage);
        redScreen.alpha = 0f;
        greenScreen.alpha = 0f;
    }
    private void ChangeSceneCost()
    {
        currentCourage -= 20;
        couragebar.SetCourage(currentCourage);
    }
    void TakeDamage(float damage)
    {
        currentCourage += damage;
        couragebar.SetCourage(currentCourage);
        if(damage < 0f)
        {
            source.GenerateImpulse();
            FindObjectOfType<SoundManager>().PlaySound("Damage");
            Fade(redScreen);
        }
        else
        {
            FindObjectOfType<SoundManager>().PlaySound("Heal");
            Fade(greenScreen);
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

    public void Fade(CanvasGroup canva)
    {
        var canvGroup = canva;
        StartCoroutine(DoFade(canvGroup));

        mFaded = !mFaded;
    }
    public IEnumerator DoFade(CanvasGroup canva)
    {
        float counter = 0f;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            canva.alpha = Mathf.Lerp(1.0f, 0, counter / duration);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using System;

public class SceneLoader : MonoBehaviour
{
    private CinemachineVirtualCamera cineCam;
    private PlayerSpawner player;
    private Vector3 playerStartPos;
    public CanvasGroup canvas;
    private float duration = 1f;
    private static string exitName = "";
    private static string sceneToLoad = "";
    
    private static SceneLoader _instance;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            player = FindObjectOfType<PlayerSpawner>();
            cineCam = FindObjectOfType<CinemachineVirtualCamera>();
            playerStartPos = player.transform.position;
            //Invoke ExitScene.cs
            LevelEvent.onChangeScene.AddListener(OnEnteredExitTrigger);

            //couragebar.cs
            LevelEvent.onVictory.AddListener(ShowVictoryScreen);
            LevelEvent.onDefeat.AddListener(ShowDefeatScreen);
            LevelEvent.gotMaxCourage.AddListener(ShowVictoryScreen);

            //finalText.cs
            LevelEvent.onReplay.AddListener(StartReplay);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void StartReplay()
    {
        player.movement.controllerIsActive = false;
        player.transform.position = playerStartPos;
        SceneManager.LoadScene("PlayerRoom");
    }

    private void ShowDefeatScreen()
    {
        SceneManager.LoadScene("DefeatScreen");
    }

    private void ShowVictoryScreen()
    {
        if (SceneManager.GetActiveScene().name == "Gym")
        {
            SceneManager.LoadScene("VictoryScreen");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Teleport Player
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == sceneToLoad)
        {
            EntranceScene[] allEntrance = FindObjectsOfType<EntranceScene>();
            
            foreach (EntranceScene entrance in allEntrance)
            {
                if (entrance.lastExitName == exitName)
                {
                    player.movement.controllerIsActive = false;
                    cineCam.Follow = player.transform;
                    cineCam.LookAt = player.transform;
                    player.transform.position = entrance.transform.position;
                    player.transform.rotation = Quaternion.Euler(0, 0, 0);
                    player.movement.controllerIsActive = true;
                    return;
                }
            }
        }
        player.movement.controllerIsActive = true;
    }

    public void OnEnteredExitTrigger(ChangeSceneData data)
    {

        StartCoroutine(TransitionToScene(data));
    }

    IEnumerator TransitionToScene(ChangeSceneData data)
    {
        float counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(0, 1.0f, counter / duration);
            yield return null;
        }
        //yield return new WaitForSeconds(3.0f);
        //Load Scene
        exitName = data.exitName;
        sceneToLoad = data.sceneName;
        if (sceneToLoad == "Gym")
        {
            //couragebar.cs
            LevelEvent.onGetToLastScene.Invoke();
        }
        SceneManager.LoadScene(data.sceneName);
        counter = 0f;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            canvas.alpha = Mathf.Lerp(1.0f, 0, counter / duration);
            yield return null;
        }
    }
 }
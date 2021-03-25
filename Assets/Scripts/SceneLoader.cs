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
            //Invoke ExitScene.cs
            LevelEvent.onChangeScene.AddListener(OnEnteredExitTrigger);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Teleport Player
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == sceneToLoad)
        {
            Debug.Log(sceneName + " " + sceneToLoad);
            EntranceScene[] allEntrance = FindObjectsOfType<EntranceScene>();
            
            foreach (EntranceScene entrance in allEntrance)
            {
                if (entrance.lastExitName == exitName)
                {
                    player.movement.controllerIsActive = false;
                    cineCam.Follow = player.transform;
                    cineCam.LookAt = player.transform;
                    player.transform.position = entrance.transform.position;
                    player.transform.rotation = entrance.transform.rotation;
                    Debug.Log(entrance.lastExitName + " " + exitName);
                    player.movement.controllerIsActive = true;
                    return;
                }
            }
        }
    }

    public void OnEnteredExitTrigger(ChangeSceneData data)
    {
        //Load Scene
        exitName = data.exitName;
        sceneToLoad = data.sceneName;
        SceneManager.LoadScene(data.sceneName); 
    }
 }
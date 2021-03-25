using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class SceneLoader : MonoBehaviour
{
    public CinemachineVirtualCamera cineCam;
    public GameObject playerPrefab;
    private string exitName = "";
    private string sceneToLoad = "";

    private static SceneLoader _instance;
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }

        //Invoke ExitScene.cs
        LevelEvent.onChangeScene.AddListener(OnEnteredExitTrigger);
    }

    public void OnEnteredExitTrigger(ChangeSceneData data)
    {
        exitName = data.exitName;
        sceneToLoad = data.sceneName;
        SceneManager.LoadScene(data.sceneName);
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Debug.Log(sceneName);

        if (sceneName == sceneToLoad)
        {
            EntranceScene[] allEntrance = FindObjectsOfType<EntranceScene>();
            foreach (EntranceScene entrance in allEntrance)
            {
                if (entrance.lastExitName == exitName)
                {
                    PlayerSpawner player = FindObjectOfType<PlayerSpawner>();
                    cineCam.Follow = player.transform;
                    cineCam.LookAt = player.transform;
                    player.transform.position = entrance.transform.position;
                    player.transform.rotation = entrance.transform.rotation;
                    return;
                }
            }
        }
    }
 }
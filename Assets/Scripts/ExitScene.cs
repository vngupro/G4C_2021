using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitScene : MonoBehaviour
{
    public string SceneName;
    public string exitName;

    private void OnTriggerEnter(Collider other)
    {
        LevelEvent.onChangeScene.Invoke(new ChangeSceneData(exitName, SceneName));
    }
}

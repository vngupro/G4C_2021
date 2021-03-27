using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class LevelEvent 
{
    public static ChangeSceneEvent onChangeScene = new ChangeSceneEvent();
    public static ChangeMaskEvent onChangeMask = new ChangeMaskEvent();
    public static ChangeCourageEvent onNoMask = new ChangeCourageEvent();
    public static ChangeCourageEvent onCollide = new ChangeCourageEvent();
    public static UnityEvent onGetToLastScene = new UnityEvent();
    public static UnityEvent onVictory = new UnityEvent();
    public static UnityEvent onDefeat = new UnityEvent();
    public static UnityEvent gotMaxCourage = new UnityEvent();
    public static UnityEvent onReplay = new UnityEvent();
}

public class ChangeCourageEvent : UnityEvent<float> { }
public class ChangeMaskEvent : UnityEvent<State> { }
public class ChangeSceneEvent : UnityEvent<ChangeSceneData>{ }
public class ChangeSceneData
{
    public string exitName;
    public string sceneName;

    public ChangeSceneData(string _exitName, string _sceneName)
    {
        this.exitName = _exitName;
        this.sceneName = _sceneName;
    }
} 
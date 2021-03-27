using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject courageBarManager;
    public GameObject maskManager;
    public GameObject canvas;
    public PlayerSpawner player;
    public void Start()
    {
        this.gameObject.SetActive(true);
        courageBarManager.SetActive(false);
        maskManager.SetActive(false);
        canvas.SetActive(false);
        player.movement.controllerIsActive = false;
    }
    public void CloseTutorial()
    {
        this.gameObject.SetActive(false);
        courageBarManager.SetActive(true);
        maskManager.SetActive(true);
        canvas.SetActive(true);
        player.movement.controllerIsActive = true;
    }
}

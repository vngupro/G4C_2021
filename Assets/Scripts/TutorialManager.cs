using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject courageBarManager;
    public GameObject maskManager;
    public GameObject canvas;
    public PlayerSpawner player;
    private static TutorialManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Start()
    {
        this.gameObject.SetActive(true);
        //courageBarManager.SetActive(false);
        //maskManager.SetActive(false);
        //canvas.SetActive(false);
        player.movement.controllerIsActive = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CloseTutorial();
        }
    }
    public void CloseTutorial()
    {
        this.gameObject.SetActive(false);
        //courageBarManager.SetActive(true);
        //maskManager.SetActive(true);
        //canvas.SetActive(true);
        player.movement.controllerIsActive = true;
    }
}

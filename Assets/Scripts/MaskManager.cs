using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MaskManager : MonoBehaviour
{
    public GameObject maskInventory;
    public GameObject maskOpen;
    public Image image;
    public TMP_Text textBox;
    public Sprite[] sprites;
    public LayerMask layer;
    [HideInInspector]
    public State state;

    //public static MaskManager instance;
    //private void Awake()
    //{
    //    if(instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //        LevelEvent.onChangeMask.AddListener(ChangeMaskUI);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    private void Start()
    {
        state = State.FULLMASK;
    }

    public void RemoveMask()
    {
        if (state != State.NONE)
        {
            state++;
            //playerListen.cs
            LevelEvent.onChangeMask.Invoke(state);
            ChangeMaskUI(state);
            FindObjectOfType<SoundManager>().PlaySound("UpMask");
        }
    }

    public void AddMask()
    {
        if (state != State.FULLMASK)
        {
            state--;
            //playerListen.cs
            LevelEvent.onChangeMask.Invoke(state);
            ChangeMaskUI(state);
            FindObjectOfType<SoundManager>().PlaySound("DownMask");
        }
    }

    public void ChangeMaskUI(State state)
    {
        switch (state)
        {
            case State.FULLMASK:
                textBox.text = "4/4";
                image.sprite = sprites[0];
                break;
            case State.THIRD:
                textBox.text = "3/4";
                image.sprite = sprites[1];
                break;
            case State.HALF:
                textBox.text = "2/4";
                image.sprite = sprites[2];
                break;
            case State.QUARTER:
                textBox.text = "1/4";
                image.sprite = sprites[3];
                break;
            case State.NONE:
                textBox.text = "0/4";
                image.sprite = sprites[4];
                ResetMask();
                break;
            default:
                textBox.text = "0/4";
                image.sprite = sprites[4];
                ResetMask();
                break;
        }
    }

    public void ResetMask()
    {
        StartCoroutine(PutFullMask());
        textBox.text = "4/4";
        image.sprite = sprites[0];
        state = State.FULLMASK;
    }
    public IEnumerator PutFullMask()
    {
        yield return new WaitForSeconds(3.0f);
    }
    //public void OpenMask()
    //{
    //    maskOpen.SetActive(false);
    //    maskInventory.SetActive(true);
    //}

    //public void CloseMask()
    //{
    //    maskOpen.SetActive(true);
    //    maskInventory.SetActive(false);
    //}
}

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
    private void Awake()
    {
        LevelEvent.onChangeMask.AddListener(ChangeMaskUI);
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
                break;
            default:
                textBox.text = "0/4";
                image.sprite = sprites[4];
                break;
        }
    }
    public void OpenMask()
    {
        maskOpen.SetActive(false);
        maskInventory.SetActive(true);
    }

    public void CloseMask()
    {
        maskOpen.SetActive(true);
        maskInventory.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public MaskSlot[] maslSlots;
    public State state;

    public KeyCode upMask = KeyCode.E;
    public KeyCode downMask = KeyCode.F;
    //private static Mask _instance;
    //private void Awake()
    //{
    //    if (_instance == null)
    //    {
    //        _instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this);
    //    }
    //}

    private void Update()
    {
        if(Input.GetKeyDown(upMask) ) 
        {
            if(state != State.NONE)
            {
                state++;
                //playerListen.cs
                LevelEvent.onChangeMask.Invoke(state);
                FindObjectOfType<SoundManager>().PlaySound("UpMask");
            }
            Debug.Log("Remove = " + state);
        }
        else if(Input.GetKeyDown(downMask) )
        {
            if(state != State.FULLMASK)
            {
                state--;
                LevelEvent.onChangeMask.Invoke(state);
                FindObjectOfType<SoundManager>().PlaySound("DownMask");
            }
            Debug.Log("Add = " + state);
        }
    }
}

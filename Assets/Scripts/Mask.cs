using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public MaskSlot[] maslSlots;
    public KeyCode upMask = KeyCode.E;
    public KeyCode downMask = KeyCode.F;
    [HideInInspector]
    public State state;

    private void Start()
    {
        state = State.FULLMASK;
    }
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
        }
        else if(Input.GetKeyDown(downMask) )
        {
            if(state != State.FULLMASK)
            {
                state--;
                LevelEvent.onChangeMask.Invoke(state);
                FindObjectOfType<SoundManager>().PlaySound("DownMask");
            }
        }
    }
}

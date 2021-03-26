using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mask : MonoBehaviour
{
    public MaskSlot[] maslSlots;
    public State state;

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
        if (Input.GetMouseButtonDown(0))
        {
            if(state != State.NONE)
            {
                state++;
                LevelEvent.onChangeMask.Invoke(state);
            }
            Debug.Log("Remove = " + state);
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if(state != State.FULLMASK)
            {
                state--;
                LevelEvent.onChangeMask.Invoke(state);
            }
            Debug.Log("Add = " + state);
        }
    }
}

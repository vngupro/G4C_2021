using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaskManager : MonoBehaviour
{
    public void OpenMask()
    {
        Debug.Log("open Mask");
    }

    public void CloseMask()
    {
        SceneManager.LoadScene("Ginny 1");
        Debug.Log("close Mask");
    }
}

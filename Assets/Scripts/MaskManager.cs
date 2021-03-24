using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MaskManager : MonoBehaviour
{
    public GameObject maskInventory;
    public GameObject maskOpen;
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

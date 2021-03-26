using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new Dialogue List", menuName = "ScriptableObjects/DialogueList")]
public class DialogueList : ScriptableObject
{
    public List<string> stringList = new List<string>();
}
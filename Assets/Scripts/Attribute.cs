using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attribute", menuName = "ScriptableObjects/Attribute", order = 0)]
public class Attribute : ScriptableObject
{
    public string Name;
    [TextArea(4,10)]
    public string Description;
    public int Value;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public List<NPCDialogue> dialogues = new List<NPCDialogue>();
    [SerializeField]
    public TMP_Text dialogueBox;
    public bool canGetLastDialogue = false;
    private void Start()
    {
        dialogueBox.text = dialogues[0].dialogue.text; 
    }

    public void ChangeDialogue(State state)
    {
        foreach(NPCDialogue dialogue in dialogues)
        {
            if(dialogue.state == state)
            {
                dialogueBox.text = dialogue.dialogue.text;
            }
        }
    }

    public void CanGetLastDialogue(bool value)
    {
        Debug.Log("Get Last Dialogue");
        canGetLastDialogue = value;
    }

}

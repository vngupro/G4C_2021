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
    public bool canShowDialogue = false;
    private void Start()
    {
        dialogueBox.text = dialogues[0].dialogue.text;
        dialogueBox.enabled = false;
    }

    public void CanShowDialogue(bool value)
    {
        canShowDialogue = value;
        dialogueBox.enabled = value;
        if (!value) { dialogueBox.text = "";  }
        Debug.Log("can show dialogue");
    }
    public void ChangeDialogue(State state)
    {
        if (canShowDialogue)
        {
            foreach (NPCDialogue dialogue in dialogues)
            {
                if (!canGetLastDialogue)
                {
                    if (dialogue.state == state && state != State.FULLMASK)
                    {
                        dialogueBox.text = dialogue.dialogue.text;
                    }
                }
                else
                {
                    if (dialogue.state == state)
                    {
                        dialogueBox.text = dialogue.dialogue.text;
                    }
                }
            }
            Debug.Log("Get New Dialogue ");
        }
    }

    public void CanGetLastDialogue(bool value)
    {
        Debug.Log("Get Last Dialogue");
        canGetLastDialogue = value;
    }

}

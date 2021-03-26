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

    public float braveValue = 0;
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
        Debug.Log("can show dialogue = " + value);
    }
    public void ChangeDialogue(State state)
    {
        if (canShowDialogue)
        {
            foreach (NPCDialogue dialogue in dialogues)
            {
                if (dialogue.state == state)
                {
                    dialogueBox.text = dialogue.dialogue.text;
                }
            }
            Debug.Log("Get New Dialogue ");
        }

        if(state == State.NONE)
        {
            LevelEvent.onNoMask.Invoke(braveValue);
        }
    }

    //public void CanGetLastDialogue(bool value)
    //{
    //    Debug.Log("Get Last Dialogue");
    //    canGetLastDialogue = value;
    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        CanShowDialogue(true);
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanShowDialogue(false);
        }
    }

}

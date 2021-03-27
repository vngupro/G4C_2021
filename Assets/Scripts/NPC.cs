using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPC : MonoBehaviour
{
    public List<NPCDialogue> dialogues = new List<NPCDialogue>();
    public Dialogue collideDialogue;
    [SerializeField]
    public TMP_Text dialogueBox;
    private bool canShowDialogue = false;
    private DialogueType dialogueType;
    public float braveValue = 0;
    private bool hasTalkToPlayer = false;
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
                    dialogueType = dialogue.dialogue.dialogueType;
                }
            }

            if(state == State.NONE && !hasTalkToPlayer)
            {
                //CourageBar.cs
                LevelEvent.onNoMask.Invoke(braveValue);
                hasTalkToPlayer = true;
            }
        }
    }

    private void ShowOnCollideText()
    {
        dialogueBox.enabled = true;
        dialogueBox.text = collideDialogue.text;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CanShowDialogue(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ShowOnCollideText();
            //CourageBar.cs
            LevelEvent.onCollide.Invoke(-Mathf.Abs(braveValue / 2.0f));
        }
    }

}

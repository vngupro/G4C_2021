using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FinalText : MonoBehaviour
{
    public TMP_Text textBox;
    public TMP_Text buttonTextBox;
    public DialogueList dialogueList;
    private int count;

    private void Start()
    {
        textBox.text = dialogueList.stringList[count];
        count++;
    }
    public void GetNextDialogue()
    {
        if (count == dialogueList.stringList.Count)
        {
            SceneManager.LoadScene("PlayerRoom");
            return;
        }
        textBox.text = dialogueList.stringList[count];

        count++;
        if (count == dialogueList.stringList.Count)
        {
            buttonTextBox.text = "Replay";
        }
    }
}

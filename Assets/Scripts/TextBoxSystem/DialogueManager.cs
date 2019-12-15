using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI textbox;

    private Queue<string> dialogue;

    private void Start()
    {
        dialogue = new Queue<string>();
    }

    public void StartDialogue(Dialogue text)
    {
        dialogue.Clear();

        foreach(string sentence in text.dialogue)
        {
            dialogue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        if(dialogue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = dialogue.Dequeue();
        textbox.text = sentence;
    }

    public void EndDialogue()
    {

    }

}

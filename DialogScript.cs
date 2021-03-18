using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogScript: MonoBehaviour
{
    public GameObject DialogueBox;
    private Queue<string> sentences;


    public void EnableDialogBox()
    {
        DialogueBox.SetActive(true);
    }

    void Start()
    {
        sentences = new Queue<string>();   
    }

    public void StartDialog(Dialog dialogue)
    {
        Debug.Log("Starting Vonversation with: " + dialogue.name);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {

            EndDialogue();
            return;
        }

        Debug.Log("Hello there");
        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation with");
    }
}

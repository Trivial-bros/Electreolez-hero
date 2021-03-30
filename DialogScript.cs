
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScript: MonoBehaviour
{
    //variables
    public static int DialogCount;
    public GameObject DialogueBox;
    private Queue<string> sentences;
    public TextMeshProUGUI PancakesNameText;
    public TextMeshProUGUI PancakesText;
    public Animator animator;
    public Mouselook Mouselook;
    public GameObject MainUI;
    public Playermovement Playermovement;
    public GameObject Weapons;

    private void Update()
    {
        Debug.Log(DialogCount);
    }

    public void EnableDialogBox()
    {
        //we just activate the dialog box I guess
        DialogueBox.SetActive(true);    
    }

    void Start()
    {
        //we fill up the sentences array with stuff
        sentences = new Queue<string>();   
    }

    public void StartDialog(Dialog dialogue)
    {
       //we prevent the player from looking around and also set pancakes's name
        Mouselook.isIntext = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Playermovement.enabled = false;
        Weapons.SetActive(false);
        PancakesNameText.text = dialogue.name;

        //clear old queues
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
           //we get the elements of the sentences array from the dialog class and put them in this class
            sentences.Enqueue(sentence);
        }

       //display stuff's method
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
       //check if the npc has said everything they need to say
        if(sentences.Count == 0)
        {

            EndDialogue();
            return;
        }

       //we dequeue the sentence that pancakes just saif
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(Typesentence(sentence));
    }

    IEnumerator Typesentence (string sentence)
    {
        //we use a coroutine so we can gradually draw out the text 1 letter per frame
        PancakesText.text = "";
        foreach (char letter in sentence.ToCharArray()) 
        {
            PancakesText.text += letter;
            yield return null; //wait a frame
        }
    }

    public void EndDialogue()
    {
       //allow the player to look around again, activate the ui and disable the script
        animator.SetTrigger("done");
        Mouselook.isIntext = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Playermovement.enabled = true;
        Weapons.SetActive(true);
        MainUI.SetActive(true);
        DialogCount++;
        this.enabled = false;
    }

    //random corrotine dont wanna remove it tho scared I might break a thing
    IEnumerator disableDialogBox()
    {
        yield return null;
    }
    
}


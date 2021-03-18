using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog Dialogue;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogScript>().StartDialog(Dialogue); 
    }
}

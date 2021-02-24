using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    public playerhealth playerhealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerhealth.TakeDamage(999);
        }
    }
}

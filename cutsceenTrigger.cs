using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutsceenTrigger : MonoBehaviour
{
    public GameObject deathZone1;
    public GameObject deathZone2;
    public GameObject deathZone3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            deathZone1.SetActive(false);
            deathZone2.SetActive(false);
            deathZone3.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShatterGlass : MonoBehaviour
{
    public GameObject Shatterglass;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Invoke("destroy", 7);
            Shatterglass.SetActive(true);
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    void destroy()
    {
        Destroy(Shatterglass);
        Destroy(gameObject);
    }
}

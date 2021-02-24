using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperLogic : MonoBehaviour
{
    public WeaponSwitcher WeaponSwitcher;
    public GameObject SniperModel;
    public GameObject SniperVision;
    public GunLogic GunLogic;

    // Update is called once per frame
    void Update()
    {
        if (GunLogic.isScoped == true && WeaponSwitcher.selectedWeapon == 1)
        {
            StartCoroutine(Scope());
        }

        else
        {
            StartCoroutine(Unscope());
        }
        
    }

    IEnumerator Scope()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<MeshRenderer>().enabled = false;
        SniperVision.SetActive(true);
    }

    IEnumerator Unscope()
    {
        GetComponent<MeshRenderer>().enabled = true;
        SniperVision.SetActive(false);
        yield return new WaitForSeconds(0f);
    }
}

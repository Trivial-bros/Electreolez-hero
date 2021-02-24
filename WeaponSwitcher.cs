
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
   [HideInInspector]
    public int selectedWeapon = 0;
    public GunLogic GunLogic;
    bool reloading;

    // Start is called before the first frame update
    void Start()
    {
        
        Selectweapon();
    }

    // Update is called once per frame
    void Update()
    {
        reloading = GunLogic.isReloading;
        int previousSelectedWeapon = selectedWeapon;

        if (GunLogic.isScoped)
            return;
        if (reloading == false)
        {

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                {
                    selectedWeapon = 0;
                }

                else
                {
                    selectedWeapon++;
                }
            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                {
                    selectedWeapon = transform.childCount - 1;
                }

                else
                {
                    selectedWeapon--;
                }
            }
            if (previousSelectedWeapon != selectedWeapon)
            {
                Selectweapon();
            }
        }
            
    }

    void Selectweapon()
    {
        int i = 0;
        foreach(Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}

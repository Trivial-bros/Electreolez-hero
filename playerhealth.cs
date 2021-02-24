using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerhealth : MonoBehaviour
{
    public TextMeshProUGUI Text;

    public int MaxHealth = 100;
    public int currentHealth;

    public healthbar healthbar;
    public GameObject bloodeffect;
    public GameObject Deathscreen;

    [HideInInspector]
    public bool isDead = false;

    // Update is called once per frame
    void Start()
    {
        currentHealth = MaxHealth;
        healthbar.Setmaxhealth(MaxHealth);
    }

    private void Update()
    {
        Text.text = currentHealth + "";

        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(20);
        }
        if (currentHealth <= -1)
        {
            currentHealth = 0;
        }
        
        
        redborder();
        playerdeath();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.sethealth(currentHealth);
    }

    void redborder()
    {
        
        
        if (currentHealth <= 20 && currentHealth != 0)
        {
            bloodeffect.SetActive(true);
        }
        else
        {
             bloodeffect.SetActive(false);
        }
    }

    void playerdeath()
    {
        if (currentHealth <= 0)
        {
            isDead = true;
            Deathscreen.SetActive(true);
            GetComponent<Playermovement>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Deathscreen.SetActive(false);
        }
    }
}

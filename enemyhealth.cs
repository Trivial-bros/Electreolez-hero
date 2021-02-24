using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyhealth : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth = 0;
    public Animator animator;
    public GameObject enemyattackbox;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("isDead", true);

        enemyattackbox.GetComponent<hurtplayer>().enabled = false;
        GetComponent<EnemyAi>().enabled = false;
        GetComponent<NavMeshAgent>().enabled = false;
        GetComponent<Collider>().enabled = false;
        this.enabled = false;
    }
}

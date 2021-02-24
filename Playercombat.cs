using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercombat : MonoBehaviour
{
    public Transform attackpoint;
    public LayerMask EnemyLayer;
    public Animator animator;
    
    public float attackrange = 0.5f;
    public int attackdamage = 40;

    public float attackrate = 5f;
    float nextAttackTime = 0f;

    private void Update()
    {
        if(Time.time > nextAttackTime)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackrate;
            }
        }       
    }

    void Attack()
    {
        animator.SetTrigger("ataacc");

        Collider[] hitenemies =  Physics.OverlapSphere(attackpoint.position, attackrange, EnemyLayer);

        foreach(Collider enemy in hitenemies)
        {
            enemy.GetComponent<enemyhealth>().takeDamage(40);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint == null)
            return;

        Gizmos.DrawWireSphere(attackpoint.position, attackrange);
    }
}

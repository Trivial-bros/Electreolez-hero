using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katchruntrigger : MonoBehaviour
{
    public Animator enemyAnimator;
    public Animator enemyAnimator2;

    [SerializeField]
    bool startAnim = false;
   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (startAnim == true)
            {
                enemyAnimator2.SetTrigger("endtrigger");
                enemyAnimator.SetTrigger("startrun");
            }
            else
            {
                enemyAnimator.SetTrigger("endrun");
            }
        }
    }
}

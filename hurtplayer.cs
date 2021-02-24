
using UnityEngine;

public class hurtplayer : MonoBehaviour
{
    private bool touchingDock = false;
    public playerhealth playerHealth;
    private float nextActionTime = 0.0f;
    public float period = 1f;
    public Animator enemyAnimator;

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            if (touchingDock)
            {
                HurtPlayer();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            touchingDock = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            touchingDock = false;
        }
    }

    private void hurtPlayer()
    {
        Invoke("HurtPlayer", 1);
    }

    private void HurtPlayer()
    {
        playerHealth.TakeDamage(20);
        enemyAnimator.SetTrigger("attack");
    }
}

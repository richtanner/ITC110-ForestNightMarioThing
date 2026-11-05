using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // destroy bullet so it doesn't hurt anyone else
            Destroy(other.gameObject);

            if (animator != null)
            {
                // animate and do cool stuff
                animator.SetTrigger("gotKilled");


                Destroy(gameObject, 0.5f);
            }
            else
            {
                // nothing to show, instakill
                Destroy(gameObject);
            }
        }


    }
}

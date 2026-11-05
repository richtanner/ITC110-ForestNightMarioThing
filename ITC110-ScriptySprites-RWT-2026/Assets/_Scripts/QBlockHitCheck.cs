using UnityEngine;

[RequireComponent(typeof(Animator))]

public class QBlockHitCheck : MonoBehaviour
{
    private Animator animator;
    private bool beenCollected = false;
    [SerializeField] AudioClip bumpSound;
    [Header("PowerUp in Block")]
    [SerializeField] GameObject reward;
    [SerializeField] Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        if (reward == null)
        {
            Debug.LogError("Q Block has no assigned Reward! What the CHEAP?!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts.Length > 0)
        {
            ContactPoint2D contact = collision.contacts[0];
            if (Vector2.Dot(contact.normal, Vector2.up) > 0.5)
            {
                //collision was from below
                if (collision.gameObject.tag == "Player" && !beenCollected)
                {
                    beenCollected = true;
                    AudioSource.PlayClipAtPoint(bumpSound, transform.position);
                    animator.SetBool("didHit", true);
                    SpawnReward();
                }
            }
        }
    }
    private void SpawnReward ()
    {
        // The Power-Up instantiation happens here.
        GameObject PowerUpReward;
        PowerUpReward = Instantiate(reward, spawnPoint.position, spawnPoint.rotation) as GameObject;
    }
}

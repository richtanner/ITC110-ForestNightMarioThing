using UnityEngine;

public class CoinCleanup : MonoBehaviour
{
    private SpriteRenderer rend;
    public AudioClip coinSound;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        AudioSource.PlayClipAtPoint(coinSound, transform.position);
    }

    void SelfDestruct()
    {
        Destroy(gameObject);
    }

    void MoveForward()
    {
        rend.sortingOrder = 5;
    }
}

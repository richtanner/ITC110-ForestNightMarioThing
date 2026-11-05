using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    GameManager gameManager;
    private bool didCountKey = false;

    private void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !didCountKey)
        {
            didCountKey = true;
            gameManager.numberOfKeys++;
            gameManager.audioSource.clip = gameManager.keyClip;
            gameManager.audioSource.Play();
            Destroy(gameObject);
        }
    }
}

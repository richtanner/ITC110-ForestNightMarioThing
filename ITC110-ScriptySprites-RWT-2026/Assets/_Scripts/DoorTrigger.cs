using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    GameManager gameManager;
    public int numberOfKeysRequired = 1;

    private void Start()
    {
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (gameManager.numberOfKeys < numberOfKeysRequired)
            {
                // donk
                gameManager.audioSource.clip = gameManager.noKeyClip;
                gameManager.audioSource.Play();
            }
            else
            {
                gameManager.numberOfKeys--;
                gameManager.audioSource.clip = gameManager.keyClip;
                gameManager.audioSource.Play();
                Destroy(gameObject);
            }
        }
    }

}

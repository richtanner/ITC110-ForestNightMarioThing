using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpicFailAdvanced : MonoBehaviour
{
    GameManager gameManager;
    private bool isColliding = false;

    private void Start()
    {
        // only works if Canvas is literally named "Canvas"
        gameManager = GameObject.Find("Canvas").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isColliding)
        {
            return;
        }

        if (other.gameObject.tag == "Player")
        {
            isColliding = true;

            if (gameManager.numberOfLives == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                gameManager.numberOfLives--;
                other.gameObject.transform.position = gameManager.spawnPoint;
            }

            StartCoroutine(Reset());
            
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        isColliding = false;
    }
}

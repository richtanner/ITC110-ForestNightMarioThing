using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpicFail : MonoBehaviour
{
    LevelManager LM;
    private bool isColliding = false;

    private void Start()
    {
        // only works if the Canvas is literally named "Canvas"
        LM = GameObject.Find("Canvas").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // OnTriggerEnter2D can get called a LOT, so here, if it's already 
        // colliding, we are bailing out so we don't lose 2 lives at once
        if (isColliding)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            isColliding = true;

            if (LM.numberOfLives == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                LM.numberOfLives--;
                LM.lifeCounterText.SetText("Lives: " + LM.numberOfLives);
                other.gameObject.transform.position = LM.spawnPoint;
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
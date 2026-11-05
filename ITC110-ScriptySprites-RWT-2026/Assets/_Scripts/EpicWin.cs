using UnityEngine;
using UnityEngine.SceneManagement;

public class EpicWin : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            // write something to the Console just to make 
            // sure this function is being called
            Debug.Log("WE ARE WINNER!");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

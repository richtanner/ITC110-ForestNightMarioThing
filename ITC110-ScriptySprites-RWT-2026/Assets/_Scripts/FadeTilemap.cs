using UnityEngine;
using UnityEngine.Tilemaps;

public class FadeTilemap : MonoBehaviour
{
    public float fadeAmount = 0.1f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Color faded = GetComponent<Tilemap>().color;
            faded.a = fadeAmount;
            GetComponent<Tilemap>().color = faded;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Color restore = GetComponent<Tilemap>().color;
            restore.a = 1.0f;
            GetComponent<Tilemap>().color = restore;
        }
    }
}

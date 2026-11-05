using UnityEngine;

public class Warp : MonoBehaviour
{
    [SerializeField] Transform warpTarget;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // maybe some smoke and mirrors here, but for now, ENERGIZE
            other.gameObject.transform.position = warpTarget.position;
        }
    }
}

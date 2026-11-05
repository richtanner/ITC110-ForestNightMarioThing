using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioClip pickupSound;

    private bool didPickupAlready = false;

    public LevelManager LM;

    private void Start()
    {
        LM = GameObject.Find("Canvas").GetComponent<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !didPickupAlready)
        {
            didPickupAlready = true;

            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            // tell the canvas about this pickup
            LM.numberOfCoins++;
            LM.coinCounterText.SetText("Moneys: " + LM.numberOfCoins);

            Destroy(gameObject);
        }
    }
}

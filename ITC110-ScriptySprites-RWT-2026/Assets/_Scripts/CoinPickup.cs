using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public enum CoinTypes { Overworld, Underground, Underwater, Castle };

    public CoinTypes coinType;

    [SerializeField] AudioClip pickupSound;

    private void Start()
    {
        switch (coinType)
        {
            case CoinTypes.Overworld:

                break;
            case CoinTypes.Underground:

                break;
            case CoinTypes.Underwater:

                break;
            case CoinTypes.Castle:

                break;
            default:

                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            Destroy(gameObject);
        }
    }

}

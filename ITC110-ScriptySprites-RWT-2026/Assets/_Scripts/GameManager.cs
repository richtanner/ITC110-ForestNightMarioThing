using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int numberOfLives = 3;
    public int numberOfKeys = 0;
    public int numberOfCoins = 0;
    public int costPerExtraLife = 20;

    public TextMeshProUGUI livesText;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI coinsText;

    public Vector3 spawnPoint;
    public AudioSource audioSource;
    public AudioClip coinClip;
    public AudioClip keyClip;
    public AudioClip noKeyClip;
    public AudioClip waypointClip;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = new Vector3(0, 0, 0);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = "Lives: " + numberOfLives;
        keysText.text = "Keys: " + numberOfKeys;
        coinsText.text = "Coins: " + numberOfCoins;

        if (numberOfCoins == costPerExtraLife)
        {
            numberOfCoins = 0;
            numberOfLives++;
        }
    }
}

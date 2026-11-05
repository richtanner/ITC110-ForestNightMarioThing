using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EpicHalfWin : MonoBehaviour
{
    public LevelManager LM;
    private bool hasHitCheckpoint = false;
    public Color endColor = Color.aquamarine;
    private SpriteRenderer spriteRend;
    private Light2D coollight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LM = GameObject.Find("Canvas").GetComponent<LevelManager>();
        spriteRend = GetComponent<SpriteRenderer>();
        coollight = GetComponent<Light2D>();
        coollight.color = spriteRend.color;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !hasHitCheckpoint)
        {
            hasHitCheckpoint = true;
            // tell LM about it
            LM.spawnPoint = this.transform.position;
            spriteRend.color = endColor;
            coollight.color = endColor;
        }
    }
}
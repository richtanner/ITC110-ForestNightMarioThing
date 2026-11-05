using UnityEngine;
using UnityEngine.Jobs;

public class PitMonster : MonoBehaviour
{
    public bool goLeft = true;
    public float moveSpeed = 2.0f;
    public int direction = 1;
    public Vector2 startingScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startingScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // going left along negative direction
        if (goLeft == true)
        {
            direction = -1;
            transform.localScale = startingScale;
        }
        else
        {
            direction = 1;
            transform.localScale = new Vector2(-startingScale.x, startingScale.y);
        }

        transform.Translate(new Vector2(direction, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("EnemyBullet"))
        {
            // change direction
            goLeft = !goLeft;
        }
    }
}

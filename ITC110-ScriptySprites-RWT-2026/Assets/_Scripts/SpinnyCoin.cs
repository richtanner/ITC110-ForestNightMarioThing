using UnityEngine;

public class SpinnyCoin : MonoBehaviour
{
    public Vector2 startingScale;

    private void Start()
    {
        startingScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        // PingPong returns a value that will increment and
        // decrement between the value 0 and length
        transform.localScale = new Vector2(Mathf.PingPong(Time.time * 2, startingScale.x), startingScale.y);
    }
}

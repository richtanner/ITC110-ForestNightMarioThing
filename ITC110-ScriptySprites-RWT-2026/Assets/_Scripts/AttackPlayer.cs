using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public Transform player;
    public float distanceToPlayer = 0;
    public float attackDistance = 20;
    public GameObject bullet;
    public Transform firePoint;
    public float bulletForce = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= attackDistance)
        {
            // ATTACK!
            FireBullet();
        }
    }

    void FireBullet()
    {
        // Bullet instantiate at the position of GameObject
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        newBullet.transform.parent = null;

        // get Rigidbody2D component of instantiated Bullet
        Rigidbody2D tempRigidBody = newBullet.GetComponent<Rigidbody2D>();

        // calc vector to player
        Vector2 direction = transform.position - player.position;
        tempRigidBody.AddForce(direction * bulletForce);

        // basic Clean Up, set Bullets to self destruct after 2 seconds
        Destroy(newBullet, 2.0f);
    }
}

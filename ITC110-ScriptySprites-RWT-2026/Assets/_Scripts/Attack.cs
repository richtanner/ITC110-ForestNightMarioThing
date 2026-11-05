using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;

    public GameObject firePoint;

    Animator animator;

    public bool fireForward = true;

    public float bulletForce = 1500.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0 ) 
        {
            fireForward = true;
        }
        else if (horizontalInput < 0 )
        {
            fireForward = false;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("doAttack");
            FireBullet();
        }
    }

    private void FireBullet()
    {
        // Bullet Instantiation
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;

        // get RigidBody2D off that bullet
        Rigidbody2D tempRigidbody = newBullet.GetComponent<Rigidbody2D>();

        // "push" the bullet forward
        if (fireForward)
        {
            // fire to the right
            tempRigidbody.AddForce(transform.right * bulletForce);
        }
        else
        {
            // fire to the negative right a.k.a. "left"
            tempRigidbody.AddForce(-transform.right * bulletForce);
        }

        // basic cleanup, go bye-bye after 2 seconds
        Destroy(newBullet, 2.0f);
    }
}

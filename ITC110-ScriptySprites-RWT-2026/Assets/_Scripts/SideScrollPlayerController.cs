using UnityEngine;
using UnityEngine.InputSystem;

public class SideScrollPlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 50.0f;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public bool isGrounded = false;
    public InputActionReference playerMove;
    public InputActionReference playerJump;
    public AudioClip jumpSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // get input from Input System
        Vector2 directionP = playerMove.action.ReadValue<Vector2>();
        directionP.y = 0; // reset the Y so we don't go UP or DOWN
        transform.Translate(directionP * moveSpeed * Time.deltaTime);

        // animate!
        if (directionP.x > 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = false;
        }
        else if (directionP.x < 0)
        {
            animator.SetBool("isRunning", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void OnEnable()
    {
        playerJump.action.started += JumpPlayer;
    }

    private void OnDisable()
    {
        playerJump.action.started -= JumpPlayer;
    }

    void JumpPlayer(InputAction.CallbackContext context)
    {
        if (isGrounded == true)
        {
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
            rb.AddForce(transform.up * jumpForce);
        }
    }

    private void OnTriggerStay2D (Collider2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        isGrounded = false;
    }
}

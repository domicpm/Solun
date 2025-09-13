using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    public bool isGrounded = false;

    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (PlayerLightDamage.isDead) { return; }
        // Horizontal Bewegung
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Überprüfen ob am Boden
        Vector2 groundCheckPos = (Vector2)transform.position + (Vector2.down * 0.5f);
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, checkRadius, groundLayer);

        // Springen
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    public float doubleTapMaxDelay = 0.3f; // maximal erlaubte Zeit zwischen zwei Taps
    private float lastTapTime = 0;
    public Transform groundCheck;
    public float checkRadius = 0.2f;
    public LayerMask groundLayer;
    public SaveSquarePos lastSquare; // das zuletzt berührte Square
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

        if (Input.touchCount > 0 && isGrounded)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (Time.time - lastTapTime < doubleTapMaxDelay)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }

                lastTapTime = Time.time;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shadow")) // dein Square-Tag
        {
            SaveSquarePos square = collision.gameObject.GetComponent<SaveSquarePos>();
            if (square != null)
            {
              lastSquare = square;
              Debug.Log("Neues aktives Square: " + square.name);
            }
        }
    }
}

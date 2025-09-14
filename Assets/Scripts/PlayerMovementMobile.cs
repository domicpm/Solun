using UnityEngine;

public class PlayerMovementMobile : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // Bildschirmhälfte bestimmen
                if (touch.position.x < Screen.width / 2)
                {
                    // Links
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }
                else
                {
                    // Rechts
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
}

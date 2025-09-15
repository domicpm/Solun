using System.Collections;
using UnityEngine;

public class StickProjectile : MonoBehaviour
{
    public float jointBreakForce = 100f; // optional: Joint kann bei Gewalt brechen

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shadow") || collision.gameObject.CompareTag("Projectile")) // dein Square-Tag
        {
            Rigidbody2D targetRb = collision.rigidbody;
            if (rb == null || targetRb == null) return;

            // Projektil stoppt
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            // Temporär Gravity erhöhen
            rb.gravityScale = 1f;
            rb.mass = 0.5f;
            // Projektil bleibt physikalisch am Square hängen
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = targetRb;
            joint.breakForce = jointBreakForce;
            joint.enableCollision = true;

            // Coroutine starten, um Gravity zurückzusetzen
            StartCoroutine(GravityReset(0.2f));
        }
    }

    IEnumerator GravityReset(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        // Gravity wieder auf 0 setzen
        if (rb != null)
            rb.gravityScale = 0f;
    }
}

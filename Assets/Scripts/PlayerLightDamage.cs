using UnityEngine;

public class PlayerLightDamage : MonoBehaviour
{
    public Transform pointLight;        // Die Lichtquelle
    public LayerMask shadowLayer;       // Layer, auf dem ShadowCasters liegen
    public SpriteRenderer spriteRenderer; // SpriteRenderer des Players
    public float fadeSpeed = 4f; // Geschwindigkeit des Fadens
    public static bool isDead = false;
    public PlayerParticleExplosion ppe;
    void Update()
    {
        // Position des Players
        Vector2 playerPos = transform.position;

        // Richtung vom Licht zum Player
        Vector2 dir = (playerPos - (Vector2)pointLight.position).normalized;

        // Distanz zum Licht
        float distance = Vector2.Distance(pointLight.position, playerPos);

        // Raycast prüfen, ob ShadowCaster dazwischen
        RaycastHit2D hit = Physics2D.Raycast(pointLight.position, dir, distance, shadowLayer);

        if (hit.collider == null)
        {
            // Spieler wird vom Licht „getroffen“
            Color c = spriteRenderer.color; // aktuelle Farbe holend
            c.a = Mathf.Lerp(c.a, 0, fadeSpeed * Time.deltaTime);
            spriteRenderer.color = c;        // neu setzen
            if (c.a <= 0.01f) // kleiner Schwellwert
            {
                Debug.Log("Dead");

                if (ppe != null)
                {
                    ppe.ParticleExplosion(transform.position);
                }
                else
                {
                    Debug.LogWarning("ParticleManager (ppe) ist nicht gesetzt!");
                }

                Destroy(gameObject);
            }

        }
        else
        {
            Color c = spriteRenderer.color; // aktuelle Farbe holen
            c.a = Mathf.Lerp(c.a, 1,  fadeSpeed * Time.deltaTime);
            spriteRenderer.color = c;
        }
    }
}


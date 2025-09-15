using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    private int ableToShot = 5;
    public GameObject prefab;
    public float shootForce = 10f;
    public Transform spawnPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && ableToShot >= 1)
        {
            ableToShot--;
            GameObject projectile = Instantiate(prefab, spawnPos.transform.position, Quaternion.identity);

            // Rigidbody2D holen
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Mausposition in Welt-Koordinaten umrechnen
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPos.z = 0f; // weil 2D

            // Richtung berechnen
            Vector2 direction = (mouseWorldPos - spawnPos.transform.position).normalized;

            // Geschwindigkeit setzen
            rb.velocity = direction * shootForce;

        }
    }
}

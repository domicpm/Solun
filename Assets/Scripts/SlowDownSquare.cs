using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownSquare : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Bremskraft anwenden, damit es nicht wegfliegt
                rb.velocity *= 0.8f; // dämpfen
            }
        }
    }

}

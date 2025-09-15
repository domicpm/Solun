using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSquarePos : MonoBehaviour
{
    public PlayerMovement pm;
    public Rigidbody2D rb;
    public bool isTriggered = false;
    public Vector2 recentSquarePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isTriggered)
        {
                isTriggered = true;
                recentSquarePos = gameObject.transform.position;
                Debug.Log("Pos:" + recentSquarePos);           
        }
    }

    public void ReturnSquare()
    {
        gameObject.transform.position = recentSquarePos;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSquarePos : MonoBehaviour
{
    public PlayerMovement pm;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector2 SavePos()
    {
        return gameObject.transform.position;
    }
    public void ReturnSquare()
    {
        gameObject.transform.position = pm.recentSquarePos;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}

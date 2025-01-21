using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ( collision.relativeVelocity.y <= 0)
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            
            if ( playerRb != null )
            {
                playerRb.velocity = Vector2.up * jumpForce;
            }
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

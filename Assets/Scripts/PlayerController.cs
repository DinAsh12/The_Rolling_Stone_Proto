using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public Rigidbody2D stoneBody;
    public float moveForce;
    public float jumpForce;
    public Vector2 maximumVelocity = new Vector2(20.0f, 20.0f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        // Gets Horizontal axis and move right
        if ((Input.GetAxis("Horizontal") > 0) && stoneBody.transform.position.y <= -2)
        {
             stoneBody.AddForce(Vector2.right * moveForce);
        }
        // Gets Horizontal axis and move left
        if ((Input.GetAxis("Horizontal") < 0) && stoneBody.transform.position.y <= -2)
        {
             stoneBody.AddForce(Vector2.left * moveForce);
        }
        // Jump
        if ((Input.GetAxis("Jump") > 0) && stoneBody.transform.position.y <= -2.3)
        {
            stoneBody.gravityScale = 1;
            stoneBody.AddForce(Vector2.up * jumpForce);
        }
        stoneBody.velocity = new Vector2(
            Mathf.Clamp(stoneBody.velocity.x, -maximumVelocity.x, maximumVelocity.x),
            Mathf.Clamp(stoneBody.velocity.y, -maximumVelocity.y, maximumVelocity.y)
            );
    }
}

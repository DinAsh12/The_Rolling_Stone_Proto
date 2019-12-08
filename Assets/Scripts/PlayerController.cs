using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement Settings")]
    public Rigidbody2D stoneBody;
    public float moveForce;
    private BoxCollider2D boxCollider2d;
    [SerializeField] private LayerMask platformsLayerMask;

    public Vector2 maximumVelocity = new Vector2(20.0f, 20.0f);
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
        stoneBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {

        stoneBody.velocity = new Vector2(Input.GetAxis("Horizontal") * moveForce, 0);

        

        if (IsGrounded() && Input.GetKeyDown(KeyCode.UpArrow))
        {
            float jumpVelocity = 100f;
            stoneBody.velocity = (Vector2.up * jumpVelocity);
        }


        
    }
    

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * 0.1f, platformsLayerMask);

            //(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * 1f,platformsLayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
}

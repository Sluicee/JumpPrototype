using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private BoxCollider2D collider;
    private bool isGrounded;
    private float jumpTimeCounter;
    private bool isJumping;

    [Header("Jump")]
    [Range(0f, 10f)]
    [SerializeField] private float jumpForce;
    [Range(0f, 10f)]
    [SerializeField] private float forwardForce;
    [SerializeField] private float jumpTimer;

    [Header("GroundCheck")]
    [SerializeField] private Transform groundCheckPos;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float checkRadius;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTimer;
            Jump();
        }
        if (Input.GetKey(KeyCode.Space) && isJumping) 
        {
            if (jumpTimeCounter > 0)
            {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    void Jump()
    {
        rigidbody.velocity = new Vector2(forwardForce, jumpForce);

    }

    bool IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos.position, checkRadius, whatIsGround);
        return isGrounded;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] float jumpHeight;
    [SerializeField] float moveSpeed;
    [SerializeField] float slideSpeed;
    [SerializeField] float moveVelocity;
    private Animator animator;

    public bool isActive;

    public Transform groundCheck;
    public Transform wallCheck;
    public LayerMask whatIsGround;
    private bool _isGrounded;
    public bool _isWallSticked;
    private bool _canJump;
    private bool _canDoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        isActive = true;
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();  
    }
    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, whatIsGround);
        _isWallSticked = Physics2D.OverlapCircle(wallCheck.position, 0.1f, whatIsGround);
        _canJump = (_isGrounded || _isWallSticked);
    }
    // Update is called once per frame
    void Update()
    {
        
        moveVelocity = 0f;
        if (isActive)
        {
            if (Input.GetButton("MoveRight"))
            {
                moveVelocity = moveSpeed;
            }

            if (Input.GetButton("MoveLeft"))
            {
                moveVelocity = -moveSpeed;
            }
            Move();
            ChangeFaceDirection();

            if (Input.GetButtonDown("Jump") && _canJump)
            {
                Jump();
            }
            if (_canJump)
                _canDoubleJump = true;
            if (Input.GetButtonDown("Jump") && !_isGrounded && _canDoubleJump)
            {
                Jump();
                _canDoubleJump = false;
            }

            WallSlide();
        }
        

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetBool("WallStick", _isWallSticked);
        animator.SetBool("IsGrounded", _isGrounded);
        animator.SetBool("IsFlying", !_canJump);
        animator.SetBool("DoubleJump", !_canDoubleJump);
    }

    public void Move()
    {
        rb.velocity=new Vector2(moveVelocity,rb.velocity.y);
    }

    public void ChangeFaceDirection()
    {
        if (rb.velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);
        if (rb.velocity.x < 0)
            transform.localScale = new Vector3(-1f, 1f, 1f);
    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        SoundManager.PlaySound(3);
    }

    private void WallSlide()
    {
        if(_isWallSticked && !_isGrounded )
        {
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -slideSpeed, float.MaxValue));
        }
    }
    
}

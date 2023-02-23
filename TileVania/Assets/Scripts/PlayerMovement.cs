using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2D;
    Animator animator;
    CapsuleCollider2D capsuleCollider2D;

    [Header("Movement")]
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    float defaultGravityScale;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        defaultGravityScale = rb2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void ClimbLadder()
    {
        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Climb")))
        {
            rb2D.gravityScale = defaultGravityScale;
            animator.SetBool("isClimbing", false);
            return;
        }
        rb2D.gravityScale = 0;
        Vector2 climbVelocity = new Vector2(rb2D.velocity.x, moveInput.y * climbSpeed);
        rb2D.velocity = climbVelocity;

        bool hasVerticalSpeed = Mathf.Abs(rb2D.velocity.y) > Mathf.Epsilon;
        animator.SetBool("isClimbing", hasVerticalSpeed);


    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!capsuleCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (value.isPressed)
        {
            rb2D.velocity += new Vector2(0f, jumpSpeed);

        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb2D.velocity.y);
        rb2D.velocity = playerVelocity;


        bool hasHorizontalSpeed = Mathf.Abs(rb2D.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", hasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool hasHorizontalSpeed = Mathf.Abs(rb2D.velocity.x) > Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            rb2D.transform.localScale = new Vector2(Mathf.Sign(rb2D.velocity.x), 1);
        }
    }
}

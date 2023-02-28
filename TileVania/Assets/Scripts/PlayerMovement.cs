using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2D;
    Animator animator;
    CapsuleCollider2D bodyCollider2D;
    BoxCollider2D feetCollider2D;

    bool isAlive = true;

    [Header("Movement")]
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] Vector2 deathKick = new Vector2(20f, 20f);
    float defaultGravityScale;

    [Header("Fire")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyCollider2D = GetComponent<CapsuleCollider2D>();
        feetCollider2D = GetComponent<BoxCollider2D>();
        defaultGravityScale = rb2D.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();
    }


    void Die()
    {
        if (bodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            isAlive = false;
            animator.SetTrigger("dying");
            rb2D.velocity = deathKick;
            FindObjectOfType<GameSession>().ProcessPlayerDeath();
        }
    }

    
    void ClimbLadder()
    {
        if (!feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climb")))
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
        if (!feetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")) || !isAlive) { return; }

        if (value.isPressed)
        {
            rb2D.velocity += new Vector2(0f, jumpSpeed);

        }
    }
    void OnFire(InputValue value){
        if(!isAlive){return;}
        Instantiate(bullet,gun.position,transform.rotation);
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

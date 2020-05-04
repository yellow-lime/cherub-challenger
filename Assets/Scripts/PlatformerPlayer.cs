using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    [Tooltip("Whether the gameObject is facing right.")]
    public bool facingRight;
    [Tooltip("Seconds left in the current level.")]
    public float runSpeed = 5f;
    public float jumpSpeed = 8f;
    [Tooltip("Horizontal control while in the air (0-1).")]
    public float airRunCoef = .5f;

    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rigidBody2D;
    public CapsuleCollider2D boxCollider2D;

    public LayerMask platformsLayerMask;

    // public int maxJumps = 1;
    // private int jumpsLeft;

    // Start is called before the first frame update
    void Start()
    {
        // jumpsLeft = maxJumps;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<CapsuleCollider2D>();
    }

    Vector3 up = Vector3.up;
    Vector3 right = Vector3.right;

    // Update is called once per frame
    void Update()
    {
        bool isGrounded = IsGrounded();
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
        animator.SetBool("isGrounded", isGrounded); // FIXME too suboptimal

        float jumpModifier = isGrounded ? 1 : airRunCoef;
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * runSpeed * jumpModifier;
        rigidBody2D.velocity = new Vector2(x, rigidBody2D.velocity.y);

        animator.SetFloat("speed", System.Math.Abs(x));
        

        if ((facingRight && x < 0) || (!facingRight && x > 0))
        {
            ChangeSpriteFacing(x);
        }
    }

    private void ChangeSpriteFacing(float x)
    {
        facingRight = !facingRight;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }

    public void Jump()
    {
        rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpSpeed);
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);
        Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}

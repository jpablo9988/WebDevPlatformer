using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] 
    private LayerMask platformLayerMask;
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    public Animator animator;
    private bool facingRight = true;

    private SpriteRenderer sprite;

    public UnityEvent OnLandEvent;
    private bool isGrounded;


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isGrounded = true;
    }

    public void OnLanding()
    {
        isGrounded = true;
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        /*
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/

        sprite.flipX = !facingRight;

    }

    public void MovePlayer (float direction)
    {
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (direction > 0f)
        {
            if (!facingRight)
            {
                Flip();
            }

            player.velocity = new Vector2(direction * speed, player.velocity.y);

        }
        else if (direction < 0f)
        {
            if (facingRight)
            {
                Flip();
            }

            player.velocity = new Vector2(direction * speed, player.velocity.y);

        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }
    public void PlayerJump()
    {
        player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        animator.SetBool("IsGrounded", false);
    }

    void Update()
    {
        player.constraints = RigidbodyConstraints2D.FreezeRotation;
        animator.SetFloat("Speed", Mathf.Abs(direction));
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f)
        {
            if (!facingRight)
            {
                Flip();
            }

            player.velocity = new Vector2(direction * speed, player.velocity.y);

        }
        else if (direction < 0f)
        {
            if (facingRight)
            {
                Flip();
            }

            player.velocity = new Vector2(direction * speed, player.velocity.y);

        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            animator.SetBool("IsGrounded", isGrounded);
        }
    }

}





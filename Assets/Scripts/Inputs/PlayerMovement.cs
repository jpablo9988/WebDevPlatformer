using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private Rigidbody2D player;
    public Animator animator;
    private bool facingRight = true;

    private SpriteRenderer sprite;

    public UnityEvent OnLandEvent;
    private bool isGrounded;
    [SerializeField]
    private AudioClip jumpSfx;

    private float ogSpeed, ogJumpSpeed;

    public MovementJoystick movementJoystick;

    [Header("Get Hit Settings (Impulse)")]
    [SerializeField]
    private float yMagnitude = 20f;
    [SerializeField]
    private float xMagnitude = 20f;
    [SerializeField]
    private float xMovementDeactiveTimer = 0.8f;

    private bool deactivateMovement = false;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        isGrounded = true;
        ogSpeed = speed;
        ogJumpSpeed = jumpSpeed;
    }

    public void OnLanding()
    {
        isGrounded = true;
        animator.SetBool("IsGrounded", isGrounded);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        sprite.flipX = !facingRight;

    }

    public void MovePlayer (float direction )
    {
        if (!deactivateMovement)
        {
            animator.SetFloat("Speed", Mathf.Abs(direction));
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
                //player.velocity = new Vector2(0, player.velocity.y);
            }
        }
    }
    public void PlayerJump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            animator.SetBool("IsGrounded", false);
            GameMaster.Instance.PlaySfx(jumpSfx);
        }
    }
    public void ResetSpeed()
    {
        speed = ogSpeed;
        jumpSpeed = ogJumpSpeed;
    }

    public void AdditiveSpeed(float speedAdd)
    {
        speed += speedAdd;
        jumpSpeed += speedAdd;
    }
    public SpriteRenderer GetRenderer()
    {
        return this.sprite;
    }

    public void ApplyImpulse(Vector2 EnemyPosition)
    {
        float xImpulse = this.xMagnitude, yImpulse = this.yMagnitude;
        // -- if x of enemy is > than yours
        if (EnemyPosition.x >= this.transform.position.x)
        {
            xImpulse *= -1;
        }
        if (EnemyPosition.y >= this.transform.position.y)
        {
            yImpulse *= -1;
        }
        Vector2 impulseVector = new (xImpulse, yImpulse);
        StartCoroutine(RestoreControlsOnTimer());
        player.AddForce(impulseVector, ForceMode2D.Impulse);
    }

    private IEnumerator RestoreControlsOnTimer()
    {
        deactivateMovement = true;
        yield return new WaitForSeconds(xMovementDeactiveTimer);
        deactivateMovement = false;
    }

}





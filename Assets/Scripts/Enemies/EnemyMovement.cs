using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("General Settings")]
    [Tooltip("How long does it take to jump again")]
    [SerializeField]
    private float jumpCooldownTimer = 1.0f;
    [Tooltip("Will it flip the sprite considering its X velocity?")]

    [Header("Physics")]
    [SerializeField]
    private float speed = 5f, seekingSpeed = 10f, jumpForce = 100f;


    [SerializeField] 
    Vector3 startOffset;

    [Tooltip("Offset for collider which will check if it's grounded.")]
    [SerializeField]
    private float jumpCheckOffset = 0.1f;

    [Header("Dependencies")]
    [SerializeField] private RaycastHit2D isGrounded;
    private Animator _anim;
    // --- Privates --- //
    private Rigidbody2D rb;
    private bool isInAir, isOnCooldown;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isInAir = false;
        isOnCooldown = false;
    }
    /** Recieves a normalized direction ...
     */
    public void MoveToDirection(Vector2 direction, bool isSeeking)
    {
        if (direction.magnitude >= 0.2)
        {
            _anim.SetBool("IsMoving", true);
            if (isSeeking)
            {
                _anim.SetBool("SpotPlayer", true);
            }
        }
        else
        {
            _anim.SetBool("IsMoving", false);
            if (isSeeking)
            {
                _anim.SetBool("SpotPlayer", false);
            }
        }
        Vector2 force;
        if (isSeeking)
        {
            force = direction * seekingSpeed;
        }

        else
        {
            force = direction * speed;
        }
        // Movement
        rb.velocity = new Vector2(force.x, rb.velocity.y);
    }
    public void Jump()
    {
        startOffset = transform.position - new Vector3(0f, GetComponent<Collider2D>().bounds.extents.y + jumpCheckOffset, transform.position.z);
        isGrounded = Physics2D.Raycast(startOffset, -Vector3.up, 0.05f);
        if (isGrounded && !isInAir && !isOnCooldown)
        {
            if (isInAir) return;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(JumpCoolDown());
        }
        if (isGrounded)
        {
            isInAir = false;
        }
        else
        {
            isInAir = true;
        }
    }
    public void SwitchDirection()
    {
        if (rb.velocity.x > 0.05f)
        {
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (rb.velocity.x < -0.05f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    IEnumerator JumpCoolDown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(jumpCooldownTimer);
        isOnCooldown = false;
    }

}

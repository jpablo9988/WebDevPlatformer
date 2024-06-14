using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private LayerMask platformLayerMask;
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;
    public Animator animator;
    private bool facingRight = true;
    private BoxCollider2D boxCollider;

    public UnityEvent OnLandEvent;


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    


    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }




    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(direction));

        player.constraints = RigidbodyConstraints2D.FreezeRotation;



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
        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
            animator.SetBool("IsJumping", true);
        }
    }

}





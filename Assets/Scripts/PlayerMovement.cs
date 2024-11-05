using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Object to initialize 
    PlayerControls controls;

    float direction = 0;
    public float jumpForce = 5;
    int numberOfJumps = 0;
    public float speed = 200;
    public bool isFacingRight = true;
    bool isGrounded;

    public Rigidbody2D playerRB;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public Animator animator;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();
        //ctx is a context variable 
        controls.Land.Move.performed += ctx =>
        {
            //When move action is performed 
            //direction will be called 
            //ctx.ReadValue will return 1 for D, -1 for A if we release keys it will return 0
            direction = ctx.ReadValue<float>();
        };
        controls.Land.Jump.performed += ctx => Jump();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //When direction is 1 player will move right 
        //When directoion is -1 player will move left 
        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));
        if (isFacingRight && direction < 0 || !isFacingRight && direction > 0)
            Flip();

        //This helps check when the player has landed
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    //Debug.Log("Player Jump"); to test code
    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            numberOfJumps++;
            AudioManager.instance.Play("FirstJump");

        }
        else
        {
            if (numberOfJumps == 1)
            {
                playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
                numberOfJumps++;
                AudioManager.instance.Play("SecondJump");
            }
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }
}

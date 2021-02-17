using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float walkSpeed = 5f;
    private float jumpSpeed = 5f;

    private Rigidbody2D playerRBody;
    private BoxCollider2D playerBoxCollider2D;

    private Animator playerAnimator;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerRBody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerBoxCollider2D = GetComponent<BoxCollider2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipPlayer();
        Jump();
    }

    void Run()
    {
        float inputValue = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(inputValue * walkSpeed, playerRBody.velocity.y);
        playerRBody.velocity = playerVelocity;

        bool isPlayerMoving = Mathf.Abs(playerRBody.velocity.x) > 0;
        playerAnimator.SetBool("isWalking",isPlayerMoving);
    }

    void Jump()
    {
        if (!playerBoxCollider2D.IsTouchingLayers(LayerMask.GetMask("UI")) )
        {
            playerAnimator.SetBool("isJumping",false);
            return;
        }

        if (Input.GetKeyDown("space") && (player.transform.position.y > -3.5) && player.transform.position.y < -2.5)
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            playerRBody.velocity += jumpVelocity;
            playerAnimator.SetBool("isJumping",true);
        }
    }

    void FlipPlayer()
    {
        bool isPlayerMoving = Mathf.Abs(playerRBody.velocity.x) > 0;
        if (isPlayerMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(playerRBody.velocity.x), 1f);
        }
    }
}

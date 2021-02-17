using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 5f;

    private Rigidbody2D playerRBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FlipPlayer();
    }

    void Run()
    {
        float inputValue = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(inputValue * speed, playerRBody.velocity.y);
        playerRBody.velocity = playerVelocity;
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

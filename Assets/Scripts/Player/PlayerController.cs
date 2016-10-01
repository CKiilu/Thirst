using UnityEngine;
using System.Collections;

public class PlayerController: MonoBehaviour {

    public static bool overrideMovementLock = true;

    public float jumpHeight, speed;
    public bool movementLockValue;

    private Animator playerAnimator;
    private Rigidbody2D player;
    private bool grounded = true, dead = false;

    
	void Start () {
        overrideMovementLock = movementLockValue;
        player = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponentInChildren<Animator>();
    }

	
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (MonologueManager.playerMove || overrideMovementLock)
        {
            Move(moveHorizontal, 0);
            if (grounded && moveVertical > 0)
            {
                Jump();
                playerAnimator.SetBool("isWalking", false);
            }

            if (player.velocity.y == 0 && !grounded)
            {
                setGrounded(true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            dead = true;
        }
    }



    void Move(float moveHorizontal, float moveVertical)
    {
        // Player is walking if horizontal vector is not zero
        playerAnimator.SetBool("isWalking", (moveHorizontal != 0));
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        player.AddForce(movement * speed);
    }

    void Jump()
    {
        player.AddForce(Vector3.up * jumpHeight);
        setGrounded(false);
    }

    void setGrounded(bool val)
    {
        grounded = val;
    }

    public bool Dead()
    {
        return dead;
    }
}

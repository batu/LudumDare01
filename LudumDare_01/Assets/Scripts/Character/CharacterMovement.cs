using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 1f;

    [Header("Jump Related Variables")]
    [Range(0, 10)]
    public float jumpVelocity = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float groundedSkin = 0.05f;
    public float acmeTime = 0.05f;

    public LayerMask playerMask;
    bool grounded = true;

    Vector2 playerSize;
    Vector2 boxSize;


    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x + acmeTime, groundedSkin);
    }

    // Update is called once per frame


    protected Vector2 targetVelocity;



    void Update() {
        //Key input

        if (Input.GetButtonDown("Jump") && grounded) {
            grounded = false;
            Jump();
        } else {
            Vector2 centerPoint = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) /2f;
            grounded = Physics2D.OverlapBox(centerPoint, boxSize, 0, playerMask) != null;
        }
    }

    void FixedUpdate() {

        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");

        targetVelocity = move * maxSpeed * Time.deltaTime;
        Move(targetVelocity);


        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.03f) : (move.x < -0.03f));
        if (flipSprite) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        // Adjust jump fall.
        if (rb.velocity.y < 0) {
            rb.gravityScale = fallMultiplier;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.gravityScale = lowJumpMultiplier;
        } else {
            rb.gravityScale = 1;
        }
    }

    void Jump() {
        rb.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
    }
    void Move(Vector2 move) {
        rb.position = rb.position + move;
        return;
    }

}

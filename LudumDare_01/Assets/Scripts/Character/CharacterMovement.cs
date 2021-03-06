﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public float maxSpeed = 1f;

    public float jumpBonusMultiplier = 0f;

    
    public bool hasBag = false;

    // idle, side
    public Sprite[] noBagSprites;

    // left idle side
    public Sprite[] BagSprites;

    public ParticleSystem jumpParticles;
    [Header("Jump Related Variables")]
    [Range(0, 10)]
    public float jumpVelocity = 5f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float groundedSkin = 0.05f;
    public float acmeTime = -0.05f;

    public LayerMask playerMask;
    bool grounded = true;

    Vector2 playerSize;
    Vector2 playerScale;

    Vector2 boxSize;


    Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerScale = new Vector2(transform.localScale.x, transform.localScale.y);
        playerSize = GetComponent<BoxCollider2D>().size;
        boxSize = new Vector2(playerSize.x * playerScale.x + acmeTime, groundedSkin);
    }

    // Update is called once per frame


    protected Vector2 targetVelocity;

    void OnDrawGizmos() {
        //Vector2 centerPoint = (Vector2)transform.position + Vector2.down * (playerSize.y + boxSize.y) / 2f;
        //Gizmos.DrawCube(centerPoint, boxSize);
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && grounded) {
            grounded = false;
            Jump();
        } else {
            Vector2 centerPoint = (Vector2)transform.position + Vector2.down * (playerSize.y * playerScale.y + boxSize.y) /2f;
            grounded = Physics2D.OverlapBox(centerPoint, boxSize, 0, playerMask) != null;
        }
    }


    void UpdateSprite(Vector2 move) {
        if (!hasBag) {
            if (move.x > 0.05f) {
                spriteRenderer.sprite = noBagSprites[1];
                spriteRenderer.flipX = false;
            } else if (move.x < -0.05f) {
                spriteRenderer.sprite = noBagSprites[1];
                spriteRenderer.flipX = true;
            } else {
                spriteRenderer.sprite = noBagSprites[0];
                spriteRenderer.flipX = false;
            }
        } 

        if (hasBag) {
            if (move.x > 0.05f) {
                spriteRenderer.sprite = BagSprites[2];
            } else if (move.x < -0.05f) {
                spriteRenderer.sprite = BagSprites[0];
            } else {
                spriteRenderer.sprite = BagSprites[1];
            }
        }
    }

    void AdjustJump() {
        if (rb.velocity.y < 0) {
            rb.gravityScale = fallMultiplier;
        } else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) {
            rb.gravityScale = lowJumpMultiplier;
        } else {
            rb.gravityScale = 1;
        }
    }

    void FixedUpdate() {

        Vector2 move = Vector2.zero;
        move.x = Input.GetAxis("Horizontal");
        targetVelocity = move * maxSpeed * Time.deltaTime;

        Move(targetVelocity);
        UpdateSprite(move);
        AdjustJump();
    }

    void Jump() {
        rb.AddForce(Vector2.up * (jumpVelocity + jumpBonusMultiplier) , ForceMode2D.Impulse);
        jumpParticles.Stop();
        jumpParticles.Play();
    }

    void Move(Vector2 move) {
        rb.position = rb.position + move;
        return;
    }

    public void pickUpBag() {
        spriteRenderer.flipX = false;
    }
}

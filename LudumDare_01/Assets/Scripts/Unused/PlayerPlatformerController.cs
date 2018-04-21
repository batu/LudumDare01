using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Awake() {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    Vector2 move = Vector2.zero;
    protected override void ComputeVelocity() {
        move = rb2d.velocity;

        move.x = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp("Jump")) {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
        if (flipSprite) {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }


        targetVelocity = move * maxSpeed;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGame : Clickable {

    ParticleSystem plusones;
    public float turnSpeed = 1f;
    Rigidbody2D rb;

    public override void Click() {
        rb.AddTorque(turnSpeed, ForceMode2D.Force);
        plusones.Stop();
        plusones.Play();
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        plusones = transform.GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        GameManager.Instance.tapGameValueUpdate(rb.angularVelocity);
	}
}

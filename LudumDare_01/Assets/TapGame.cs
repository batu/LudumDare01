using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapGame : Clickable {

    public float turnSpeed = 1f;
    Rigidbody2D rb;

    public override void Click() {
        print("ok..");
        rb.AddTorque(turnSpeed, ForceMode2D.Force);
    }

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUpdate : MonoBehaviour {

    
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "BallHead") {
            GameManager.Instance.swingGameValueUpdate();
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

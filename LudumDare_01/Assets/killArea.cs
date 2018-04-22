using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killArea : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            GameManager.Instance.GameOver();
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

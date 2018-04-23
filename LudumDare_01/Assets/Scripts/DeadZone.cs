using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadZone : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}


    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Player") {
            SceneManager.LoadScene(1);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}

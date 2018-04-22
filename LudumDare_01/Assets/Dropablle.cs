using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropablle : MonoBehaviour {


    public float dropabbleTime = 2f;
    GameObject particleEffect;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            particleEffect.SetActive(true);
            Destroy(gameObject, dropabbleTime);
        }
    }
	// Use this for initialization
	void Start () {
        particleEffect = transform.parent.GetChild(0).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

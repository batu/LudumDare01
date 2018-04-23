using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateDeadZone : MonoBehaviour {


    public GameObject deadZone;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.tag == "Player") {
            GameManager.Instance.transform.GetComponent<CameraMover>().enabled = true;
            GameManager.Instance.started = true;
            deadZone.SetActive(true);
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationUpdate : MonoBehaviour {

    ParticleSystem plusones;
    Transform swirly;
    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "BallHead") {
            GameManager.Instance.swingGameValueUpdate();
            plusones.Stop();
            plusones.Play();
        }
    }

	// Use this for initialization
	void Start () {
        swirly = transform.parent.GetChild(1);
        plusones = swirly.GetComponentInChildren<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = swirly.transform.position + new Vector3(0, 1, 0);
    }
}

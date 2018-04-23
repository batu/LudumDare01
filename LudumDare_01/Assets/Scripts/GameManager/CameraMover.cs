using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
   
    public float cameraMoveSpeed = 1f;

    public float maxDistanceTreshold = 25f;
    public float baseCameraMoveSpeed;
    bool cameraStarted = true;

    Transform playerT;
    Transform deadZone;
    Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        baseCameraMoveSpeed = cameraMoveSpeed;
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
        deadZone = GameObject.FindGameObjectWithTag("DeadZone").transform;
        rb = playerT.gameObject.GetComponent<Rigidbody2D>();
    }

    void MoveCameraUp() {
        float distance = Mathf.Abs(playerT.position.y - deadZone.position.y);
        if (distance > maxDistanceTreshold && rb.velocity.y >= 0) {
            Camera.main.transform.Translate(Vector3.up * cameraMoveSpeed * 3 *Time.deltaTime);
        } else {
            Camera.main.transform.Translate(Vector3.up * cameraMoveSpeed * Time.deltaTime);
        }

    }
	// Update is called once per frame
	void FixedUpdate () {
		if (cameraStarted) {
            MoveCameraUp();
        }
	}
}

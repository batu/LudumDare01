using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {

    public float cameraMoveSpeed = 1f;

    public float baseCameraMoveSpeed;
    bool cameraStarted = true;
	// Use this for initialization
	void Start () {
        baseCameraMoveSpeed = cameraMoveSpeed;
    }
	
    void MoveCameraUp() {
        Camera.main.transform.Translate(Vector3.up * cameraMoveSpeed * Time.deltaTime);
    }
	// Update is called once per frame
	void FixedUpdate () {
		if (cameraStarted) {
            MoveCameraUp();
        }
	}
}

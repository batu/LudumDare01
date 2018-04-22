using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagPickup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col) {
        if(col.collider.tag == "Player") {
            col.gameObject.GetComponent<CharacterMovement>().hasBag = true;
            col.gameObject.GetComponent<CharacterMovement>().pickUpBag();
            secondCam.GetComponent<Camera>().nearClipPlane = 0.3f;
            Destroy(gameObject);
        }
    }

    public GameObject secondCam;

}

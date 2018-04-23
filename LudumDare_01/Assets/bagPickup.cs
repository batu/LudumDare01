using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bagPickup : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D col) {
        if(col.collider.tag == "Player") {
            col.gameObject.GetComponent<CharacterMovement>().hasBag = true;
            col.gameObject.GetComponent<CharacterMovement>().pickUpBag();
            secondCam.GetComponent<Camera>().nearClipPlane = 0.3f;
            StartCoroutine(camSlide());



        }
    }


    IEnumerator camSlide() {

        Camera cam = Camera.main;
        
        while (cam.rect.width > 0.5f) {

            cam.rect = new Rect(0f, 0f, cam.rect.width - 0.01f, 1f);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
    public GameObject secondCam;

}

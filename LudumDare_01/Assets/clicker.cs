using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clicker : MonoBehaviour {

    public LayerMask clickAble;

    RaycastHit2D hit;
    Vector2 MousePosition;
    Vector2 objPosition;

    Camera secondCamera;

    void Start() {
        secondCamera = GameObject.FindGameObjectWithTag("SecondCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {

            Debug.DrawRay(secondCamera.ScreenPointToRay(Input.mousePosition).origin,
                                 secondCamera.ScreenPointToRay(Input.mousePosition).direction * 1000, Color.red, 1000);

            hit = Physics2D.Raycast(secondCamera.ScreenPointToRay(Input.mousePosition).origin,
                                 secondCamera.ScreenPointToRay(Input.mousePosition).direction, 1000, clickAble);
            if (hit) {

                GameObject go = hit.transform.gameObject;
                Clickable clickable = go.GetComponent<Clickable>();
                clickable.Click();
            }
        }
    }
}

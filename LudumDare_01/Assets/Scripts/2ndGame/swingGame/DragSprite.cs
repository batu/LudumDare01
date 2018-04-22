using UnityEngine;

public class DragSprite : MonoBehaviour {

    public LayerMask twirlAble;
    public GameObject ballHead;


    Camera secondCamera;
    public float maxDistanceTolerance = 0.1f;
    float maxDistance;
    Rigidbody2D ballHead_rb;
    void Start () {
        maxDistance = Vector3.Distance(transform.position, ballHead.transform.position);
        secondCamera = GameObject.FindGameObjectWithTag("SecondCamera").GetComponent<Camera>();
        ballHead_rb = ballHead.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public float dragForce = 10f;
    Rigidbody2D rb = null;
    bool active = false;
    RaycastHit2D hit;
    Vector2 MousePosition;
    Vector2 objPosition;

    public float smoothSpeed = 0.5f;
    void LateUpdate() {
        if (objPosition != Vector2.zero) {
            Vector3 desiredPosition = objPosition;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }

    }

    
    void UpdateMaxDistance() {
        float current_distance = Vector3.Distance(transform.position, ballHead.transform.position);
        if (current_distance > maxDistance + maxDistanceTolerance) {
            Vector2 direction = (ballHead.transform.position - transform.position).normalized;
            Vector2 curr_position = transform.position;
            ballHead_rb.MovePosition(curr_position + direction * maxDistance);
        }
    }
    void FixedUpdate() {
        //UpdateMaxDistance();
    }

    void Update() {


        if (Input.GetMouseButton(0)) {
            hit = Physics2D.Raycast(secondCamera.ScreenPointToRay(Input.mousePosition).origin,
                                 secondCamera.ScreenPointToRay(Input.mousePosition).direction, 1000, twirlAble);
            if (hit) {
                active = true;
                if (!rb)
                    rb = hit.transform.gameObject.GetComponent<Rigidbody2D>();
            }

        }

        if (active) {
            MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            objPosition = secondCamera.ScreenToWorldPoint(MousePosition);

            

            rb.constraints = RigidbodyConstraints2D.None;
            rb.AddForce((objPosition - (Vector2)transform.position).normalized * dragForce, ForceMode2D.Impulse);
        }


        // Make sure the user pressed the mouse down
        if (Input.GetMouseButtonUp(0)) {
            active = false;
            if (rb && rb.constraints == RigidbodyConstraints2D.None) {
                rb.constraints = RigidbodyConstraints2D.FreezePosition;
            }
        }

    }
}

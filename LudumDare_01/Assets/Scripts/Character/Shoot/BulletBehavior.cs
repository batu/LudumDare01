using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletBehavior : MonoBehaviour {

    public float lifeLength;
    public float bulletSpeed;

    Rigidbody2D rb;



    void fireBullet() {
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(killBullet(lifeLength));
    }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        fireBullet();
    }

    void OnCollisionEnter2D(Collision2D col) {

        if (col.collider.tag == "Breakable") {
            col.collider.gameObject.GetComponent<Breakable>().takeDamage();
        }
        if(col.transform.tag != "Player")
            StartCoroutine(killBullet(0f));
    }

    IEnumerator killBullet(float time){
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

}

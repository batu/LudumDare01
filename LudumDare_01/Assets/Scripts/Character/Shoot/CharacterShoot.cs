using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShoot : MonoBehaviour {


    public GameObject bulletPrefab;
    Transform gunLocationTransform;

    public void Shoot() {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, gunLocationTransform.position, Quaternion.identity, gunLocationTransform);
    }

	// Use this for initialization
	void Awake() {
        if (bulletPrefab == null)
            bulletPrefab = GameObject.FindGameObjectWithTag("Bullet");
        gunLocationTransform = GameObject.FindGameObjectWithTag("GunPoint").transform;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

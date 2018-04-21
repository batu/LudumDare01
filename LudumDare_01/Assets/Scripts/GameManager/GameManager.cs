using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    GameObject player;

    CharacterShoot characterShoot;
    CharacterMovement characterMovement;
    private void Awake() {

        player = GameObject.FindGameObjectWithTag("Player");
        characterShoot = player.GetComponent<CharacterShoot>();
        characterMovement= player.GetComponent<CharacterMovement>();
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    // Increases jump ability
    public void tapGameValueUpdate(float angularVelocity) {
        characterMovement.jumpBonusMultiplier = angularVelocity / 100f;

    }

    //Decreases the camera speed.
    public void swingGameValueUpdate() {

    }

    // Shoots a laser.
    public void quadGameSuccess() {
        characterShoot.Shoot();
    }

    public float spinGameScore;
    public float SwingerScore;
    public float tapScore;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

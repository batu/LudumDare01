using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    GameObject player;

    CameraMover cameraMover;
    CharacterShoot characterShoot;
    CharacterMovement characterMovement;

    public float SwingerScoreReductionTime = 2f;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
        cameraMover = GetComponent<CameraMover>();
        player = GameObject.FindGameObjectWithTag("Player");
        characterShoot = player.GetComponent<CharacterShoot>();
        characterMovement= player.GetComponent<CharacterMovement>();

        StartCoroutine(swingerReduce());
    }

    // Increases jump ability
    public void tapGameValueUpdate(float angularVelocity) {
        characterMovement.jumpBonusMultiplier = angularVelocity / 100f;

    }

    public IEnumerator swingerReduce() {
        while (true) {
            yield return new WaitForSeconds(SwingerScoreReductionTime);
            if (SwingerScore > 0) {
                SwingerScore--;
                cameraMover.cameraMoveSpeed = cameraMover.baseCameraMoveSpeed * (1 / (SwingerScore + 1));
            }
        }

    }
    //Decreases the camera speed.
    public void swingGameValueUpdate() {
        SwingerScore++;
        cameraMover.cameraMoveSpeed = cameraMover.baseCameraMoveSpeed * (1 / (SwingerScore + 1));

    }

    // Shoots a laser.
    public void quadGameSuccess() {
        characterShoot.Shoot();
    }
    
    public float SwingerScore = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

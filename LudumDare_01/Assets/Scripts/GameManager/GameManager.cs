using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    GameObject player;

    CameraMover cameraMover;
    CharacterShoot characterShoot;
    CharacterMovement characterMovement;

    [Header("Click Features.")]
    public float maxJumpBonus = 6f;
    public float normalizeAmount = 100f;
    public ParticleSystem goldClickerPS;
    public ParticleSystem jumpParticles;

    [Header("SwingerFeatures.")]
    public float SwingerScoreReductionTime = 4f;
    [HideInInspector]
    public float SwingerScore = 0;
    public ParticleSystem redSwingerPS;
    public ParticleSystem redDeadZonePS;

    public bool started = false;
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
        float normalizedRotation = Mathf.Clamp(angularVelocity / normalizeAmount, 0, maxJumpBonus);
        characterMovement.jumpBonusMultiplier = normalizedRotation;
        ParticleSystem.EmissionModule emissionModule = goldClickerPS.emission;
        emissionModule.rateOverTime = (Mathf.Clamp(normalizedRotation - 3, 0, 3) * 200);

        ParticleSystem.EmissionModule emissionModule_jump = jumpParticles.emission;
        emissionModule_jump.burstCount = (int) (Mathf.Clamp(normalizedRotation, 0, 6));
    }

    public IEnumerator swingerReduce() {
        while (true) {
            yield return new WaitForSeconds(SwingerScoreReductionTime);
            if (SwingerScore > 0) {
                SwingerScore--;
                cameraMover.cameraMoveSpeed = cameraMover.baseCameraMoveSpeed * (1 - (SwingerScore / 6));

                ParticleSystem.EmissionModule emissionModule = redSwingerPS.emission;
                emissionModule.rateOverTime = (Mathf.Clamp(SwingerScore, 0, 5) * 30);

                ParticleSystem.EmissionModule emissionModule_dz = redDeadZonePS.emission;
                emissionModule_dz.rateOverTime = (5 - Mathf.Clamp(SwingerScore, 0, 5)) * 30;
            }
        }

    }
    //Decreases the camera speed.
    public void swingGameValueUpdate() {
        if (started) {
            SwingerScore++;
            SwingerScore = Mathf.Clamp(SwingerScore, 0, 5);
            cameraMover.cameraMoveSpeed = cameraMover.baseCameraMoveSpeed * (1 - (SwingerScore / 6));
            ParticleSystem.EmissionModule emissionModule = redSwingerPS.emission;
            emissionModule.rateOverTime = (Mathf.Clamp(SwingerScore, 0, 5) * 30);


            ParticleSystem.EmissionModule emissionModule_dz = redDeadZonePS.emission;
            emissionModule_dz.rateOverTime = (5 - Mathf.Clamp(SwingerScore, 0, 5)) * 30;
        }
        
    }

    // Shoots a laser.
    public void quadGameSuccess() {
        characterShoot.Shoot();
    }
    

    public void GameOver() {
        
        SceneManager.LoadScene(1);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    public AudioSource crashChar;
    public GameObject mainCamera;
    public GameObject levelControl;
    public GameObject animator;
    [SerializeField] GameObject shield;

    private PlayerMovement playerMovement;
    private DistanceCounter distanceCounter;
    private GenerateLevel generateLevel;
    private EndRunSequence endRunSequence;
    private Animator cameraAnimator;

    void Start()
    {
        crashChar = GameObject.Find("LevelControl/CrashChar").GetComponent<AudioSource>();
        mainCamera = GameObject.Find("/Player(Clone)/Camera");
        levelControl = GameObject.Find("LevelControl");
        playerMovement = GetComponent<PlayerMovement>();
        distanceCounter = levelControl.GetComponent<DistanceCounter>();
        generateLevel = levelControl.GetComponent<GenerateLevel>();
        endRunSequence = levelControl.GetComponent<EndRunSequence>();
        
    }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy") && !shield.activeSelf)
            {


                playerMovement.enabled = false;


                distanceCounter.enabled = false;
                generateLevel.enabled = false;
                endRunSequence.enabled = true;


                if (crashChar != null)
                    crashChar.Play();


                if (animator != null)
                    animator.GetComponent<Animator>().Play("Stumble Backwards");


            }
        }
    
}

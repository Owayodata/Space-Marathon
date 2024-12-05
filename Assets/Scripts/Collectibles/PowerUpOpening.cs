using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpOpening : MonoBehaviour
{
    [SerializeField] private GameObject powerUp;
    [SerializeField] private AudioSource powerUpSFX;

    private void OnTriggerEnter(Collider collision)
    {
        if (!powerUp.activeSelf)
        {
            powerUpSFX.Play();
            powerUp.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerUpButtonBehavior : MonoBehaviour
{
    public GameObject fireballTransform;
    public GameObject SpeedBTN;
    public GameObject rbodyCollider;
    public GameObject shield;
    
    
    
   

    private void Update()
    {
        fireballTransform = GameObject.Find("Player(Clone)/InsTransformLocation");
        rbodyCollider = GameObject.Find("Player(Clone)");
        shield = GameObject.Find("CharController/Player(Clone)/Shield");
        
    }

    public void instantiateCaller(GameObject fireball)
    {
        
        Instantiate(fireball, fireballTransform.transform.position, fireballTransform.transform.rotation);
    }

    public void speedUp()
    {
        if (PlayerMovement.isGrounded == true)
            StartCoroutine(speedUpRoutine());
    }

    IEnumerator speedUpRoutine()
    {
        rbodyCollider.GetComponent<BoxCollider>().enabled = false;
        shield.gameObject.SetActive(true);

        // Store the original movement speed
        float originalSpeed = PlayerMovement.movementSpeed;

        // Increase the movement speed by a factor of 2, but not exceeding 10
        PlayerMovement.movementSpeed = Mathf.Min(PlayerMovement.movementSpeed * 2f, 12f);

        yield return new WaitForSeconds(5);

        // Restore the original movement speed
        shield.GetComponent<Animator>().enabled = true;
        PlayerMovement.movementSpeed = originalSpeed;

        yield return new WaitForSeconds(2);
        rbodyCollider.GetComponent<BoxCollider>().enabled = true;
        shield.GetComponent<Animator>().enabled = false;
        shield.gameObject.SetActive(false);
        SpeedBTN.gameObject.SetActive(false);
    }


}

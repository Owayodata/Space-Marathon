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
        
        if(PlayerMovement.isGrounded == true)
        StartCoroutine(speedUpRoutine());
        
        


        IEnumerator speedUpRoutine()
        {
           
            rbodyCollider.GetComponent<Rigidbody>().useGravity = false;
            rbodyCollider.GetComponent<BoxCollider>().enabled = false;
            PlayerMovement.isGrounded = false;
            shield.gameObject.SetActive(true);
            PlayerMovement.movementSpeed *= 2f;

            yield return new WaitForSeconds(5);
            shield.GetComponent<Animator>().enabled = true;
            PlayerMovement.movementSpeed = 7f;

            yield return new WaitForSeconds(2);
            PlayerMovement.isGrounded = true;
            rbodyCollider.GetComponent<Rigidbody>().useGravity = true;
            rbodyCollider.GetComponent<BoxCollider>().enabled = true;
            shield.GetComponent<Animator>().enabled = false;
            shield.gameObject.SetActive(false);
            SpeedBTN.gameObject.SetActive(false);
        }
    }

}

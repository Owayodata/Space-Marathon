using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PowerUpButtonBehavior : MonoBehaviour
{
    public GameObject fireballTransform;

    private void Update()
    {
        fireballTransform = GameObject.Find("Player(Clone)/InsTransformLocation");
    }

    public void instantiateCaller(GameObject fireball)
    {
        Instantiate(fireball, fireballTransform.transform.position, fireballTransform.transform.rotation);



    }
}

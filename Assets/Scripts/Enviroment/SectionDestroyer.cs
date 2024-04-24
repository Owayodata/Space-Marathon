using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDestroyer : MonoBehaviour
{

    public GameObject Section;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(Section, 3);
            Debug.Log("Collision Worked...");
        }
    }
}

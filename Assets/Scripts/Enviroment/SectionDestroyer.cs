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
            
            Debug.Log("Section will be destroyed in 3 seconds...");

            
            Invoke(nameof(DeactivateSection), 3f);
        }
    }

    void DeactivateSection()
    {
        Section.SetActive(false); 
        Debug.Log("Section Destroyed...");
    }
}

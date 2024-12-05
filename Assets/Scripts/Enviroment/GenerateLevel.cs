using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] sections; 
    public int zPos = 50; 
    public int sectionSpacing = 50; 
    public float generationInterval = 4.2f; 
    private Queue<GameObject> sectionPool; 
    public int poolSize = 10; 

    void Start()
    {
        // start object pooling
        sectionPool = new Queue<GameObject>();
        InitializePool();

        // create section parts periodically
        InvokeRepeating(nameof(GenerateSection), 0f, generationInterval);
    }

    void InitializePool()
    {
        // create objects for pool and save them in queue
        for (int i = 0; i < poolSize; i++)
        {
            int randomIndex = Random.Range(0, sections.Length);
            GameObject section = Instantiate(sections[randomIndex], Vector3.zero, Quaternion.identity);
            section.SetActive(false); // Kullanýlmayan nesneleri devre dýþý býrak
            sectionPool.Enqueue(section);

            // add SectionDestroyer script to every piece
            SectionDestroyer destroyer = section.AddComponent<SectionDestroyer>();
            destroyer.Section = section;
        }
    }

    void GenerateSection()
    {
        // take object from pool, create if there is none
        GameObject section = sectionPool.Dequeue();
        section.SetActive(true); // activate object
        section.transform.position = new Vector3(0, 0, zPos); // adjust new position
        zPos += sectionSpacing;

        // Reactivate all child objects
        foreach (Transform child in section.transform)
        {
            child.gameObject.SetActive(true);
        }

        // add to queue (for reusing)
        sectionPool.Enqueue(section);
    }

}

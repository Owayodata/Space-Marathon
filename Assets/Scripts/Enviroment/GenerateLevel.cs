using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    
    public GameObject[] section;
    public int zPos = 50;
    public bool creatingSection = false;
    public int secNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creatingSection == false)
        {
            creatingSection = true;
            StartCoroutine(generateSection());
        }
    }
    IEnumerator generateSection()
    {
        secNum = Random.Range(0, 7);
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        yield return new WaitForSeconds(3);
        creatingSection = false;

    }
}

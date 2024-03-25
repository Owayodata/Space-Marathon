using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceCounter : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    public int disRun;
    public bool addingDis = false;

    // Update is called once per frame
    void Update()
    {
        if(addingDis == false)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }

        IEnumerator AddingDis()
       {
            disRun += 1;
            disDisplay.GetComponent<TMP_Text>().text = "" + disRun;
            disEndDisplay.GetComponent<TMP_Text>().text = "" + disRun;
            yield return new WaitForSeconds(0.25f);
            addingDis = false;
       }
    }
}

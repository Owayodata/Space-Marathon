using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectingCoins : MonoBehaviour
{
    public AudioSource coinFX;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinFX.Play();
            CollectableScore.CoinCount += 1;
            this.gameObject.SetActive(false);
        }

    }
}

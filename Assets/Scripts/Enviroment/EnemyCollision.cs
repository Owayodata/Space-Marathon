using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private int Dammage;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(("Player")))
        {
            collider.GetComponent<Lives>().TakeDamage(Dammage);
        }
    }
}

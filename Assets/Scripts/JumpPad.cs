using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private int jumpForce;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == ("Player"))
        {
            Debug.Log("JumpPad");
            collider.GetComponent<CharController>().jump(jumpForce);
        }
    }
}

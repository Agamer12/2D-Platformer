using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform CurrentCheckpoint;
    private Lives Lives;
    private CharController player;

    private void Start()
    {
        Lives = GetComponent<Lives>();
        Console.WriteLine("test");
        player = GetComponent<CharController>();
    }

    public void Respawn()
    {
        player.rb.velocity = Vector2.zero;
        transform.position = CurrentCheckpoint.position;
        Lives.ResetHealth();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == ("Checkpoint"))
        {
            Lives.ResetHealth();
            Console.WriteLine("Checkpoint Set");
            CurrentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
        }
    }
}

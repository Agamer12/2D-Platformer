using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform _currentCheckpoint;
    private Lives _lives;
    private CharController _player;
    private AudioSource _audioSource;

    private void Start()
    {
        _lives = GetComponent<Lives>();
        _player = GetComponent<CharController>();
    }

    public void Respawn()
    {
        _player.rb.velocity = Vector2.zero;
        transform.position = _currentCheckpoint.position;
        _lives.ResetHealth();
    }
    public void PlayerReset()
    {
        transform.position = Vector3.zero;
        _lives.ResetHealth();
        _lives.points = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(("Checkpoint")))
        {
            _lives.ResetHealth();
            Console.WriteLine("Checkpoint Set");
            _currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("appear");
            _audioSource = collision.GetComponent<AudioSource>();
            _audioSource.Play();
        }
    }
}

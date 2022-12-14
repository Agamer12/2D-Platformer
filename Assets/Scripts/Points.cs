using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int value;

    private Collider2D colide;
    private Renderer render;
    private AudioSource coinSound;

    private void Start()
    {
        colide = GetComponent<Collider2D>();
        render = GetComponent<Renderer>();
        coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<Lives>().points += value;
            coinSound.Play();
            colide.enabled = false;
            render.enabled = false;

        }
    }
}

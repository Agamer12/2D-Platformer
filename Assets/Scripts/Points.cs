using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int value;

    private Collider2D _colide;
    private Renderer _render;
    private AudioSource _coinSound;

    private void Start()
    {
        _colide = GetComponent<Collider2D>();
        _render = GetComponent<Renderer>();
        _coinSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Lives>().points += value;
            _coinSound.Play();
            _colide.enabled = false;
            _render.enabled = false;

        }
    }
}

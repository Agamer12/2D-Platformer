using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int value;

    private Collider2D colide;
    private Renderer render;

    private void Start()
    {
        colide = GetComponent<Collider2D>();
        render = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.GetComponent<PointsDriver>().points += value;
            colide.enabled = false;
            render.enabled = false;

        }
    }
}

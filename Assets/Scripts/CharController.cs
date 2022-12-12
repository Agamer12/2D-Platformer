using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class CharController : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float boostSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] public LayerMask groundLayer;

    public Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private Lives Health;

    private float xInput;
    private float yInput;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Health = GetComponent<Lives>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.rotation = 50f;
        }

        while (transform.position.y < -20)
        {
            Health.TakeDamage(1);
        }

        //Move LR code
        if (!isOnWall())
        {
            rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        }

        //Jump code
        if (isGrounded() && (yInput > .1f || Input.GetKeyDown(KeyCode.Space)))
        {
            jump(jumpForce);
        }
    }
    
    public void jump(float _force)
    {
        rb.velocity = new Vector2(rb.velocity.x - .01f, _force);
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size * .9f, 0f, Vector2.down, .2f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool isOnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size * .9f, 0f, new Vector2(xInput, 0), .2f, groundLayer);
        return raycastHit.collider != null;
    }

}

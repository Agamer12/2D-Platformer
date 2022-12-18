using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CharController : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private float boostSpeed;
    [SerializeField] public float jumpForce;
    [SerializeField] public LayerMask groundLayer;

    public Rigidbody2D rb;
    private BoxCollider2D _boxCollider;
    private Lives _health;
    [SerializeField] private AudioSource JumpSound;

    private float _xInput;
    private float _yInput;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _health = GetComponent<Lives>();
    }

    // Update is called once per frame
    private void Update()
    {
        _xInput = Input.GetAxis("Horizontal");
        _yInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        while (transform.position.y < -20)
        {
            _health.TakeDamage(1);
        }

        //Move LR code
        if (!isOnWall())
        {
            rb.velocity = new Vector2(_xInput * speed, rb.velocity.y);
        }

        //Jump code
        if (IsGrounded() && (_yInput > .1f || Input.GetKeyDown(KeyCode.Space)))
        {
            Jump(jumpForce);
        }
    }

    public void Jump(float _force)
    {
        rb.velocity = new Vector2(rb.velocity.x - .01f, _force);
        JumpSound.Play();

    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size * .9f, 0f, Vector2.down, .2f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool isOnWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size * .9f, 0f, new Vector2(_xInput, 0), .2f, groundLayer);
        return raycastHit.collider != null;
    }

}

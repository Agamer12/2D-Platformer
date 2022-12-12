using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lives : MonoBehaviour
{

    [SerializeField] private int StartingLives = 3;
    [SerializeField] private float hurtJumpForce = 10f;
    private PlayerRespawn PlayerRespawn;

    private CharController Player;

    public int Deaths
    {
        get;
        private set;
    }
    public int CurrentHealth
    {
        get;
        private set;
    }

    // Start is called before the first frame update
    void Start()
    {
        Deaths = 0;
        CurrentHealth = StartingLives;
        Player = GetComponent<CharController>();
        PlayerRespawn = GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int _dammage)
    {
        if (CurrentHealth > 0)
        {
            CurrentHealth -= _dammage;
            Debug.Log("Lives: " + CurrentHealth);
            Player.jump(hurtJumpForce);
        }
        else
        {
            Debug.Log("Game Over");
            PlayerRespawn.Respawn();
            Deaths++;
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = StartingLives;
    }

}

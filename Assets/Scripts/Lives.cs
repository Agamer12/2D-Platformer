using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Lives : MonoBehaviour
{

    [SerializeField] private int StartingLives = 3;
    [SerializeField] private float hurtJumpForce = 10f;
    [SerializeField] private int DeathCost;

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
            Deaths++;
            points -= DeathCost;

            if (points >= 0)
            {
                PlayerRespawn.Respawn();
            }
            else
            {
                PlayerRespawn.PlayerReset();
            }
        }
    }

    public void ResetHealth()
    {
        CurrentHealth = StartingLives;
    }

    public int points
    {
        get;
        set;
    }
}

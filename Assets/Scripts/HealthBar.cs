using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private Lives playerLives;



    // Update is called once per frame
    private void Update()
    {
        healthBar.fillAmount = playerLives.CurrentHealth / 3f;
    }
}

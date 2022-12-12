using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{

    private TextMeshProUGUI deathsDisplay;
    [SerializeField] private Lives player;
    
    // Start is called before the first frame update
    void Start()
    {
        deathsDisplay = GetComponent<TextMeshProUGUI>();
        player.GetComponent<Lives>();
        deathsDisplay.text = "Deaths: " + player.Deaths;
    }
    
    // Update is called once per frame
    void Update()
    {
        deathsDisplay.text = "Deaths: " + player.Deaths;
    }
}

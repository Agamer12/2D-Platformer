using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{

    private TextMeshProUGUI _deathsDisplay;
    [SerializeField] private Lives player;
    
    // Start is called before the first frame update
    private void Start()
    {
        _deathsDisplay = GetComponent<TextMeshProUGUI>();
        player.GetComponent<Lives>();
        _deathsDisplay.text = "Deaths: " + player.Deaths;
    }
    
    // Update is called once per frame
    private void Update()
    {
        _deathsDisplay.text = "Deaths: " + player.Deaths;
    }
}

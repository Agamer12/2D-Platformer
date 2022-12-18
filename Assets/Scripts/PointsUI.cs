using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private Lives PlayerPoints;

    private TextMeshProUGUI _pointsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPoints.GetComponent<Lives>();
        _pointsDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _pointsDisplay.text = "Score: " + PlayerPoints.points;
    }
}

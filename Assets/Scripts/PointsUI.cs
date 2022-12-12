using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUI : MonoBehaviour
{
    [SerializeField] private PointsDriver PlayerPoints;
    private TextMeshProUGUI PointsDisplay;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPoints.GetComponent<PointsDriver>();
        PointsDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        PointsDisplay.text = "Score: " + PlayerPoints.points;
    }
}

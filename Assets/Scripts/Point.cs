using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Point : MonoBehaviour
{   
    private TextMeshProUGUI Points;
    // Start is called before the first frame update
    void Start()
    {
        Points=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        float totalPoints=Score.points;

        Points.text="Points :"+totalPoints;
    }
}

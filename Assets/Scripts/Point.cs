using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Point : MonoBehaviour
{   
    private TextMeshProUGUI Points;

    public float totalPoints;
    // Start is called before the first frame update
    void Start()
    {
        Points=GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        totalPoints=Score.points;

        Points.text="Points :"+PlayerPrefs.GetFloat("Points");
    }
    public void SavePoints(){
        PlayerPrefs.SetFloat("Points",Score.points);
    }
    public void LoadPoints()
    {
        Score.points = PlayerPrefs.GetFloat("Points");
    }
    public void ResetPoints(){
        PlayerPrefs.SetFloat("Points",0);
    }

}

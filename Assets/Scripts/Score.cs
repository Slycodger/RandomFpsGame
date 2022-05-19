using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{   
    public float AddScore;
    public TextMeshProUGUI SayScore;
    public static float points;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ScoreUp(int ScoreToAdd){
        AddScore+=ScoreToAdd;
        SayScore.text="Score:"+AddScore;
        points+=ScoreToAdd;
    }

}

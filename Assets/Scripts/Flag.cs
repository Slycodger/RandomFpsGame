using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{   
    public GameObject posAfterTouch;
    private Score score;
    public int points;
    // Start is called before the first frame update
    void Start()
    {
        score=GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.transform.position=posAfterTouch.transform.position;
            score.ScoreUp(points);
        }
    }
}

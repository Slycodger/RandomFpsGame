using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGoForward : MonoBehaviour
{   
    public float Speed;

    private Score AddScore;
    private Rigidbody rb;
    public bool isThereScore=false;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddRelativeForce(Vector3.forward*Speed,ForceMode.Impulse);
        Invoke("destroyBullet",15f);
        if(isThereScore){
        AddScore=GameObject.Find("Score").GetComponent<Score>();
        }
    }
    private void OnCollisionEnter(Collision other) {
        Speed=0f;
        if(other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject.gameObject);
            AddScore.ScoreUp(1);
            Speed=0f;
        }
    }

    public void destroyBullet(){
        Destroy(gameObject);
    }
}

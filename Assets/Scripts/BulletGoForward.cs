using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletGoForward : MonoBehaviour
{   

    private Score AddScore;
    private Rigidbody rb;
    public bool isThereScore=false;

    private GameManager GM;

    private int BulletNoCollision;
    // Start is called before the first frame update
    void Start()
    {   
        GM=GameObject.Find("GameManager").GetComponent<GameManager>();

        rb=GetComponent<Rigidbody>();

         BulletNoCollision=LayerMask.NameToLayer("BulletCollison");
    }

    // Update is called once per frame
    void Update()
    {   
        if(GM.Snipe){
            rb.useGravity=false;
        }
        if(GM.NoScope){
            rb.useGravity=false;
        }
        if(GM.Snipe){
        rb.AddRelativeForce(Vector3.forward*GM.speedOfShot);
        }
        if(GM.NoScope){
            rb.AddRelativeForce(Vector3.forward*GM.speedOfShot,ForceMode.Impulse);
        }
        Invoke("destroyBullet",15f);
        if(isThereScore){
        AddScore=GameObject.Find("Score").GetComponent<Score>();
        }
        if(GM.BulletCollision){
            gameObject.layer=BulletNoCollision;
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(rb.velocity.z>0){
            rb.AddForce(-rb.velocity);
        }
        
        if(other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject.gameObject);
            AddScore.ScoreUp(1);
        }
    }

    public void destroyBullet(){
        Destroy(gameObject);
    }
}

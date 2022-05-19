using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTowardsPlayer : MonoBehaviour
{
    private GameObject playerToGoTo;

    private GameManager gm;
    private Rigidbody rb;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {   
        playerToGoTo=GameObject.Find("Player");
        gm=GameObject.Find("GameManager").GetComponent<GameManager>();
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   if(gm.GoTowardsPlayer){
        Vector3 lookVector = playerToGoTo.transform.position - transform.position;
         lookVector.y = transform.position.y;
         Quaternion rot = Quaternion.LookRotation(lookVector);
         transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
         rb.AddRelativeForce(-Vector3.up*speed*Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{   
    public float speed;
    public float jump_force;
    public float sensitivity;

    public Transform playerBody;

    private Rigidbody rb;
    public bool grounded=true;
    float xRotation;
    public GameObject gameover;
    public Ammo stopShoot;
    public bool Gameover;
    public GameObject escape;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible=false;
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {   
       if(Gameover){
           gameover.SetActive(true);
       } 
       if(!Gameover){ 
       float mouseX = Input.GetAxis("Mouse X")*Time.deltaTime*sensitivity;
       float mouseY = Input.GetAxis("Mouse Y")*Time.deltaTime*sensitivity;

       xRotation-=mouseY;

       xRotation=Mathf.Clamp(xRotation,-90,90); 

       playerBody.transform.localRotation=Quaternion.Euler(xRotation,0f,0f);
       transform.Rotate(Vector3.up*mouseX);

       rb.AddRelativeForce(Vector3.forward*Time.deltaTime*speed*Input.GetAxis("Vertical"));
       rb.AddRelativeForce(Vector3.right*Time.deltaTime*speed*Input.GetAxis("Horizontal"),ForceMode.Force);

       if(Input.GetKey(KeyCode.LeftShift)){
           speed=200000f;
        } else{
               speed=50000f;
           }
       if(Input.GetKeyDown(KeyCode.Space)&&!grounded){
           grounded=true;
           rb.AddForce(Vector3.up*jump_force,ForceMode.Impulse);
       }
       if(stopShoot.HaveAmmo==false){
            gameover.SetActive(true);
            stopShoot.HaveAmmo=false;
            stopShoot.mags=0;
            Gameover=true;
            Cursor.visible=true;
       }
       if(Input.GetKey(KeyCode.Escape)){
           escape.gameObject.SetActive(true);
       }
       }
    }
    private void OnCollisionEnter(Collision other) {
        grounded=false;
    }
    public void resume(){
    escape.gameObject.SetActive(false);
        Cursor.visible=false;
}
}

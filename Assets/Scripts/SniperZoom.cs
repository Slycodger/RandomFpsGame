using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperZoom : MonoBehaviour
{   
    private Camera perspective;

    private bool zoomed=false;
    public bool areYouCamera=false;

    public bool areYouGun=false;
    public float FOVafterzoom;

    public Vector3 amountToMove;
    // Start is called before the first frame update
    void Start(){
        perspective=GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1)&&areYouCamera){
            perspective.fieldOfView=FOVafterzoom;
        }else{
            perspective.fieldOfView=60;
        }
        if(Input.GetMouseButtonDown(1)&&areYouGun){
            transform.Translate(amountToMove);
            zoomed=true;
         }else if(Input.GetMouseButtonUp(1)&&zoomed){
             transform.Translate(-amountToMove);
             zoomed=false;
         }
        //else{
        //     transform.position=new Vector3(0.824f,-0.337f,0.527f);
        // }
    }
}

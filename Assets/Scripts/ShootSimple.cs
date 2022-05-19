using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSimple : MonoBehaviour
{
    public GameObject RotationWand;

    public GameObject PlaceOfShot;
    public GameObject bulletToShoot;

    public float RateOfFire;

    private float fr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        fr-=Time.deltaTime*60;
        if(Input.GetMouseButtonDown(0)&&fr<=0){
            Instantiate(bulletToShoot,PlaceOfShot.transform.position,RotationWand.transform.rotation);
            fr=RateOfFire;
        }
    }
}

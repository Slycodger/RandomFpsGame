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

    public Ammo ammo;
    private GameManager GM;
    // Start is called before the first frame update
    void Start()
    {
     GM=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        fr-=Time.deltaTime*60;
        if(Input.GetMouseButtonDown(0)&&fr<=0&&ammo.HaveAmmo){
            for(int i=0; i <GM.BulletAtOnce;i++){
                Instantiate(bulletToShoot,PlaceOfShot.transform.position,RotationWand.transform.rotation);
            }
            fr=RateOfFire;
        }
    }
}

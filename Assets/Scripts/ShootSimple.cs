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
    public Movement player;

    public bool AreYouFullAuto;
    public bool AreYouSemiAuto;
    // Start is called before the first frame update
    void Start()
    {
     GM=GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        fr-=Time.deltaTime*60;

        if(AreYouFullAuto){
            FullAuto();
        }
        if(AreYouSemiAuto){
            SemiAuto();
        }
    }
    
    private void FullAuto(){
        if(Input.GetMouseButton(0)&&ammo.HaveAmmo&&!player.Gameover&&fr<=0){
            for(int i = 0;i<=GM.BulletAtOnce;i++){
                Instantiate(bulletToShoot,PlaceOfShot.transform.position,RotationWand.transform.rotation);
            }
            fr=RateOfFire;
        }
    }
    private void SemiAuto(){
        if(Input.GetMouseButtonDown(0)&&ammo.HaveAmmo&&!player.Gameover&&fr<=0){
            for(int i = 0;i<=GM.BulletAtOnce;i++){
                Instantiate(bulletToShoot,PlaceOfShot.transform.position,RotationWand.transform.rotation);
            }
            fr=RateOfFire;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ammo : MonoBehaviour
{   
    public bool SemiAuto;
    public float FireRate;
    public bool FullAuto;
    private float Fr;
    private float ammo;
    public float AmmoToShoot;
    public bool HaveAmmo = true;
    public float mags=0;

    public Score enemiesShot;

    private float enemies30=30;
    public TextMeshProUGUI ammoCount;

    // Start is called before the first frame update
    void Start()
    {
        ammo=AmmoToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if(FullAuto){
            Fr-=Time.deltaTime*60;
            if(Input.GetMouseButton(0)&&Fr<0&&HaveAmmo){
            Fr=FireRate;
            ammo--;
        }
        if(ammo<0){
            HaveAmmo=false;
        }
        }
        ammoCount.text="Ammo :"+ammo+"X"+mags;
        if(Input.GetKeyDown(KeyCode.R)&&mags>0){
            ammo=AmmoToShoot;
            mags--;
        }
        if(enemiesShot.AddScore>enemies30){
            mags++;
            enemies30+=30;

        }
    }
}

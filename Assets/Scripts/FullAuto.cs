using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAuto : MonoBehaviour
{   
    public GameObject Bullet;
    public GameObject Pos;
    public GameObject Rot;

    public float FireRate;

    private float Fr;

    private Ammo ammo;

    // Start is called before the first frame update
    void Start()
    {
        ammo=GameObject.Find("GameManager").GetComponent<Ammo>();
    }

    // Update is called once per frame
    void Update()
    {
        Fr-=Time.deltaTime*60.0f;

        if(Input.GetMouseButton(0)&&Fr<0&&ammo.HaveAmmo){
            Instantiate(Bullet,Pos.transform.position,Rot.transform.rotation);
            Fr=FireRate;
        }
    }
}

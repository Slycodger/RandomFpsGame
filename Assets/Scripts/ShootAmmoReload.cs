using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShootAmmoReload : MonoBehaviour
{
    public int Ammo;
    public float ReloadTime;
    public GameObject bullet;
    public GameObject Barrel;
    public GameObject Camera;
    private IEnumerator courtine;
    private int OGAmmo;
    private bool Reloaded = false;
    public TextMeshPro text;
    private IEnumerator waitime;
    // Start is called before the first frame update
    void Start()
    {
        OGAmmo = Ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Ammo > 0)
        {
            Instantiate(bullet, Barrel.transform.position, Camera.transform.rotation);
            Ammo--;
        }
        if (Input.GetKeyDown(KeyCode.R) && Reloaded == false)
        {
            Reloaded = true;
            courtine = reload(ReloadTime);
            StartCoroutine(courtine);
            StartCoroutine(waitime);

        }

        text.text = ""+Ammo;
        waitime = wait(5);
    }

    public IEnumerator reload(float time)
    {

            while (true)
            {
                yield return new WaitForSeconds(time);
                Reloaded = true;
                StartCoroutine(waitime);
                Ammo = OGAmmo;
                StopCoroutine(courtine);
            }
    }

    public IEnumerator wait(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Reloaded = false;
            StopCoroutine(waitime);
        }
    }
}

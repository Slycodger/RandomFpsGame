using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ShootAmmo : MonoBehaviour
{
    public int Ammo;
    public float ReloadTime;
    public GameObject bullet;
    public GameObject Barrel;
    public GameObject Camera;
    public IEnumerator courtine;
    public int OGAmmo;
    public bool Reloaded = false;
    public TextMeshPro text;
    public IEnumerator waitime;
    public IEnumerator AttackSpeed;
    public bool TimeBetweenShots;
    public int AttackSped = 5;
    // Start is called before the first frame update
    void Start()
    {
        OGAmmo = Ammo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && Ammo > 0 &&!TimeBetweenShots)
        {
            Instantiate(bullet, Barrel.transform.position, Camera.transform.rotation);
            Ammo--;
            TimeBetweenShots = true;
            AttackSpeed = AtackSpeed(AttackSped);
            StartCoroutine(AttackSpeed);
        }
        if (Input.GetKeyDown(KeyCode.R) && Reloaded == false)
        {
            Reloaded = true;
            courtine = reload(ReloadTime);
            StartCoroutine(courtine);
            StartCoroutine(waitime);
            StartCoroutine(AttackSpeed);

        }

        text.text = "" + Ammo;
        waitime = wait(1);
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
    public IEnumerator AtackSpeed(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            TimeBetweenShots = false;
            StopCoroutine(AttackSpeed);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletGoForward : MonoBehaviour
{
    public int BulletSpeed;
    private Rigidbody Rb;
    private Movement P;
    private Enemy E;
    private IEnumerator bulletGoAwayTime;
    private Money money;
    public int Gravity = 10;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.AddRelativeForce(Vector3.forward * Time.deltaTime * BulletSpeed, ForceMode.Impulse);
        P = GameObject.Find("Player").GetComponent<Movement>();
        E = GameObject.Find("Enemy").GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {

        money = GameObject.Find("Money").GetComponent<Money>();
        bulletGoAwayTime = BulletAway(10);
        StartCoroutine(bulletGoAwayTime);
        Rb.AddForce(Vector3.down * 10);
    }
    public IEnumerator BulletAway(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            P.Health -= E.Damage;
            money.Cash -= E.Damage;
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            E.Health -= P.Damage;
            money.Cash += P.Damage;
            Destroy(gameObject);
        }
    }
}

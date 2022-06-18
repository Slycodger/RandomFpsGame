using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuletGoForward : MonoBehaviour
{
    public float BulletSpeed;
    private Rigidbody Rb;
    private IEnumerator courtine;
    public Movement P;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Rb.AddRelativeForce(Vector3.forward * Time.deltaTime * BulletSpeed, ForceMode.Impulse);
        P = GameObject.Find("Player").GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {

        Rb.AddForce(Vector3.down * 10);
        damage = GameObject.Find("Player").GetComponent<Movement>().Damage;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Movement>().health -= P.Damage;
            P.cashtogain += P.Damage;
        }
        courtine = goAway(2);
        StartCoroutine(courtine);
    }
    public IEnumerator goAway(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

            Destroy(gameObject);

        }
    }
}

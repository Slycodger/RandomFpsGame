using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LasarGun : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject PosRotWand;
    public OnWard O;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (O.Bool)
        {
            StartCoroutine(timer(5));
            O.Bool = false;
        }
    }
    public IEnumerator timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Instantiate(Bullet, transform.position, PosRotWand.transform.rotation);
            O.Bool = true;
        }
    }
}

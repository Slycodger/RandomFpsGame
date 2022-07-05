using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{
    public GameObject[] p1;
    public GameObject[] p2;
    public GameObject[] p3;
    private int a;
    private int b;
    private int c;
    // Start is called before the first frame update
    void Start()
    {
        a = Random.Range(0, p1.Length);
        b = Random.Range(0, p2.Length);
        c = Random.Range(0, p3.Length);

        p1[a].gameObject.SetActive(true);
        p2[b].gameObject.SetActive(true);
        p3[c].gameObject.SetActive(true);
    }

    public void Refresh()
    {
        p1[a].gameObject.SetActive(false);
        p2[b].gameObject.SetActive(false);
        p3[c].gameObject.SetActive(false);

        a = Random.Range(0, p1.Length);
        b = Random.Range(0, p2.Length);
        c = Random.Range(0, p3.Length);

        p1[a].gameObject.SetActive(true);
        p2[b].gameObject.SetActive(true);
        p3[c].gameObject.SetActive(true);

    }
}

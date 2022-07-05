using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject[] walls;
    int a;
    int b;
    int c;
    int d;
    int e;
    public bool starter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (starter)
        {
            StartCoroutine(timer(5));
            starter = false;
        }
    }
    public IEnumerator timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            walls[a].gameObject.SetActive(true);
            walls[b].gameObject.SetActive(true);
            walls[c].gameObject.SetActive(true);
            walls[d].gameObject.SetActive(true);
            walls[e].gameObject.SetActive(true);
            StartCoroutine(WallDrop(5));
        }
    }
    public IEnumerator WallDrop(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);

             a = Random.Range(0, walls.Length);
             b = Random.Range(0, walls.Length);
             c = Random.Range(0, walls.Length);
             d = Random.Range(0, walls.Length);
             e = Random.Range(0, walls.Length);

            walls[a].gameObject.SetActive(false);
            walls[b].gameObject.SetActive(false);
            walls[c].gameObject.SetActive(false);
            walls[d].gameObject.SetActive(false);
            walls[e].gameObject.SetActive(false);
            StartCoroutine(timer(5));
        }
    }
}

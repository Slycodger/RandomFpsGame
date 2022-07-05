using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float Health;
    public float Damage;
    public GameObject StartPos;
    public GameObject[] RandomPos;
    public GameObject bullet;
    public IEnumerator courtine;
    public IEnumerator TrackTime;
    public Movement P;
    public GameObject PosRotWand;
    public OnWard O;
    public bool Start = false;
    public GameObject Player;
    public GameObject[] Loop;
    public NavMeshAgent agent;
    public int PosToGO = 0;
    public GameObject Laser;
    private bool StopTrack;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        P = GameObject.Find("Player").GetComponent<Movement>();
        if (Start)
        {
            courtine = Timer(5);
            StartCoroutine(courtine);
            Start = false;
        }
        if(Health <= 0)
        {
            O.ECounter++;
            Health = 100;
            int I = Random.Range(0, RandomPos.Length);
            transform.position = RandomPos[I].transform.position;
        }
        if(Physics.Raycast(Laser.transform.position, Laser.transform.forward,out hit))
        {
            if (!hit.collider.gameObject.CompareTag("Player")){
                Laser.transform.Rotate(Vector3.up * 1);

                agent.SetDestination(Loop[PosToGO].transform.position);
            }
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                TrackTime = Track(10);
                StartCoroutine(TrackTime);
                StopTrack = true;
            }
        }
        if (StopTrack)
        {
            agent.SetDestination(P.transform.position);
            if (agent.remainingDistance <= 2)
            {
                agent.SetDestination(transform.position);
            }
        }
        else
        {
            agent.SetDestination(Loop[PosToGO].transform.position);
        }
    }
    public IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            Instantiate(bullet, PosRotWand.transform.position, PosRotWand.transform.rotation);
            if (agent.remainingDistance <= 2)
            {
                PosToGO++;
            }
            if (PosToGO == 4)
            {
                    PosToGO = 0;
            }
        }
    }
    public IEnumerator Track(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            StopTrack = false;
            StopCoroutine(TrackTime);
        }
    }
}

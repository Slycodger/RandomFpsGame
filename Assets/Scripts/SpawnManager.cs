using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{   
    public GameObject[] SpotsToSpawn;
    public GameObject enemy;

    public int AmountOfEnemiesOnScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemies.Length<=AmountOfEnemiesOnScreen){
            Instantiate(enemy,SpotsToSpawn[RandomPositionForYou()].transform.position,enemy.transform.rotation);
        }
    }
    private int RandomPositionForYou(){
        int i = Random.Range(0,SpotsToSpawn.Length);
        int RandomPosition=i;
        return RandomPosition;
    }
}

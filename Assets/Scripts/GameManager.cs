using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   public bool GoTowardsPlayer;
    public bool Snipe;
    public bool NoScope;
    public float speedOfShot;

    public bool BulletCollision;
    public int BulletAtOnce;

    public bool LoseWhenTouched;
    public bool ShootAtPlayer;
    public int PointsFromEnemy;
    public GameObject[] SpotsToSpawn;
    public GameObject enemy;
    public bool RespawnEnemies;
    public int PointsFromCompletion;

    public int AmountOfEnemiesOnScreen;
    public bool SpawnEnemies;
    private Score AddScore;

    private int AOEOS = 0;
    public int OGAOEOS;
    private bool SpawnedEnemies=false;
    public int AmountShot;
    private bool PointAdded= false;
    public float NormalSpeed;
    public float SprintSpeed;
    public float SpeedTowardsPlayer;
    // Start is called before the first frame update
    void Start()
    {
        OGAOEOS=AmountOfEnemiesOnScreen;
        AddScore=GameObject.Find("Score").GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {   
        if(SpawnEnemies){
        var Enemies=GameObject.FindGameObjectsWithTag("Enemy");
        if(Enemies.Length<=AmountOfEnemiesOnScreen&&RespawnEnemies){
            Instantiate(enemy,SpotsToSpawn[RandomPositionForYou()].transform.position,enemy.transform.rotation);
            SpawnedEnemies=true;
        }else if(Enemies.Length<=AmountOfEnemiesOnScreen&&!RespawnEnemies&&OGAOEOS>=AOEOS){
            Instantiate(enemy,SpotsToSpawn[RandomPositionForYou()].transform.position,enemy.transform.rotation);
            AOEOS++;
            SpawnedEnemies=true;
        }
        if(!RespawnEnemies){
            if(AmountShot>=OGAOEOS+1&&!PointAdded){
                AddScore.ScoreUp(PointsFromCompletion);
                AmountShot=0;
                AOEOS=0;
            }
            
        }
    }

    }
    public void PracticeMode(){
        SceneManager.LoadScene(1);
    }
    public void BackToMain(){
        SceneManager.LoadScene(0);
    }
    public void SniperPractice(){
        SceneManager.LoadScene(3);
    }
    public void MachineGunPractice(){
        SceneManager.LoadScene(2);
    }
    public void MidShootPractice(){
        SceneManager.LoadScene(4);
    }
    public void CloseRangePractice(){
        SceneManager.LoadScene(5);
    }
    public void RunNGun(){
        SceneManager.LoadScene(6);
    }
    public void Shop()
    {
        SceneManager.LoadScene(7);
    }
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private int RandomPositionForYou(){
        int i = Random.Range(0,SpotsToSpawn.Length);
        int RandomPosition=i;
        return RandomPosition;
}
public void Back(){
        SceneManager.LoadScene(1);
}

public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}

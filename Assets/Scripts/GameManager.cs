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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
    public void Reset(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

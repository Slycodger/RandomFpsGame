using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class OnWard : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject StartButton;
    public GameObject EnemyScene;
    public GameObject BossScene;
    public GameObject Player;
    public GameObject Camera;
    public GameObject Pause;
    public GameObject ShopStuff;
    private Movement P;
    private Enemy E;
    public int ECounter;
    public int AmountNeeded;
    private bool AtScene = false;
    public Boss B;
    public bool Bool;
    private void Update()
    {
        if (ECounter >= AmountNeeded && AtScene)
        {
            E.transform.position = E.StartPos.transform.position;
            E.Health = 100;
            Back();
        }
    }
    public void OnWord()
    {
        Buttons.gameObject.SetActive(true);
        StartButton.gameObject.SetActive(false);
    }
    public void Enemy()
    {   
        EnemyScene.gameObject.SetActive(true);
        Buttons.gameObject.SetActive(false);
        Player.gameObject.SetActive(true);
        Camera.gameObject.SetActive(false);
        Cursor.visible = false;
        E = GameObject.Find("Enemy").GetComponent<Enemy>();
        E.Start = true;
        E.transform.position = E.StartPos.transform.position;
        P = GameObject.Find("Player").GetComponent<Movement>();
        AtScene = true;
        P.Health = 100;
    }
    public void Boss()
    {
        BossScene.gameObject.SetActive(true);
        Buttons.gameObject.SetActive(false);
        Player.gameObject.SetActive(true);
        Camera.gameObject.SetActive(false);
        P = GameObject.Find("Player").GetComponent<Movement>();
        Cursor.visible = false;
        B.starter = true;
        Bool = true;
    }
    public void Back() {
        ShopStuff.gameObject.SetActive(false);
        EnemyScene.gameObject.SetActive(false);
        BossScene.gameObject.SetActive(false);
        Buttons.gameObject.SetActive(true);
        Player.gameObject.SetActive(false);
        Camera.gameObject.SetActive(true);
        P.Paused = false;
        Pause.gameObject.SetActive(false);
        Cursor.visible = true;
        AtScene = false;

    }
    public void Resume()
    {
        Pause.gameObject.SetActive(false);
        P.Paused = false;
        Cursor.visible = false;
    }
    public void Shop()
    {
        ShopStuff.gameObject.SetActive(true);
        Buttons.gameObject.SetActive(false);
    }
}

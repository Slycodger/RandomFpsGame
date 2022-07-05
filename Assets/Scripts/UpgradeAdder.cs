using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAdder : MonoBehaviour
{
    public float speed;
    public float terminalSpeed;
    public float Damage;
    public float EDamage;
    public float Health;
    public float EHealth;
    public Movement P;
    public Money M;
    public ShootAmmo SA;
    public float PSpeed = 1000;
    public float PterminalSpeed =4;
    public float PDamage = 25;
    public float PHealth = 100;
    public int AttackSpeed;
    public int Ammo;
    public int ReloadSpeed;
    public int CostToRemove;
    private void Update()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {   
            P.speed += speed;
            P.terminalSpeed += terminalSpeed;
            P.Damage += Damage;
            P.Health += Health;
            M.Cash -= CostToRemove;
            SA.ReloadTime += ReloadSpeed;
            SA.AttackSped += AttackSpeed;
            SA.Ammo += Ammo;

            PSpeed += speed;
            PterminalSpeed += terminalSpeed;
            PDamage += Damage;
            PHealth += Health;

        }
    }
    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            speed = 0;
            terminalSpeed = 0;
            Damage = 0;
            EDamage = 0;
            Health = 0;
            EHealth = 0;
            CostToRemove = 0;
            ReloadSpeed = 0;
            AttackSpeed = 0;
            Ammo = 0;
        }
    }
}

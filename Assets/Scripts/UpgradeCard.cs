using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UpgradeCard : MonoBehaviour
{
    public float speed;
    public float terminalspeed;
    public float damage;
    public float health;
    public int AttackSpeed;
    public int Ammo;
    public int ReloadSpeed;
    public int Cost;
    public UpgradeAdder UA;
    private IEnumerator courtine;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    public void Upgrade()
    {   
        UA.speed += (UA.PSpeed *= speed);
        UA.terminalSpeed +=(UA.PterminalSpeed *= terminalspeed);
        UA.Damage += (UA.PDamage *=damage);
        UA.Health +=(UA.PHealth *= health);
        UA.AttackSpeed -=AttackSpeed;
        UA.Ammo += Ammo;
        UA.ReloadSpeed -= ReloadSpeed;   
        UA.CostToRemove += Cost;
        courtine = Away(0.5f);
        StartCoroutine(courtine);
    }
    public IEnumerator Away(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            gameObject.SetActive(false);
        }
    }
}

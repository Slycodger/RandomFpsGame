using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthTotalCashGainedCash : MonoBehaviour
{
    private Movement P;

    public TextMeshPro Health;
    public TextMeshPro TotalCash;
    public TextMeshPro CashGonnaGain;
    public TextMeshPro Damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Health.text = "Health :" + P.health;
        TotalCash.text = "Total cash :"; 
    }
}

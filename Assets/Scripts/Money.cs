using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    public float Cash;
    private float num;
    private bool lottery;
    private IEnumerator courtine;
    private TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !lottery)
        {
            num = Random.Range(0, 1);
            if(num == 0)
            {
                Cash = 0;
            }
            if(num == 1)
            {
                Cash *= 2;
            }
            courtine = Timer(120);
            StartCoroutine(courtine);
        }
        text.text = "Cash :" + Cash + "\n" + "Press I to Gamble, double or nothing";
    }
    public IEnumerator Timer(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            lottery = true;
        }
    }
}

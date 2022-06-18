using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static int p1rounds;
    public static int p2rounds;
    public int RoundsNeeded;
    private TextMeshProUGUI Text;
    public TextMeshProUGUI CashCashgonnagain;
    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    public Movement[] P;
    public Start button;
    // Start is called before the first frame update
    void Start()
    {

        Text = GameObject.Find("YaWin").GetComponent<TextMeshProUGUI>();
        CashCashgonnagain = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
        health = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
        score = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        button = GameObject.Find("GameObject").GetComponent<Start>();
        if (button.havestarted)
        {
            score.text = "Player 1 score : " + p1rounds + "\n" + "Player 2 score : " + p2rounds;

            health.text = "Player 1 health : " + P[0].health + "\n" + "Player 2 health : " + P[1].health;

            CashCashgonnagain.text = "Player 1 Cash : " + Movement.cash + "\n" +"Player 2 Cash : " + Movement.cash2;


        }
       
    }
    private void LateUpdate()
    {
        if (button.havestarted)
        {
            P[0] = GameObject.Find("Player").GetComponent<Movement>();
            P[1] = GameObject.Find("Target").GetComponent<Movement>();
            CashCashgonnagain = GameObject.Find("CashText").GetComponent<TextMeshProUGUI>();
            health = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();
            score = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        }
        if (p2rounds == RoundsNeeded)
        {
            Text.color = Color.green;
            Text.text = "Player 2 wins!";
        }
        if (p1rounds == RoundsNeeded)
        {
            Text.color = Color.blue;
            Text.text = "Player 1 wins!";
        }
    }
}

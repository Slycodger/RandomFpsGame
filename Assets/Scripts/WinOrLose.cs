using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{
    public bool p1 = false;
    public bool p2 = false;
    public Movement[] P;
    public int cash1;
    public int cash2;
    private Start button;
    private bool added = false;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("GameObject").GetComponent<Start>();
    }

    // Update is called once per frame
    void Update()
    {

        if (button.havestarted)
        {
            P[0] = GameObject.Find("Player").GetComponent<Movement>();
            P[1] = GameObject.Find("Target").GetComponent<Movement>();
        }
        

    }
    private void LateUpdate()
    {

        if (button.havestarted)
        {
            if (p1)
            {
                cash1 += P[0].cashtogain / 2;
                cash2 += P[1].cashtogain;
                P[0].cashtogain = 0;
                P[1].cashtogain = 0;

                p1 = !p1;
                if (!added)
                {
                    added = true;
                    Movement.cash += cash1;
                    Movement.cash2 += cash2;
                }
            }
            if (p2)
            {
                cash2 += P[1].cashtogain / 2;
                cash1 += P[0].cashtogain;
                P[0].cashtogain = 0;
                P[1].cashtogain = 0;
                p2 = false;
                if (!added)
                {
                    added = true;
                    Movement.cash += cash1;
                    Movement.cash2 += cash2;
                }
            }


        }
    }
}

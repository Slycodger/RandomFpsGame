using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAndLoadUpgrades : MonoBehaviour
{
    public string oneToUpgrade;
    private GameObject Player;
    private float RounderLR;
    private float RounderUD;
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            RounderLR = 1;
        }else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RounderLR = -1;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            RounderUD = 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            RounderUD = -1;
        }




        Player = GameObject.Find("Player");
        if (PlayerPrefs.GetInt("KeyToAim") == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Player.transform.Rotate(Vector3.right *RounderUD *0.1f );
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                Player.transform.Rotate(Vector3.up * RounderLR *0.1f);
            }
        }
        Debug.Log(RounderLR);
    }
    private void Start()
    {
    }
    public void Buy()
    {
        if(PlayerPrefs.GetFloat("Points") >= 500)
        {
            PlayerPrefs.SetFloat("Points", PlayerPrefs.GetFloat("Points") - 500);

            PlayerPrefs.SetInt(oneToUpgrade, 1);
            Debug.Log(PlayerPrefs.GetFloat("Points"));
        }
    }
    public void Reset()
    {
        PlayerPrefs.SetInt(oneToUpgrade, 0);
    }
}

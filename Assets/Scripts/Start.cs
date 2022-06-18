using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Start : MonoBehaviour
{
    public GameObject[] Scene;
    public GameObject Button;
    public Movement[] Player;
    public int scenetogo;

    public static bool started = false;
    public bool havestarted;
    private IEnumerator courtine;
    private void Update()
    {
        if (started) { 
        Player[0] = GameObject.Find("Player").GetComponent<Movement>();
        Player[1] = GameObject.Find("Target").GetComponent<Movement>();
        Player[0].P1 = true;
        Player[1].P2 = true;
        }
        havestarted = started;
    }
    public void GameOn()
    {

        scenetogo = Random.Range(1,4);

        SceneManager.LoadScene(scenetogo);

        Button.gameObject.SetActive(false);
        started = true;
    }
    public void YaLost()
    {
        courtine = Loser(1);
        StartCoroutine(courtine);
        
    }
    public IEnumerator Loser(int I)
    {
        while (true)
        {
            yield return new WaitForSeconds(I);

            SceneManager.LoadScene(scenetogo);
            scenetogo = Random.Range(1, 4);

            SceneManager.LoadScene(scenetogo);
        }
    }
}

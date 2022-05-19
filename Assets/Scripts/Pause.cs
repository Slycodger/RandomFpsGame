using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{   
    public GameObject escape;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape)){
            escape.gameObject.SetActive(true);
            Cursor.visible=true;
        }
    }
    public void Back(){
        SceneManager.LoadScene(1);
    }
    public void resume(){
        escape.gameObject.SetActive(false);
        Cursor.visible=false;
    }
}

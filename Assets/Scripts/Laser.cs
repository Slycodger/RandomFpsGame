using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LineRenderer L;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit))
        {
            if (hit.collider)
            {
                L.SetPosition(1,new Vector3(0, 0, hit.distance));
            }
            else
            {
                L.SetPosition(1, new Vector3(0, 0, 5000));
            }
        }
    }
}

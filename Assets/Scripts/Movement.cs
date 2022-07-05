using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Movement : MonoBehaviour
{
    public GameObject Camera;
    public float speed;
    public float sensitivty;
    private float horizontal;
    private Rigidbody rb;
    private bool grounded = false;
    public float terminalSpeed = 4;
    public GameObject Pause;
    public bool Paused;
    public float Damage;
    public float Health;
    public GameObject bullet;
    public TextMeshProUGUI text;
    public OnWard O;
    public Enemy E;
    public Money M;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!Paused)
        {
            if (gameObject.CompareTag("Player"))
            {
                float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivty;
                float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivty;
                horizontal -= MouseY;
                horizontal = Mathf.Clamp(horizontal, -90, 90);

                Camera.transform.localRotation = Quaternion.Euler(horizontal, 0, 0);
                transform.Rotate(Vector3.up * MouseX);
                if (rb.velocity.x < terminalSpeed && rb.velocity.z < terminalSpeed && rb.velocity.x > -terminalSpeed && rb.velocity.z > -terminalSpeed)
                {
                    rb.AddRelativeForce(Vector3.forward * Time.deltaTime * speed * Input.GetAxis("Vertical"));
                }
                if (rb.velocity.x < terminalSpeed && rb.velocity.z < terminalSpeed && rb.velocity.x > -terminalSpeed && rb.velocity.z > -terminalSpeed)
                {
                    rb.AddRelativeForce(Vector3.right * Time.deltaTime * speed * Input.GetAxis("Horizontal"));
                }
                if (Input.GetKeyDown(KeyCode.Space) && !grounded)
                {
                    rb.AddForce(Vector3.up * (rb.mass * 5), ForceMode.Impulse);
                    grounded = true;
                }
                if (Input.GetKey(KeyCode.K))
                {
                    Cursor.visible = true;
                    Paused = true;
                    Pause.gameObject.SetActive(true);
                }
            }
        }
        if(Health <= 0)
        {
            O.Back();
        }
        text.text = "Health : " + Health;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
}

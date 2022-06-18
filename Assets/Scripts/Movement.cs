using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement : MonoBehaviour
{
    public GameObject Camera;
    public float speed;
    public float sensitivty;
    private float horizontal;
    private Rigidbody rb;
    private bool grounded = false;
    public float terminalSpeed = 4;
    public int health = 100;
    private static int damage;
    public static int cash;
    public static int cash2;
    private int cashgonnagain;
    private Start button;
    private WinOrLose WL;
    public static bool p1 = false;
    public static bool p2 = false;
    private Score score;
    public int Damage;
    public int cashtogain;
    public bool P1;
    public bool P2;
    private bool counted = false;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        button = GameObject.Find("GameObject").GetComponent<Start>();
        WL = GameObject.Find("Pivit").GetComponent<WinOrLose>();
        score = GameObject.Find("Score").GetComponent<Score>();
        rb.mass = 1;
    }

    // Update is called once per frame
    void Update()
    {   
        if (health < 1)
        {
            if (p1 && Score.p2rounds < score.RoundsNeeded)
            {
                if (!counted)
                {
                    counted = true;
                    WL.p2 = true;
                    Score.p1rounds++;
                }
                button.YaLost();
            }
            else if (p2 && Score.p1rounds < score.RoundsNeeded)
            {
                if (counted)
                {
                    counted = true;
                    WL.p1 = true;
                    Score.p2rounds++;
                }
                button.YaLost();
            }

        }
        
        damage += Damage;
        p1 = P1;
        p2 = P2;

        float MouseX = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivty;
        float MouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivty;
        horizontal -= MouseY;
        horizontal = Mathf.Clamp(horizontal, -90, 90);

        Camera.transform.localRotation = Quaternion.Euler(horizontal, 0, 0);
        transform.Rotate(Vector3.up * MouseX);
        if (rb.velocity.x < terminalSpeed && rb.velocity.z < terminalSpeed && rb.velocity.x > -terminalSpeed && rb.velocity.z >-terminalSpeed )
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

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            grounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("trig"))
        {
            health -= 50;
            rb.AddForce(Vector3.up * 20, ForceMode.Impulse);
        }
    }
}

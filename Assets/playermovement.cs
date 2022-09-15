using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody))]

public class playermovement : MonoBehaviour
{
    public GameManager gm;
    public Rigidbody rb;
    public bool isGrounded;

    public float runSpeed = 1f;
    public float strafeSpeed = 5f;
    public float jumpForce = 15f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;
    protected bool doJump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            gm.EndGame();

            Debug.Log("Ну ты и рак конечно!");
        }
        {
            isGrounded = true;
        }

    }

    void Update()
    {

        

        if (Input.GetKey("a"))
        {
            strafeLeft = true;
        }
        else
        {
            strafeLeft = false;
        }

        if (Input.GetKey("d"))
        {
            strafeRight = true;
        }
        else
        {
            strafeRight = false;
        }

        if (Input.GetKeyDown("space") && isGrounded)
        {
            doJump = true;

            isGrounded = false;
        }

        if (transform.position.y < -5f)
        {
            gm.EndGame();
            Debug.Log("Ну ты и краб, однозначно!");
        }
    }


    void FixedUpdate()
    {


        rb.AddForce(0, 0, runSpeed);        

        if (strafeLeft)
        {
            rb.AddForce(-strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (strafeRight)
        {
            rb.AddForce(strafeSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (doJump)
        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            doJump = false;

            transform.DORewind();
            transform.DOShakeScale(.5f, .5f, 3, 30);
        }
    }
}

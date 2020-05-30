using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{

    public float WalkSpeed = 1f;
    public float RunSpeed = 2f;
    public Rigidbody rb;
    public Animator anim;
    public float horizontalMove;

    public float verticalMove;

    public CharacterController player;

    public float playerSpeed;

    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        player = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxis("Horizontal");

        verticalMove = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {    //Estoy corriendo.
                anim.SetBool("Run", true);
                rb.velocity = transform.forward * -RunSpeed;        //forward es para coger la Z,X,Y del propio objeto y no la del mundo.
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    ;        //Dejo de correr.
                    anim.SetBool("Run", false);
                }
                else
                {
                    anim.SetBool("Walk", true);
                    rb.velocity = transform.forward * -WalkSpeed;        //forward es para coger la Z,X,Y del propio objeto y no la del mundo.
                }
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                anim.SetBool("Walk", false);
                anim.SetBool("Run", false);
                rb.velocity = transform.forward * WalkSpeed;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = transform.forward * WalkSpeed;        //forward es para coger la Z,X,Y del propio objeto y no la del mundo.
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2f, 0);
        }
        else
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0, -2f, 0);
            }
        }
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Finish")
        {
            Destroy(obj.gameObject);
        }
    }

    private void FixedUpdate()
    {

        player.Move(new Vector3(horizontalMove, 0, verticalMove) * playerSpeed);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 moveInput;
    [SerializeField]
    private float moveSpeed = 0;
    private Vector3 moveVelocity;

    Rigidbody rb;

    [SerializeField]
    GameObject cam;

    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private bool estaTienda;
    private bool estaMenuTienda;

    [SerializeField]
    private Entrar_Tienda controllerTienda;

    [SerializeField]
    private GameObject trampas;

    [SerializeField]
    private Tienda tienda;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
        estaTienda = false;
        estaMenuTienda = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0){
            if(!estaMenuTienda){
                float mH = Input.GetAxis("Horizontal");
                float mV = Input.GetAxis("Vertical");
                
                moveInput = new Vector3(mH, rb.velocity.y, mV);
                moveVelocity = moveSpeed * moveInput;

                
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");
                if(yaw >= 360){
                    yaw = 0;
                }

                if(pitch < -45) pitch = -45;
                if(pitch > 45) pitch = 45;
                

                cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
                transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
                

                transform.Translate(moveVelocity,Space.Self);
            }
        }
    }


    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Tienda"){
            moveVelocity = Vector3.zero;
            controllerTienda.entrarTienda();
        }

        if(other.gameObject.tag == "SalirTienda"){
            controllerTienda.salirTienda();
        }

        if(other.gameObject.tag == "Cazar"){
            trampas.SetActive(true);
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MenuTienda"){
            controllerTienda.abrirMenuTienda();
        }

        if(other.gameObject.tag == "JabaliCazado"){
            tienda.sumarRecurso("Jabali");
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "ConejoCazado"){
            tienda.sumarRecurso("Conjeo");
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "RataCazado"){
            tienda.sumarRecurso("Rata");
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "AnguilaCazado"){
            tienda.sumarRecurso("Anguila");
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Cazar"){
            trampas.SetActive(false);
        }
    }

    public void setEstaMenuTienda(bool estaMenu){
        estaMenuTienda = estaMenu;
    }

    public GameObject getTrampas(){
        return trampas;
    }
}

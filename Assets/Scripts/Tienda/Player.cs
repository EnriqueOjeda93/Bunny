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
    private Trampas trampasScript;

    [SerializeField]
    private Tienda tienda;

    private int cantidadRecogidaJabali = 0;
    private int cantidadRecogidaAngila = 0;
    private int cantidadRecogidaConnejo = 0;
    private int cantidadRecogidaRata = 0;

    private bool cazar = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
        estaTienda = false;
        estaMenuTienda = false;
        trampasScript = GetComponent<Trampas>();
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

                if(cazar){
                    if(Input.GetKeyDown(KeyCode.Alpha1)){

                        trampasScript.ponerTrampa(1);
                    }

                    if(Input.GetKeyDown(KeyCode.Alpha2)){
                        
                        trampasScript.ponerTrampa(2);
                    }

                    if(Input.GetKeyDown(KeyCode.Alpha3)){
                        
                        trampasScript.ponerTrampa(3);
                    }
                }


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
            cazar = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "MenuTienda"){
            controllerTienda.abrirMenuTienda();
            
            tienda.sumarRecurso("Jabali", cantidadRecogidaJabali);
            tienda.sumarRecurso("Conjeo", cantidadRecogidaConnejo);
            tienda.sumarRecurso("Rata", cantidadRecogidaRata);
            tienda.sumarRecurso("Anguila", cantidadRecogidaAngila);

            cantidadRecogidaJabali = 0;
            cantidadRecogidaConnejo = 0;
            cantidadRecogidaRata = 0;
            cantidadRecogidaAngila = 0;

        }

        if(other.gameObject.tag == "JabaliCazado"){
            cantidadRecogidaJabali++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "ConejoCazado"){
            cantidadRecogidaConnejo++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "RataCazado"){
            cantidadRecogidaRata++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "AnguilaCazado"){
            cantidadRecogidaAngila++;
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Cazar"){
            trampas.SetActive(false);
            cazar = false;
        }
    }

    public void setEstaMenuTienda(bool estaMenu){
        estaMenuTienda = estaMenu;
    }

    public GameObject getTrampas(){
        return trampas;
    }
}

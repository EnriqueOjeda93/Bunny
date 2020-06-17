using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Vector3 moveInput;
    [SerializeField]
    private float moveSpeed = 0;
    private Vector3 moveVelocity;

    Rigidbody rb;

    [SerializeField]
    GameObject cam;
    Animator animator;

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

    [SerializeField]
    private GameObject gameObjectJabali;
    [SerializeField]
    private GameObject gameObjectConejo;
    [SerializeField]
    private GameObject gameObjectPescado;
    [SerializeField]
    private Text gameObjectJabaliText;
    [SerializeField]
    private Text gameObjectConejoText;
    [SerializeField]
    private Text gameObjectPescadoText;

    private int cantidadRecogidaJabali = 0;
    private int cantidadRecogidaAngila = 0;
    private int cantidadRecogidaConnejo = 0;
    private int cantidadRecogidaRata = 0;
    private float velRun;
    private bool cazar = false;
    private float cuadrante;
    private float tiempoHot;
    private float tiempoHotEspera = 4f;

    private bool jump = false;

    [SerializeField]
    private AudioClip S_get;
    [SerializeField]
    private AudioClip S_Click;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();        
        estaTienda = false;
        estaMenuTienda = false;
        trampasScript = GetComponent<Trampas>();
        animator = GetComponent<Animator>();
        tiempoHot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0){
            if(!estaMenuTienda){
                
                yaw += speedH * Input.GetAxis("Mouse X");
                pitch -= speedV * Input.GetAxis("Mouse Y");
                if(yaw >= 360){
                    yaw = 0;
                }

                if(pitch < -45) pitch = -45;
                if(pitch > 45) pitch = 45;

                cam.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
                transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);

                if(cazar){
                    if(Input.GetKeyDown(KeyCode.Alpha1)){

                        audio.clip = S_Click;
                        audio.Play();
                        trampasScript.ponerTrampa(1);
                    }

                    if(Input.GetKeyDown(KeyCode.Alpha2)){
                        
                        audio.clip = S_Click;
                        audio.Play();
                        trampasScript.ponerTrampa(2);
                    }

                    if(Input.GetKeyDown(KeyCode.Alpha3)){
                        
                        audio.clip = S_Click;
                        audio.Play();
                        trampasScript.ponerTrampa(3);
                    }
                }

                float mV = Input.GetAxis("Vertical");
                
                if(mV != 0){

                    transform.Translate(moveVelocity,Space.Self);

                    if(Input.GetKey(KeyCode.E)){
                        velRun = 2.5f;
                        animator.SetBool("run", true);
                    } else {

                        velRun = 1;
                        animator.SetBool("run", false);
                    }
                    
                    animator.SetBool("walk", true);
                    animator.SetBool("hot", false);

                    moveInput = new Vector3(rb.velocity.x, rb.velocity.y, mV);
                    moveVelocity = moveSpeed * moveInput * velRun * Time.deltaTime;
                    tiempoHot = Time.time;
                } else {

                    animator.SetBool("walk", false);
                    animator.SetBool("run", false);

                    if(Time.time > tiempoHot + tiempoHotEspera){
                        
                        animator.SetBool("hot", true);
                    }
                }

                if(Input.GetKeyDown(KeyCode.Space)){
                    
                    animator.SetBool("hot", false);
                    animator.SetBool("jump", true);
                    tiempoHot = Time.time;
                    jump = true;
                } else {

                    animator.SetBool("jump", false);
                }
            }
        }
    }

    void FixedUpdate()
    {
        if(Time.timeScale != 0){
            if(!estaMenuTienda){

                if(jump){
                    
                    jump = false;
                    rb.AddForce(Vector3.up * 1000f * Time.fixedDeltaTime, ForceMode.Impulse);
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

            gameObjectJabali.SetActive(false);
            gameObjectConejo.SetActive(false);
            gameObjectPescado.SetActive(false);

            gameObjectJabaliText.text = "";
            gameObjectConejoText.text = "";
            gameObjectPescadoText.text = "";
        }

        if(other.gameObject.tag == "JabaliCazado"){
            cantidadRecogidaJabali++;
            audio.clip = S_get;
            audio.Play();

            if(!gameObjectJabali.activeSelf){
                gameObjectJabali.SetActive(true);
            }

            gameObjectJabaliText.text = (cantidadRecogidaJabali) + "";
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "ConejoCazado"){
            cantidadRecogidaConnejo++;
            audio.clip = S_get;
            audio.Play();

            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "RataCazado"){
            cantidadRecogidaRata++;
            audio.clip = S_get;
            audio.Play();

            if(!gameObjectConejo.activeSelf){
                gameObjectConejo.SetActive(true);
            }

            gameObjectConejoText.text = (cantidadRecogidaRata) + "";

            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "AnguilaCazado"){
            cantidadRecogidaAngila++;
            audio.clip = S_get;
            audio.Play();

            if(!gameObjectPescado.activeSelf){
                gameObjectPescado.SetActive(true);
            }

            gameObjectPescadoText.text = (cantidadRecogidaAngila) + "";
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

    public void reproducirSonido(){

        audio.clip = S_Click;
        audio.Play();
    }
}

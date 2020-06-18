using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampa : MonoBehaviour
{

    private float tiempo;
    [SerializeField]
    private int tipoTrampa;
    private float tiempoEspera = 3;

    [SerializeField]
    private GameObject jabali;

    [SerializeField]
    private GameObject conejo;

    [SerializeField]
    private GameObject pollo;

    [SerializeField]
    private GameObject anguila;

    private int instanciador = 0;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(tiempo+tiempoEspera < Time.time){
            GameObject g = gameObject;
            if(instanciador == 1) g = Instantiate(jabali); else if(instanciador == 2) g = Instantiate(conejo); else if(instanciador == 3) g = Instantiate(pollo); else if(instanciador == 4) g = Instantiate(anguila); 
            g.transform.position = transform.position;
            Destroy(this.gameObject);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Jabali" && tipoTrampa == 2){
            instanciador = 1;
        }

        if(other.gameObject.tag == "Conejo" && tipoTrampa == 1){
            instanciador = 2;
        }

        if(other.gameObject.tag == "Pollo" && tipoTrampa == 1){
            instanciador = 3;
        }   

        if(other.gameObject.tag == "Anguila" && tipoTrampa == 3){
            instanciador = 4;
        }
    }
}

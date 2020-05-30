using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trampas : MonoBehaviour
{

    [SerializeField]
    private GameObject TrampaTierra;
    [SerializeField]
    private GameObject TrampaTierra2;

    [SerializeField]
    private GameObject TrampaAgua;


    public void ponerTrampa(int idTrampa){
        GameObject g;
        if(idTrampa ==1) g = Instantiate(TrampaTierra); else if(idTrampa ==2) g = Instantiate(TrampaTierra2); else g = Instantiate(TrampaAgua);

        g.transform.position = new Vector3(transform.position.x + .8f, transform.position.y + .6f, transform.position.z);

    }
}

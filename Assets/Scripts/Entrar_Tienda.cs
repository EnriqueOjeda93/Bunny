using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Entrar_Tienda : MonoBehaviour
{

    [SerializeField]
    private GameObject camaraPrincipal;
    [SerializeField]
    private GameObject camaraTienda;
    [SerializeField]
    private GameObject personajePricipal;
    [SerializeField]
    private GameObject personajeTienda;
    [SerializeField]
    private GameObject MenuTienda;
    [SerializeField]
    private Player p;

    [SerializeField]
    private GameObject pause;

    void Update(){
        if(Input.GetKey(KeyCode.P)){
            pause.SetActive(true);
            p.setEstaMenuTienda(true);
            Time.timeScale = 0;
        }
    }
    
    public void entrarTienda()
    {
        camaraTienda.SetActive(true);
        personajeTienda.SetActive(true);
        camaraPrincipal.SetActive(false);
        personajePricipal.SetActive(false);
    }

    public void salirTienda()
    {
        
        personajeTienda.transform.position = new Vector3(personajeTienda.transform.position.x, personajeTienda.transform.position.y, personajeTienda.transform.position.z+3);
        camaraPrincipal.SetActive(true);
        personajePricipal.SetActive(true); 
        camaraTienda.SetActive(false);
        personajeTienda.SetActive(false);
        personajePricipal.transform.position = new Vector3(personajePricipal.transform.position.x, personajePricipal.transform.position.y, personajePricipal.transform.position.z-1);
    }

    public void abrirMenuTienda()
    {
        Time.timeScale = 0;
        p.setEstaMenuTienda(true);
        MenuTienda.SetActive(true);
    }

    public void cerrarMenuTienda()
    {
        Time.timeScale = 1;
        p.setEstaMenuTienda(false);
        MenuTienda.SetActive(false);
    }

    public void restart(){
        pause.SetActive(false);
        p.setEstaMenuTienda(false);
        Time.timeScale = 1;
    }

    public void goToMEnu(){
        SceneManager.LoadScene("MainMenu");
    }
}

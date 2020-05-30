using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{

    public Tienda tienda;
    private GameObject[] g;
    public Pedido pedido;

    private int actitud;

    private List<Text[]> listaTienda = new List<Text[]>();

    [SerializeField]
    private Slider slider;

    private AudioSource muerte;
    [SerializeField]
    private AudioClip clip;

    private bool nadaListaPedido = true;
    // Start is called before the first frame update
    void Start()
    {   
        muerte = GetComponent<AudioSource>();
        actitud = 0;
    }


    public void check(){
        listaTienda = tienda.getListaArrayVender();
        
        g = pedido.getListaPedido();

        for (int i = 0; i < g.Length; i++)
        {
            Text []t = g[i].GetComponentsInChildren<Text>();

            if(int.Parse(t[1].text) != 0){
                for (int j = 0; j < listaTienda.Count; j++)
                {
                    if( t[0].text == listaTienda[j][0].text){    

                        if(int.Parse(t[1].text) > int.Parse(listaTienda[j][2].text)) actitud--;
                        else if(int.Parse(t[1].text) <= int.Parse(listaTienda[j][2].text)) actitud++;

                        Debug.Log(int.Parse(t[1].text));
                        Debug.Log(int.Parse(listaTienda[j][2].text));
                        nadaListaPedido = false;
                    }
                }

                if(nadaListaPedido){
                    actitud--;
                }
                nadaListaPedido = true;


            }
        }

        Button[] b = tienda.getListaVender();
        for (int j = 0; j < b.Length; j++)
        {
            if(b[j].IsActive()){
                    
                listaTienda[j][0].text = "";
                listaTienda[j][2].text = 0 + "";
                b[j].gameObject.SetActive(false);
                
            }
        }

        slider.value += (actitud*0.1f);
        actitud = 0;

        if(slider.value <=0 ){
            muerte.clip = clip;
            muerte.Play();
            Time.timeScale = 1;
            Invoke("goMenu", 1.5f);
            
        }

        pedido.setPedido();
    }

    private void goMenu(){
            SceneManager.LoadScene("MainMenu");
    }
}

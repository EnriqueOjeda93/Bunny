using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Check : MonoBehaviour
{

    public Tienda tienda;
    public Pedido pedido;

    private float actitud;

    private List<GameObject> listaPedido = new List<GameObject>();
    private List<Button> listaCompra = new List<Button>();

    [SerializeField]
    private Slider slider;

    private AudioSource muerte;
    [SerializeField]
    private AudioClip clip;

    private bool hayPedido = false;
    private bool nadaListaPedido = true;
    // Start is called before the first frame update
    void Start()
    {   
        muerte = GetComponent<AudioSource>();
        actitud = 0;
    }


    public void check(){
        listaCompra = tienda.getListCompra();
        
        listaPedido = pedido.getListPedido();

        for (int i = 0; i < listaPedido.Count; i++)
        {

            Text[] textsPedido = listaPedido[i].GetComponentsInChildren<Text>();

                for (int j = 0; j < listaCompra.Count; j++)
                {
                    Text[] textsCompra = listaCompra[j].GetComponentsInChildren<Text>();

                        Debug.Log("PEDIDO   " + textsPedido[0].text);
                        Debug.Log("COMPRA   " + textsCompra[0].text);
                    if(textsPedido[0].text == textsCompra[0].text){    

                        Debug.Log(int.Parse(textsPedido[1].text));
                        Debug.Log(int.Parse(textsCompra[1].text));
                        hayPedido = true;

                        if(int.Parse(textsPedido[1].text) > int.Parse(textsCompra[1].text)){ actitud -= 1; }
                        else if(int.Parse(textsPedido[1].text) <= int.Parse(textsCompra[1].text)) { actitud += 1; }
                    }
                }
        }
        
        if(!hayPedido){
            actitud -= 1f;
        }

        hayPedido = false;
        Debug.Log(actitud);
        slider.value += (actitud*0.07f);
        actitud = 0;
        tienda.resetCompra();

        if(slider.value <=0 ){
            muerte.clip = clip;
            muerte.Play();
            Time.timeScale = 1;
            Invoke("goMenu", 1.5f);   
        }

        pedido.resetCompra();
        pedido.setPedido();
    }

    private void goMenu(){
            SceneManager.LoadScene("MainMenu");
    }
}

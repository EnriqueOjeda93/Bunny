using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedido : MonoBehaviour
{


    private string[] listaCarne = new string[]{"Jabali","Conejo","Pollo","Ardilla","Ciervo","Pajaro"};

    private string[] listaPescado = new string[]{"Anguila","TruchaComun","TruchaArroyo","Bonito","Arenque"};

    private List<int> listaCarneComprobar = new List<int>();
    private List<int> listaPescadoComprobar = new List<int>();

    private bool pedido = true;
    private bool pedidoPescado = true;

    public List<GameObject> listPedido = new List<GameObject>();

    [SerializeField]
    private GameObject contenedorPedido;

    [SerializeField]
    private GameObject prefabPedido;

    // Start is called before the first frame update
    void Start()
    {
        setPedido();
    }

    private void alistarPedido(int consumible, string[] lista){
            
        GameObject g = Instantiate(prefabPedido);
        Text[] texts = g.GetComponentsInChildren<Text>();

        texts[0].text = lista[consumible];
        texts[1].text =  Random.Range(2, 3)+"";

         g.transform.parent = contenedorPedido.transform;

         listPedido.Add(g);
    }
    

    public void setPedido(){

        int cant = Random.Range(2, 3);
        pedidoPescado = true;

        for (int i = 0; i < cant; i++)
        {
            int eleccion = Random.Range(1, 9);
            int consumuble = Random.Range(0, 3);
            pedido = true;

            if(eleccion < 7){

                for (int j = 0; j < listaCarneComprobar.Count; j++){
                    if(listaCarneComprobar[j] == consumuble){
                        pedido = false;
                    }
                }
                if(pedido){
                    listaCarneComprobar.Add(consumuble);
                    alistarPedido(consumuble, listaCarne);
                }

            } else{
                
                if(pedidoPescado){
                    pedidoPescado = false;
                    listaPescadoComprobar.Add(0);
                    alistarPedido(0, listaPescado);
                } else {

                    i--;
                }
            }

        }

        listaCarneComprobar.Clear();
        listaPescadoComprobar.Clear();
    }

    public List<GameObject> getListPedido(){
        return listPedido;
    }

    public void resetCompra(){

        foreach (GameObject pedido in listPedido)
        {
            Destroy(pedido);
        }
        
        listPedido.Clear();
    }
}

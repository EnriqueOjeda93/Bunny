using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedido : MonoBehaviour
{


    private string[] listaCarne = new string[]{"Jabali","Cojejo","Rata","Ardilla","Ciervo","Pajaro"};

    private string[] listaPescado = new string[]{"Anguila","TruchaComun","TruchaArroyo","Bonito","Arenque"};

    
    [SerializeField]
    private GameObject[] listaPedido;

    
    private List<int> listaCarneComprobar = new List<int>();
    private List<int> listaPescadoComprobar = new List<int>();

    private bool pedido = true;

    // Start is called before the first frame update
    void Start()
    {
        setPedido();
    }

    private void alistarPedido(int i, int consumible, string[] lista){
            Text []t = listaPedido[i].GetComponentsInChildren<Text>();
            listaPedido[i].SetActive(true);
            t[0].text = lista[consumible];
            int cantidadPedido = Random.Range(1, 3);
            t[1].text = cantidadPedido+"";


    }
    public GameObject[] getListaPedido(){
        return listaPedido;
    }

    public void setPedido(){
        int cant = Random.Range(2, 3);
        
        for (int i = 0; i < cant; i++)
        {
            int eleccion = Random.Range(1, 9);
            int consumuble = Random.Range(0, 2);

            if(eleccion < 5 || consumuble == 2){

                for (int j = 0; j < listaCarneComprobar.Count; j++){
                    if(listaCarneComprobar[j] == consumuble){
                        pedido = false;
                    }
                }
                if(pedido){
                    listaCarneComprobar.Add(consumuble);
                    alistarPedido(i, consumuble, listaCarne);
                }

            } else{
                for (int j = 0; j < listaPescadoComprobar.Count; j++){
                    if(listaPescadoComprobar[j] == consumuble){
                        pedido = false;
                    }
                }
                if(pedido){
                    listaPescadoComprobar.Add(consumuble);
                    alistarPedido(i, consumuble, listaPescado);
                }
            }

            pedido = true;

        }
        listaCarneComprobar.Clear();
        listaPescadoComprobar.Clear();
        
    }
}

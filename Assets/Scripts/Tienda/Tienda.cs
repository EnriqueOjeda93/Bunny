using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Tienda : MonoBehaviour
{
    private string[] listaCarne = new string[]{"Jabali","Cojejo","Rata","Ardilla","Ciervo","Pajaro"};

    private string[] listaPescado = new string[]{"Anguila","TruchaComun","TruchaArroyo","Bonito","Arenque"};
    [SerializeField]
    private Text[] listaCarneCantidad;
    [SerializeField]
    private Text[] listaPescadoCantidad;
    [SerializeField]
    private Button[] listaVender;

    private List<Text[]> listaArrayVender = new List<Text[]>();

    private bool coger = true;
    private bool devolver = true;
    private Items items = new Items();
Item item;
    // Start is called before the first frame update
    void Awake()
    {

        for (int i = 0; i < listaCarne.Length+listaPescado.Length; i++)
        {
            if(i < listaCarne.Length) item = new Item(listaCarne[i], int.Parse(listaCarneCantidad[i].text));
            else item = new Item(listaPescado[i-listaCarne.Length], int.Parse(listaPescadoCantidad[i-listaCarne.Length].text));
            items.addItem(item);
        }

        for (int i = 0; i < listaVender.Length; i++)
        {
            Text []t = listaVender[i].GetComponentsInChildren<Text>();
            listaArrayVender.Add(t);
        }

    }
//int.Parse(listaCarneCantidad[index].text)
    public void cogerItem(int index){
        if(index>5){
            int indexPescado = index - listaCarne.Length;
            changeListas(index, indexPescado, listaPescadoCantidad);
        } else {
            int indexCarne = index;
            changeListas(index, indexCarne, listaCarneCantidad);
        }
            
            
        
    }

    private void changeListas(int indice, int incideLista, Text[] lista){
       
        if(int.Parse(lista[incideLista].text)>0){
            int nuevCantidad = int.Parse(lista[incideLista].text) - 1;
            lista[incideLista].text = nuevCantidad+"";

            for (int i = 0; i < listaVender.Length; i++)
            {

                if(!listaVender[i].IsActive() && coger){
                    listaArrayVender[i][0].text = items.getListaItems()[indice].getNameItem();
                    listaArrayVender[i][2].text = 1+"";
                    listaVender[i].gameObject.SetActive(true);
                    coger = false;
                    

                }else if(listaArrayVender[i][0].text == items.getListaItems()[indice].getNameItem() && coger){
                    listaArrayVender[i][2].text = (int.Parse(listaArrayVender[i][2].text)+1)+"";
                    coger = false;
                }
                
            }
            coger = true;
        }

    }


    public void devolverItem(Text name){

        for (int i = 0; i < listaCarne.Length+listaPescado.Length; i++)
        {
            if(items.getListaItems()[i].getNameItem() == name.text && devolver){
                
                for (int j = 0; j < listaVender.Length; j++)
                {
                    if(listaArrayVender[j][0].text == name.text){
                        int a = int.Parse(listaArrayVender[j][2].text)-1;
                        listaArrayVender[j][2].text = a+"";
                        if(a < 1){
                            
                            listaArrayVender[j][0].text = "";
                            listaArrayVender[j][2].text = 0 + "";
                            listaVender[j].gameObject.SetActive(false);
                        }
                    }
                }
                if(i>5) listaPescadoCantidad[i-listaCarne.Length].text = (int.Parse(listaPescadoCantidad[i-listaCarne.Length].text)+1)+""; else listaCarneCantidad[i].text = (int.Parse(listaCarneCantidad[i].text)+1)+"";           

                devolver = false;
            
            }
            
        }
        devolver = true;
        
    }
    
    public List<Text[]> getListaArrayVender(){
        return listaArrayVender;
    }

    public Button[] getListaVender(){
        return listaVender;
    }


    public void sumarRecurso(string name){
        for (int i = 0; i < listaCarne.Length+listaPescado.Length; i++)
        {
            Debug.Log(i);
            Debug.Log(items.getListaItems()[i].getNameItem());
            Debug.Log(name);
            if(items.getListaItems()[i].getNameItem() == name && devolver){
                
                if(i>5) listaPescadoCantidad[i-listaCarne.Length].text = (int.Parse(listaPescadoCantidad[i-listaCarne.Length].text)+1)+""; else listaCarneCantidad[i].text = (int.Parse(listaCarneCantidad[i].text)+1)+"";           

                devolver = false;
            
            }
            
        }
        devolver = true;

    }


}

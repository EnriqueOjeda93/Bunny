using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Compra
{   

    private int idCompra;
    private string nameCompra;
    private int cantidadCompra;

    public Compra(int id, string name, int cantidad, Sprite image){
        idCompra = id;
        nameCompra = name;
        cantidadCompra = cantidad;
    }

    public int getIdCompra(){
        return idCompra;
    }

    public string getNameCompra(){
        return nameCompra;
    }

    public void setNameCompra(string name){
        nameCompra = name;
    }

    public int getCantidadCompra(){
        return cantidadCompra;
    }

    public void setCantidadCompra(int cantidad){
        cantidadCompra = cantidad;
    }
}

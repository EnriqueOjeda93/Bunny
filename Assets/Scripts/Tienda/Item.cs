using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item
{   

    private int idItem;
    private string nameItem;
    private int cantidadItem;
    private Sprite imageItem;
    private bool enCompra;
    private bool agotado;

    public Item(int id, string name, int cantidad, Sprite image, bool state){
        idItem = id;
        nameItem = name;
        cantidadItem = cantidad;
        imageItem = image;
        enCompra = state;
        agotado = false;
    }

    public int getIdItem(){
        return idItem;
    }

    public string getNameItem(){
        return nameItem;
    }

    public void setNameItem(string name){
        nameItem = name;
    }

    public int getCantidadItem(){
        return cantidadItem;
    }

    public void setCantidadItem(int cantidad){
        cantidadItem = cantidad;
    }

     public Sprite getImageItem(){
        return imageItem;
    }
    public void setStateItem(bool state){
        enCompra = state;
    }

     public bool getStateItem(){
        return enCompra;
    }

    public void setAgotadoItem(bool state){
        agotado = state;
    }

     public bool getAgotadoItem(){
        return agotado;
    }

    public string verItem(){
        return "State: " + enCompra + ", Agotado: " + agotado;
    }
}

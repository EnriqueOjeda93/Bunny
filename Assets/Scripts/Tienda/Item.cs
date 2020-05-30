using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    
    private string nameItem;
    private int cantidadItem;

    public Item(string name, int cantidad){
        nameItem = name;
        cantidadItem = cantidad;
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

    public string verItem(){
        return "NAme: " + nameItem + ", CantidadItem: " + cantidadItem;
    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items
{
    
    private List<Item> listItems;

    public Items(){
       listItems = new List<Item>();
    }

    public List<Item> getListaItems(){
        return listItems;
    }
    
    public void addItem(Item item){
        listItems.Add(item);

    }


}

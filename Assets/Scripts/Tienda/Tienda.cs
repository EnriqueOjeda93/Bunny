using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Tienda : MonoBehaviour
{
    private string[] listaCarne = new string[]{"Jabali","Conejo","Pollo","Ardilla","Ciervo","Pajaro"};

    private string[] listaPescado = new string[]{"Anguila","TruchaComun","TruchaArroyo","Bonito","Arenque"};
    [SerializeField]
    private Button prefabConsumible;
    [SerializeField]
    private Sprite jabali;
    [SerializeField]
    private Sprite conejo;
    [SerializeField]
    private Sprite pollo;
    [SerializeField]
    private GameObject contenedor1;

    [SerializeField]
    private Sprite atun;
    [SerializeField]
    private GameObject contenedor2;

    [SerializeField]
    private Button prefabCompra;
    private List<Button> listaBotonesCompra = new List<Button>();
    private List<Button> listaBotonesConsumibles = new List<Button>();

    [SerializeField]
    private GameObject contenedorCompra;
    private Items items = new Items();

    [SerializeField]
    public Player player;


    // Start is called before the first frame update
    void Awake()
    {
        initTienda();
    }


    private void initTienda(){
 
        Item item1 = new Item(0, "Jabali", 10, jabali, false);
        Item item2 = new Item(1, "Conejo", 10, conejo, false);
        Item item3 = new Item(2, "Pollo", 10, pollo, false);
        Item item4 = new Item(3, "Anguila", 10, atun, false);

        items.addItem(item1);
        items.addItem(item2);
        items.addItem(item3);
        items.addItem(item4);

        for (int i = 0; i < items.cantidadItems()-1; i++)
        {
            createItemsCarne(items.getListaItems()[i]);
        }

        createItemsPescaso(items.getListaItems()[items.cantidadItems()-1]);
    }

    private void createItemsCarne(Item item){

        Button g = Instantiate(prefabConsumible);
        
        g.onClick.AddListener(delegate() {eventItemSelect(item.getIdItem());});
        
        g.GetComponentInChildren<Image>().sprite = item.getImageItem();

        Text[] texts = g.GetComponentsInChildren<Text>();
    
        texts[0].text = item.getNameItem();
        texts[1].text = item.getCantidadItem()+"";

        g.transform.parent = contenedor1.transform;

        listaBotonesConsumibles.Add(g);
    }

    private void createItemsPescaso(Item item){

        Button g = Instantiate(prefabConsumible);
        
        g.onClick.AddListener(delegate() {eventItemSelect(item.getIdItem());});
        
        g.GetComponentInChildren<Image>().sprite = item.getImageItem();

        Text[] texts = g.GetComponentsInChildren<Text>();
    
        texts[0].text = item.getNameItem();
        texts[1].text = item.getCantidadItem()+"";

        g.transform.parent = contenedor2.transform;

        listaBotonesConsumibles.Add(g);
    }

    public void createItemsCompra(Item item){
        
        Button g = Instantiate(prefabCompra);
        g.onClick.AddListener(delegate() {eventItemReturned(item.getIdItem());});
        
        Text[] texts = g.GetComponentsInChildren<Text>();
    
        texts[0].text = item.getNameItem();
        texts[1].text = ((int.Parse(texts[1].text)) +1) +"";

        g.transform.parent = contenedorCompra.transform;

        cogerItem(item.getIdItem());

        listaBotonesCompra.Add(g);
    }

    private void eventItemSelect(int id){

        Item item = items.itemForId(id);

        player.reproducirSonido();
        if(!item.getAgotadoItem()){
            if(item.getStateItem()){
                
                cogerItem(id);
            }
            else {

                createItemsCompra(item);
                items.itemForId(id).setStateItem(true);
            }
        }
    }

    private void eventItemReturned(int id){

        player.reproducirSonido();
        devolverItem(id);
    }

    public void cogerItem(int id){
        
        Item item = items.itemForId(id);

        foreach (Button butonConsumible in listaBotonesConsumibles)
        {
            Text[] textsCarne = butonConsumible.GetComponentsInChildren<Text>();
            if(textsCarne[0].text == item.getNameItem()){

                if(butonConsumible.GetComponentsInChildren<Text>()[1].text != "0"){

                    butonConsumible.GetComponentsInChildren<Text>()[1].text = (int.Parse(butonConsumible.GetComponentsInChildren<Text>()[1].text) - 1) + "";

                    foreach (Button butonCompra in listaBotonesCompra)
                    {
                        Text[] textsCompra = butonCompra.GetComponentsInChildren<Text>();
                        if(textsCompra[0].text == item.getNameItem()){

                            butonCompra.GetComponentsInChildren<Text>()[1].text = (int.Parse(butonCompra.GetComponentsInChildren<Text>()[1].text) + 1) + "";
                        }
                    } 
                } else {

                    item.setAgotadoItem(true);
                }
            }
        }
    }

    public void devolverItem(int id){

        Item item = items.itemForId(id);

        foreach (Button butonConsumible in listaBotonesConsumibles)
        {
            Text[] textsCarne = butonConsumible.GetComponentsInChildren<Text>();
            if(textsCarne[0].text == item.getNameItem()){

                butonConsumible.GetComponentsInChildren<Text>()[1].text = (int.Parse(butonConsumible.GetComponentsInChildren<Text>()[1].text) + 1) + "";

                foreach (Button butonCompra in listaBotonesCompra)
                {
                    Text[] textsCompra = butonCompra.GetComponentsInChildren<Text>();
                    if(textsCompra[0].text == item.getNameItem()){

                        butonCompra.GetComponentsInChildren<Text>()[1].text = (int.Parse(butonCompra.GetComponentsInChildren<Text>()[1].text) - 1) + "";

                        if(butonCompra.GetComponentsInChildren<Text>()[1].text == "0"){
                            listaBotonesCompra.Remove(butonCompra);
                            item.setStateItem(false);
                            Destroy(butonCompra.gameObject);
                            return;
                        }

                    }
                } 

                if(item.getAgotadoItem()){

                    item.setAgotadoItem(false);
                }
            }
        }
    }

    public List<Button> getListCompra(){
        return listaBotonesCompra;
    }

    public void resetCompra(){
        
        player.reproducirSonido();

        for (int i = 0; i < listaBotonesCompra.Count; i++)
        {
            Destroy(listaBotonesCompra[i].gameObject);
        }

        foreach (Item item in items.getListaItems())
        {
            item.setStateItem(false);
        }

        listaBotonesCompra.Clear();
    }

   public void sumarRecurso(string nameRecurso, int cantidad){

        foreach (Button butonConsumible in listaBotonesConsumibles)
        {
            Text[] textsCompra = butonConsumible.GetComponentsInChildren<Text>();
            if(textsCompra[0].text == nameRecurso){

                butonConsumible.GetComponentsInChildren<Text>()[1].text = (int.Parse(butonConsumible.GetComponentsInChildren<Text>()[1].text) + cantidad) + "";
            }
        }

    }
}

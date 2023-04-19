using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSystem : MonoBehaviour
{
    //gold counter
    public Text moneyText;
    //public Text instructions;

    public static GameObject selection;
    public GameObject card;
    
    //amount to loop
    public int x;

    // Start is called before the first frame update
    void Start()
    {
        //instructions.text = "Choose a Card";
        selection = GameObject.Find("cardSelect");
        cardSelect();
    }

    void Update() {
        //sets gold display to gold so auto updates when something bought
        moneyText.text = SceneController.gold + "";
    }

    void cardSelect(){
        //check deck exists yet
        if (SceneController.deckMade == true) {
            StartCoroutine(Draw());
        }
    }

    IEnumerator Draw()
    {
        int x = 3; //how many cards visible

        //draws cards with animation
        for (int i = 0; i < x; i++)
        { //loop for drawing cards
            //yield return new WaitForSeconds(1);
            var temp = Instantiate(card, transform.position, transform.rotation);
            temp.transform.localScale = Vector3.one * 3.6f;
            temp.transform.SetParent(selection.transform);
            SoundSystem.play = "drawCard";
        }
        //make cards visible
        for (int i = 0; i < x; i++) {
            yield return new WaitForSeconds(1);
            SoundSystem.play = "drawCard";

            //different scripts depending on if looting or shopping
            if (gameObject.scene.name.Equals("Loot"))
            {
                CardSelect temp = selection.transform.GetChild(i).GetComponent<CardSelect>();
                //temp.transform.localScale = Vector3.one * 4f; //resize
                temp.cardBack.SetActive(false); //hide cover
                temp.gameObject.GetComponent<Draggable>().enabled = true;
            }
            else { //shop
                CardShop temp = selection.transform.GetChild(i).GetComponent<CardShop>();
                //temp.transform.localScale = Vector3.one * 4f;
                temp.cardBack.SetActive(false); //hide cover
                temp.gameObject.GetComponent<Draggable>().enabled = true;
            }
        }
    }

    //picked 1 card for looting
    public static void chosenLoot(CardSelect temp) {
        //add card to deck
        SceneController.staticDeck.Add(new Card(temp.id, temp.cardName, temp.cost, temp.attack, temp.description, temp.thisSprite));
        //selection has been made clear rest
        foreach (Transform child in selection.transform)
        {
            Destroy(child.gameObject);
        }

        SceneController.LoadMapScene(); //return to map
    }

    //picked a card for upgrading
    public static void chosenShop(CardShop temp)
    {
        //GameObject select = GameObject.Find("cardSelect"); //make new object cause cant access selection obj
        //CardShop temp = select.transform.GetChild(index).GetComponent<CardShop>(); //change from 0 to number
        temp.gameObject.GetComponent<Draggable>().enabled = false;
        
        //upgrade card in deck, cant spam
        if (SceneController.gold >= temp.cost) {

            Debug.Log("Upgrading "+temp.cardName);
            SceneController.staticDeck[temp.x].attack++;
            SceneController.gold -= temp.cost;

        }//needs to inform player cant afford otherwise
        //temp.cardBack.SetActive(true);
        
        //objects in 
        foreach (Transform child in selection.transform)
        {
            Draggable script = child.GetComponent<Draggable>();
            if (script == null || script.enabled == false)
            {
                Destroy(child.gameObject);
            }
        }

        //if all upgrades bought
        if (selection.transform.childCount == 0) {
            SceneController.LoadMapScene(); //return to map
        }
    }

    //finished in the shop, press anchor to return
    public void end() {
        SceneController.LoadMapScene();   
    }

}

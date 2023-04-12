using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSystem : MonoBehaviour
{
    //gold counter
    public Text moneyText;
    //public Text instructions;

    public GameObject selection;
    public GameObject card;
    
    //amount to loop
    public int x;

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = SceneController.gold+"";
        //instructions.text = "Choose a Card";
        cardSelect();
    }

    void cardSelect(){
        //check deck exists yet (lmao)
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
            temp.transform.SetParent(selection.transform);
            SoundSystem.play = "drawCard";
        }
        //make cards visible
        for (int i = 0; i < x; i++) {
            yield return new WaitForSeconds(1);

            //different scripts depending on if looting or shopping
            if (gameObject.scene.name.Equals("Loot"))
            {
                CardSelect temp = selection.transform.GetChild(i).GetComponent<CardSelect>();
                temp.cardBack.SetActive(false); //hide cover
                temp.gameObject.GetComponent<Draggable>().enabled = true;
            }
            else { //shop
                CardShop temp = selection.transform.GetChild(i).GetComponent<CardShop>();
                temp.cardBack.SetActive(false); //hide cover
                temp.gameObject.GetComponent<Draggable>().enabled = true;
            }
        }
    }

    //picked 1 card for looting
    public static void chosenLoot() {
        GameObject select = GameObject.Find("cardSelect"); //make new object cause cant access selection obj
        CardSelect temp = select.transform.GetChild(0).GetComponent<CardSelect>();
        temp.gameObject.GetComponent<Draggable>().enabled = false;
        //add card to deck
        SceneController.staticDeck.Add(new Card(temp.id, temp.cardName, temp.cost, temp.attack, temp.description, temp.thisSprite));
        SceneController.LoadMapScene(); //return to map
    }

    //picked a card for upgrading
    public static void chosenShop(int index)
    {
        GameObject select = GameObject.Find("cardSelect"); //make new object cause cant access selection obj
        CardShop temp = select.transform.GetChild(index).GetComponent<CardShop>(); //change from 0 to number
        temp.gameObject.GetComponent<Draggable>().enabled = false;
        
        //upgrade card in deck, cant spam
        if (SceneController.gold >= temp.cost && temp.cardBack==false) {

            Debug.Log("Upgrading "+temp.cardName);
            SceneController.staticDeck[temp.x].attack++;
            SceneController.gold -= temp.cost;

        }//needs to inform player cant afford otherwise
        temp.cardBack.SetActive(true);
    }

    //finished in the shop, press anchor to return
    public void end() {
        SceneController.LoadMapScene();   
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopSystem : MonoBehaviour
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
        x = 3;
        for (int i = 0; i < x; i++) {
            cardSelect();
        }
    }

    void cardSelect(){
        //check deck exists yet (lmao)
        if (SceneController.deckMade == true) {

            //get card to be a random one in players deck, from cardShop script+prefab
            var temp = Instantiate(card, transform.position, transform.rotation);
            temp.transform.SetParent(selection.transform);
        }
    }

    //finished in the shop, press anchor to return
    public void endShop() {
        SceneController.LoadMapScene();   
    }

}

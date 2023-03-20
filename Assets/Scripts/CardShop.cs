using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardShop : MonoBehaviour
{

    public int id;
    public string cardName;
    public int cost;
    public int attack;
    public string description;

    public GameObject cardBack; //cover

    public Text nameText;
    public Text costText;
    public Text attackText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    // Start is called before the first frame update
    void Start()
    {
        //gets random card from deck, allows multiple of same o.o
        int x = Random.Range(1, SceneController.staticDeck.Count);

        id = SceneController.staticDeck[x].id;
        name = SceneController.staticDeck[x].cardName;
        cost = SceneController.staticDeck[x].cost;
        attack = SceneController.staticDeck[x].attack;
        description = SceneController.staticDeck[x].description; //change to rollover/click on?

        thisSprite = SceneController.staticDeck[x].thisImage;

        //cant interact until all cards visible
        cardBack.SetActive(true);
        gameObject.GetComponent<Draggable>().enabled = false;

        nameText.text = "" + name;
        costText.text = "" + cost;
        attackText.text = "" + attack;
        descriptionText.text = "" + description;

        thatImage.sprite = thisSprite;
    }

}

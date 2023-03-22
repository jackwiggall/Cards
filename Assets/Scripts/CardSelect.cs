using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelect : MonoBehaviour
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
        int x = Random.Range(1, CardDatabase.crewList.Count);

        id = CardDatabase.crewList[x].id;
        cardName = CardDatabase.crewList[x].cardName;
        cost = CardDatabase.crewList[x].cost;
        attack = CardDatabase.crewList[x].attack;
        description = CardDatabase.crewList[x].description; //change to rollover/click on?

        thisSprite = CardDatabase.crewList[x].thisImage;

        //cant interact until all cards visible
        cardBack.SetActive(true);
        gameObject.GetComponent<Draggable>().enabled = false;

        nameText.text = "" + cardName;
        costText.text = "" + cost;
        attackText.text = "" + attack;
        descriptionText.text = "" + description;

        thatImage.sprite = thisSprite;
    }

}

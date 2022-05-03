using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization;
using System.Reflection;

public class ThisCard : MonoBehaviour {

    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int defense;
    public int attack;
    public string cardDescription;

    public Text nameText;
    public Text costText;
    public Text defenseText;
    public Text attackText;
    public Text descriptionText;

    public Sprite thisSprite;
    public Image thatImage;

    public bool cardBack;
    public static bool staticCardBack;


    // Start is called before the first frame update
    void Start()
    {
        thisCard[0] = CardDatabase.cardList[thisId];
    }

    // Update is called once per frame
    void Update()
    {
        id = thisCard[0].id;
        cardName = thisCard[0].cardName;
        cost = thisCard[0].cost;
        defense = thisCard[0].defense;
        attack = thisCard[0].attack;
        cardDescription = thisCard[0].cardDescription;

        thisSprite = thisCard[0].thisImage;


        nameText.text = ""+cardName;
        costText.text = ""+cost;
        defenseText.text = ""+defense;
        attackText.text = ""+attack;
        descriptionText.text = ""+cardDescription;

        thatImage.sprite = thisSprite;


        staticCardBack = cardBack;

    }
}

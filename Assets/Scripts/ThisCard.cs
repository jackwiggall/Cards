using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Globalization; //extra
using System.Reflection; //libraries?

public class ThisCard : MonoBehaviour {

    public List<Card> thisCard = new List<Card>();
    public int thisId;

    public int id;
    public string cardName;
    public int cost;
    public int attack;
    //public int health;
    public string description;
    public bool friendly;

    public Text nameText;
    public Text costText;
    public Text attackText;
    //public Text healthText;
    public Text descriptionText;//change to rollover/click on?

    public Sprite thisSprite;
    public Image thatImage;

    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;

    public static int noCardsDeck;
    public static int noEnemyDeck;

    public bool canSummon;
    public bool summoned;
    public GameObject Zone;
    public GameObject enemyZone;

    public GameObject TurnSwap;

    // Start is called before the first frame update
    void Start()
    {
        //need to fix this as it currently only allows for crew mates in the team, just add an if statement somehow 
        thisCard[0] = CardDatabase.crewList[thisId];
        noCardsDeck = PlayerDeck.deckSize;
        noEnemyDeck = aiDeck.deckSize;

        summoned = false;
        canSummon = false;
        Zone = GameObject.Find("inPlay");
        enemyZone = GameObject.Find("oppPlay");

        TurnSwap = GameObject.Find("TurnSystem");
    }

    // Update is called once per frame
    void Update()
    {
        //if this card is in the hand, show
        Hand = GameObject.Find("Hand");
        if (this.transform.parent == Hand.transform.parent) {
            cardBack = false;
        }

        staticCardBack = cardBack;

        if (this.tag == "inHand")
        {
            thisCard[0] = PlayerDeck.staticDeck[noCardsDeck - 1];
            noCardsDeck -= 1;
            PlayerDeck.deckSize -= 1;
            cardBack = false;
            friendly = true;
            this.tag = "Untagged";
        }
        if (this.tag == "oppHand")
        {
            thisCard[0] = aiDeck.staticEnemyDeck[noEnemyDeck - 1];
            noEnemyDeck -= 1;
            aiDeck.deckSize -= 1;
            cardBack = true;
            friendly = false;
            this.tag = "Untagged";
        }

        id = thisCard[0].id;
        name = thisCard[0].cardName;
        cost = thisCard[0].cost;
        attack = thisCard[0].attack;
        //health = thisCard[0].health; //no longer needing health of units
        description = thisCard[0].description; //change to rollover/click on?

        thisSprite = thisCard[0].thisImage;
        thisCard[0].friendly = friendly; //gets saved to card stats


        nameText.text = ""+name;
        costText.text = ""+cost;
        attackText.text = ""+attack;
        //healthText.text = "" + health;
        descriptionText.text = ""+description; //change to rollover/click on?

        thatImage.sprite = thisSprite;

        if (summoned == false)
        {
            if (friendly)
            {
                if (SceneController.gold >= cost && TurnSystem.isYourTurn == true)
                {
                    canSummon = true;
                }
                else {
                    canSummon = false;//no longer your turn or no longer the money
                }
            }
            else
            {
                if (TurnSystem.oppGold >= cost && TurnSystem.isYourTurn == false)
                {
                    canSummon = true;
                }
                else
                {
                    canSummon = false; //no longer opponents turn or no longer the money
                }
            }
        }

        if (canSummon == true && this.tag != "Deck" && friendly == true)
        { //prevents moving deck cards etc
            gameObject.GetComponent<Draggable>().enabled = true;
        }
        else gameObject.GetComponent<Draggable>().enabled = false;

        if (summoned == false && this.transform.parent == Zone.transform) //card technically already played just 
        {
            Summon();
        }
    }

    //card is getting played
    public void Summon() {
        if (friendly)
        {
            SceneController.gold -= cost;
        }
        else {
            TurnSystem.oppGold -= cost;
        }

        AI.pass = -1; //end turn adds 1 so this makes 0
        summoned = true;
        canSummon = false; //already summoned so cant resummon
        //sound effect?
        TurnSwap.GetComponent<TurnSwap>().EndTurn();
    }
}

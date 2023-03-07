using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//modified copy of player deck for the enemy
public class aiDeck : MonoBehaviour {

    public List<Card> deck = new List<Card>();
    public List<Card> container = new List<Card>();
    public static List<Card> staticEnemyDeck = new List<Card>();

    public int x; //random int
    public static int deckSize; //opp's decksize (will need to be set)
    public int maxHand; //max hand size?
    public int startHand; //initial hand size?

    //the 4 cards in the pile to visualise decksize
    //actual cards valueless?
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    public GameObject CardToAI;

    public GameObject[] Clones;

    public GameObject Hand;
    //public GameObject Zone;

    public GameObject CardBack;

    public static bool draw;

    // Start is called before the first frame update
    void Start()
    {
        deckSize = 10;
        maxHand = PlayerDeck.maxHand;
        startHand = PlayerDeck.startHand;

        //sets a random captain to the top of the deck
        x = Random.Range(1, CardDatabase.capList.Count);
        deck[deckSize-1] = CardDatabase.capList[x]; //put captain at bottom so drawn first

        //creates a deck with a random assortment of cards from the database
        for(int i=0;i<deckSize-1;i++)
        {
            //get random number
            x = Random.Range(1, CardDatabase.crewList.Count);
            //adds to deck array a random crew card
            deck[i] = CardDatabase.crewList[x];
        }

        Hand = GameObject.Find("oppHand");
        //Zone = GameObject.Find("oppPlay");
        StartCoroutine(StartGame()); //puts card into hand

        draw = true;

    }

    // Update is called once per frame
    void Update()
    {

        staticEnemyDeck = deck;

        //either change this so its called when it updates instead of always
        //or add if true here cause this just deletes if deck size less than, wont show if more added to pile

        //change numbers to corespond with decksize once decksize definite, i.e 4 is 3/4 full, 3 is 2/3, 2 is 1/3, 1 is remainder up to last card? 
        if (deckSize < 4)
        {
            cardInDeck1.SetActive(false);
        }
        else {
            cardInDeck1.SetActive(true);
        }
        //show hide 3 cards in deck
        if (deckSize < 3)
        {
            cardInDeck2.SetActive(false);
        }
        else
        {
            cardInDeck2.SetActive(true);
        }
        //show hide 2 cards in deck
        if (deckSize < 2)
        {
            cardInDeck3.SetActive(false);
        }
        else
        {
            cardInDeck3.SetActive(true);
        }

        //show hide 1 card in deck
        if (deckSize < 1)
        {
            cardInDeck4.SetActive(false);
        }
        else
        {
            cardInDeck4.SetActive(true);
        }

        if (TurnSystem.startTurn == true && TurnSystem.isYourTurn == false) {//broken
            //add calculation of card number to draw
            if (deckSize > 0 && Hand.transform.childCount < maxHand-1) //can only draw if card exists and space in hand
            {
                StartCoroutine(Draw(1));//change to value of card draw
                //draw = true;
            }
            else { 
                //no cards to draw, do something else?
            }
            TurnSystem.startTurn = false;
        }
    }

    IEnumerator Example()
    { //shows more cards in the pile when shuffle button is clicked
        yield return new WaitForSeconds(1);
        Clones = GameObject.FindGameObjectsWithTag("Clone");//make new tag?

        foreach (GameObject Clone in Clones)
        {
            Destroy(Clone);
        }
    }

    IEnumerator StartGame() 
    {
        //should draw be max hand size or only draw 3?
        for (int i = 0; i < startHand; i++) { //loop for starting hand
            yield return new WaitForSeconds(1);
            Instantiate(CardToAI, transform.position, transform.rotation);
        }
    }


    //reorganises the cards in the deck to a random order
    public void Shuffle()
    {
        for(int i=0; i < deckSize; i++) {
            container[0] = deck[i];
            int randomIndex = Random.Range(i, deckSize);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container[0];
        }

        Instantiate(CardBack, transform.position, transform.rotation);
        StartCoroutine(Example()); //creates new card in pile for shuffle effect

    }


    IEnumerator Draw(int x) {
        for (int i = 0; i < x; i++) {
            yield return new WaitForSeconds(1);
            Instantiate(CardToAI, transform.position, transform.rotation);
        }
    }
}

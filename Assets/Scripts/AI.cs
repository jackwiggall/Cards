using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//how the enemy works, currently basic design
public class AI : MonoBehaviour
{
    public GameObject Hand;
    public GameObject Zone;
    public GameObject TurnSwap;
    public Text turnText;

    public static bool play;
    public static int pass;
    public static bool end; //round over

    void Start() {
        Hand = GameObject.Find("oppHand");
        Zone = GameObject.Find("oppPlay");
        TurnSwap = GameObject.Find("TurnSystem");

        play = false;
        pass = 0;
        end = false;

    }

    // Update is called once per frame
    void Update() {
        //if opponents turn
        if (play) {
            play = false;

            StartCoroutine(wait());
        }
    }

    //stops turn from ending straight away and emptying hand on field
    IEnumerator wait() {
        if (Hand.transform.childCount > 0) {//if hand is empty end turn straight away
            yield return new WaitForSeconds(2);
            pickCard(); 
        }else {
            pass++;
            checkPass();
            TurnSwap.GetComponent<TurnSwap>().EndAI();
        }
        yield break;
    }

    void checkPass() {
        if (pass >= 2)
        { //amount of passes before end

            end = true; //activates ScoreSystem ending round
        }
    }

    //pick a card from hand to play
    void pickCard()
    {
        checkPass();
        //replace 7 with maxplaysize
        if (Hand.transform.childCount > 0 && Zone.transform.childCount < 7) //check hand isnt empty
        {
            if (TurnSystem.opPower>TurnSystem.power+1) { //card doesnt need to be played
                pass++;
                TurnSwap.GetComponent<TurnSwap>().EndAI();
                return;
            }

            for (int i = 0; i < Hand.transform.childCount; i++)
            {
                /*try
                {*/
                    ThisCard temp = Hand.transform.GetChild(i).GetComponent<ThisCard>(); //script not game object tho
                    //int gold = int.Parse(temp.GetComponent<Text>().text);
                    if (temp.canSummon == true) {
                        //Debug.Log("Can play"); //add if false stick in deck for reshuffle?

                        GameObject temp2 = Hand.transform.GetChild(i).gameObject;
                        //Destroy(Hand.transform.GetChild(i)); //delete original object
                        temp2.transform.SetParent(Zone.transform); //move card to zone
                        
                        temp.Summon();
                        temp.cardBack = false; //show card to player
                        TurnSwap.GetComponent<TurnSwap>().EndAI();
                        return;
                    }
                /*}
                catch
                {
                    //remove null error
                }*/
            }
        }
        pass++;
        TurnSwap.GetComponent<TurnSwap>().EndAI(); //turn is over, bot cant play
    }
}

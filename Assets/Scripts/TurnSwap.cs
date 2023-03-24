using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSwap : MonoBehaviour
{
    public Text turnText;

    public static bool skippable;

    void Start() {
        skippable = false;
    }

    public void canSkip() {
        skippable = true;
    }

    //pass when card played, removed from TurnSystem to here as vars needed passed through
    //if player passes then they cant play til round end?
    public void EndTurn()
    {
        if (AI.end == false) //if game not over AND ADD SKIPPABLE SYSTEM SO CAN ONLY SKIP AT CERTAIN TIMES
        {
            //stick if statement here so cant spam and remove option for end opponents turn
            if (TurnSystem.isYourTurn) //end your turn
            {
                TurnSystem.isYourTurn = false;
                TurnSystem.yourOpponentTurn += 1;
                turnText.text = "Opponent Turn";
                aiDeck.draw = false;
                AI.play = true;
                AI.pass++;
            }
            else
            { //end opponents turn, user not allowed
              //EndAI();
            }
            TurnSystem.startTurn = true;//starts next turn
        }
    }

    //ends the AI's turn
    public void EndAI() {
        if (AI.end == false) {
            TurnSystem.isYourTurn = true;
            TurnSystem.yourTurn += 1;
            turnText.text = "Your Turn";
            aiDeck.draw = true;
            TurnSystem.startTurn = true;//starts next turn
        }
    }
}

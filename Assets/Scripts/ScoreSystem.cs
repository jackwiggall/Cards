using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

    //indicators for who won
    public GameObject round1;
    public GameObject round2;
    public GameObject round3;

    int round; //best of 3
    int yourPoints; //how many u won
    int theirPoints; //how many u lost

    public Text turnText;

    Sprite tie;
    Sprite win;
    Sprite lose;

    bool finished; //is game over?
    bool victory;

    //player & ai draw new cards for new round
    public static bool drawPlayer;
    public static bool drawAI;

    public GameObject TurnSwap;

    // Start is called before the first frame update
    void Start()
    {
        //round1.GetComponent<Image>().sprite = Resources.Load<Sprite>("scoreEmpty");
        round = 1;

        yourPoints = 0;
        theirPoints = 0;

        finished = false;
        victory = false;

        drawAI = false;
        drawPlayer = false;

        tie = Resources.Load<Sprite>("scoreTie");
        win = Resources.Load<Sprite>("scoreGreen");
        lose = Resources.Load<Sprite>("scoreRed");

        TurnSwap = GameObject.Find("TurnSystem");
    }

    //looks if game is ending
    void Update() {
        if (AI.end == true) {
            AI.end = false;
            endRound();
        }
    }


    //round has ended
    void endRound()
    {
        Sprite result;
        if (TurnSystem.power == TurnSystem.opPower)
        {
            Debug.Log("Tie");
            turnText.text = "You Tied";
            yourPoints++;
            theirPoints++;
            victory = false;
            result = tie;
        }
        else if (TurnSystem.power > TurnSystem.opPower)
        {
            Debug.Log("You Win");
            turnText.text = "You Win";
            yourPoints++;
            victory = true;
            result = win;
        }
        else
        {
            Debug.Log("You Lose");
            turnText.text = "You Lose";
            theirPoints++;
            victory = false;
            result = lose;
        }
        checkRound(result);
        checkOver();
        StartCoroutine(delay());

    }

    void checkRound(Sprite result) {
        switch (round)
        {
            case 1:
                round1.GetComponent<Image>().sprite = result;
                break;
            case 2:
                round2.GetComponent<Image>().sprite = result;
                break;
            case 3:
                round3.GetComponent<Image>().sprite = result;
                break;
            default: //error?
                break;
        }
        
        round++;
    }

    //check if game is finished
    void checkOver() {

        if (yourPoints >= 2)
        { //you won so go to map
            finished = true;
            victory = true;
        }
        else if (theirPoints >= 2)
        { //you lost
            finished = true;
            victory = false;
        }
    }

    void EmptyBoard() {
        GameObject panel1 = GameObject.Find("inPlay");
        GameObject panel2 = GameObject.Find("oppPlay");

        foreach (Transform child in panel1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in panel2.transform)
        {
            Destroy(child.gameObject);
        }

        //start new game?
        drawAI = true;
        drawPlayer = true;
        StartCoroutine(newRound());
    }

    IEnumerator newRound() {
        yield return new WaitForSeconds(3);
        AI.pass = 0;
        //choose loser to start
        if (victory)
        {
            TurnSystem.isYourTurn = true;
            TurnSwap.GetComponent<TurnSwap>().EndTurn();
            Debug.Log("Opponents turn");
        }
        else {
            TurnSwap.GetComponent<TurnSwap>().EndAI();
            Debug.Log("Your turn");
        }
        yield break;
    }

    //game ended, delay before next event
    IEnumerator delay()
    {
        if (!finished)
        {
            turnText.text = "Round " + round;
            yield return new WaitForSeconds(2);
            EmptyBoard();
        }
        else {
            if (victory)
            {
                turnText.text = "Game Won";
                SceneController.gold += 20; //change to better value
                yield return new WaitForSeconds(2);
                SceneController.LoadMapScene();
            }
            else {
                turnText.text = "Game Lost";
                yield return new WaitForSeconds(2);
                SceneController.LoadMenuScene();
            }

        }
        yield break;
    }
}

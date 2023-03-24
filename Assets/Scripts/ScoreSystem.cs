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

    public int round;

    public Text turnText;

    public Sprite tie;
    public Sprite win;
    public Sprite lose;

    // Start is called before the first frame update
    void Start()
    {
        //round1.GetComponent<Image>().sprite = Resources.Load<Sprite>("scoreEmpty");
        round = 1;

        tie = Resources.Load<Sprite>("scoreEmpty");
        win = Resources.Load<Sprite>("scoreGreen");
        lose = Resources.Load<Sprite>("scoreRed");
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
            result = tie;
        }
        else if (TurnSystem.power > TurnSystem.opPower)
        {
            Debug.Log("You Win");
            turnText.text = "You Win";
            result = win;
        }
        else
        {
            Debug.Log("You Lose");
            turnText.text = "You Lose";
            result = lose;
        }
        StartCoroutine(delay());
        checkRound(result);

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

    //game ended, delay before next event
    IEnumerator delay()
    {
        yield return new WaitForSeconds(2);
        turnText.text = "Round "+round;
        //clear board, draw new cards
        yield break;
    }
}

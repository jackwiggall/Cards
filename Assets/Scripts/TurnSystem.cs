using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public static bool isYourTurn;
    public Text turnText;

    //public static int gold;
    public static int oppGold;
    public Text moneyText;
    public Text oppMoney;

    public static int power;
    public static int opPower;
    public Text powerText;
    public Text oppPower;

    public static bool startTurn; //is it the start of a turn

    public GameObject yourPlay;
    public GameObject oppPlay;

    // Start is called before the first frame update
    void Start()
    {

        yourPlay = GameObject.Find("inPlay");
        oppPlay = GameObject.Find("oppPlay");

        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = SceneController.gold + "";
        oppMoney.text = oppGold + "";

        int oppPow = 0;
        int yourPow = 0;
        
        if (yourPlay.transform.childCount > 0) {
            for (int i = 0; i < yourPlay.transform.childCount; i++)
            {
                try
                {
                    GameObject temp = yourPlay.transform.GetChild(i).Find("Attack").gameObject;
                    yourPow += int.Parse(temp.GetComponent<Text>().text);
                }
                catch { 
                    //remove null error
                }
            }
        }
        if (oppPlay.transform.childCount > 0)
        {
            for (int i = 0; i < oppPlay.transform.childCount; i++)
            {
                try
                {
                    GameObject temp = oppPlay.transform.GetChild(i).Find("Attack").gameObject;
                    oppPow += int.Parse(temp.GetComponent<Text>().text);
                }
                catch {
                    //remove null error
                }
            }
        }

        power = yourPow;
        opPower = oppPow;
        powerText.text = yourPow+"";
        oppPower.text = oppPow+"";
    }

    public void StartGame() { //either player or ai first
        int random = Random.Range(0,2);
        if (random == 0) {
            isYourTurn = true;
            turnText.text = "Your Turn";
        } else { 
            isYourTurn = false;
            turnText.text = "Opponent Turn";
            StartCoroutine(wait()); //needs delay before bot starts to draw all cards
        }
        //gold = 10;
        oppGold = 20;
        startTurn = false;
    }

    //stops turn from ending straight away for bot if play first
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        AI.play = true;
        yield break;
    }
}

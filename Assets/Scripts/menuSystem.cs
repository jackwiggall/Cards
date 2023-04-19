using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSystem : MonoBehaviour
{
    public void startButton() {

        //clear vars
        SceneController.gold = 20;
        SceneController.staticDeck = new List<Card>();
        SceneController.deckMade = false;
        SceneController.type = "null";

        //load first map
        SceneController.LoadMapScene();
    }

    public void quitButton() {
        Application.Quit();
    }
}

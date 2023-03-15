using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool reload = false; //returning to map
    public static bool deckMade = false; //for generating a deck the first time
    public static string type = "null"; //scene type just returned from
     
    
    //move to new script?
    public static int gold = 100;
    public static List<Card> staticDeck = new List<Card>(); //retain deck between games 

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public static void LoadBattleScene()
    {
        type = "battle";
        SceneManager.LoadScene("Battle");
    }

    public static void LoadMapScene()
    {
        reload = true;
        SceneManager.LoadScene("Map");
    }

    //previous scene
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool deckMade = false; //for generating a deck the first time
    public static string type = "null"; //scene type just returned from
    public static string level = "Menu"; //defaults to main menu

    //move to new script?
    public static int gold = 20;
    public static List<Card> staticDeck = new List<Card>(); //retain deck between battles 

    public static Animator animator;

    void Start() { 
        animator = GameObject.Find("Transition").GetComponent<Animator>();
    }

    public static void FadeToLevel() { //starts fade out animation
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(level);
    }

    public static void LoadMenuScene()
    {
        FadeToLevel();
        level = "Menu";
    }

    public static void LoadBattleScene()
    {
        type = "battle";
        level = "Battle";
        FadeToLevel();
    }

    public static void LoadShopScene()
    {
        type = "shop";
        level = "Shop";
        FadeToLevel();
    }

    public static void LoadLootScene()
    {
        type = "loot";
        level = "Loot";
        FadeToLevel();
    }

    public static void LoadMapScene()
    {
        level = "Map";
        FadeToLevel();
    }
    
    public static void LoadTutScene()
    {
        level = "Tutorial";
        FadeToLevel();
    }

    //previous scene, not used
    public static void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
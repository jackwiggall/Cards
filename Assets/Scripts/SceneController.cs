using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static bool reload = false;
    public static List<NodeDetails> nodes = new List<NodeDetails>();

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public static void LoadBattleScene()
    {
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
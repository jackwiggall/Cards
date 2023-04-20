using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorialSystem : MonoBehaviour
{
    public static GameObject selection;
    public GameObject card;

    //set textboxes
    public Text moneyText;
    public Text powerText;


    // Start is called before the first frame update
    void Start()
    {
        selection = GameObject.Find("cardSelect");
        cardSelect();
    }

    public void cardSelect() {
        var temp = Instantiate(card, transform.position, transform.rotation);
        temp.transform.localScale = Vector3.one * 3.6f;
        temp.transform.SetParent(selection.transform);
        
        StartCoroutine(Flip());
  
    }

    IEnumerator Flip()
    {
        yield return new WaitForSeconds(0.5f);
        CardSelect temp = selection.transform.GetChild(0).GetComponent<CardSelect>();
        SoundSystem.play = "drawCard";
        temp.cardBack.SetActive(false); //flip over card
        moneyText.text = "10-"+temp.cost;
        powerText.text = "0+"+temp.attack;
    }

    public void exit()
    {
        SceneController.LoadMenuScene();
    }
}

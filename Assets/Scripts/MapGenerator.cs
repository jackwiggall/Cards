using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapGenerator : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;

    //gold counter
    public Text moneyText;

    public GameObject ship;
    public GameObject node;

    Sprite shopButton;

    // Start is called before the first frame update
    void Start()
    {
        shopButton = Resources.Load<Sprite>("buttonCoin");

        clear();
        checkReload();
        moneyText.text = SceneController.gold+""; //change to new script
    }

    public void checkReload() {
        if (SceneController.reload != true)
        { //returning to previous map

            randomisation();
        }
        else {
            //first time on map
            reload();
        }
    }

    //empty map, technically not needed
    public void clear() {
        
        foreach (Transform child in panel1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in panel2.transform)
        {
            Destroy(child.gameObject);
        }
    }

    //add items to map
    public void generate() {

        var temp = Instantiate(node, transform.position, transform.rotation);
        int x = Random.Range(1, 3);
        if (x == 1)
        {
            temp.tag = "Shop";
            temp.GetComponent<Image>().sprite = shopButton;
        }
        else {
            temp.tag = "Battle";
        }
        temp.transform.SetParent(panel2.transform);
    }

    //choose what to generate
    public void randomisation() {
        //new in panel2
        int x = Random.Range(1, 3);
        //Debug.Log("panel2 "+ x);
        for (int i = 0; i < x; i++)
        {
            generate();
        }
    }

    public void clearPanel2() {
        foreach (Transform child in panel2.transform)
        {
            Destroy(child.gameObject);
        }
    }

    //return after an event
    public void reload() {

        //set previous area to whatever
        if (SceneController.type == "battle") {
            var temp = Instantiate(node, transform.position, transform.rotation);
            temp.tag = "Battle";
            temp.transform.SetParent(panel1.transform);
        }
        if (SceneController.type == "shop")
        {
            var temp = Instantiate(node, transform.position, transform.rotation);
            temp.tag = "Shop";
            temp.GetComponent<Image>().sprite = shopButton;
            temp.transform.SetParent(panel1.transform);
        }

        clearPanel2();
        randomisation();
    }
}

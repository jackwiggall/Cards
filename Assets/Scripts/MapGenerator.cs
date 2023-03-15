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

    // Start is called before the first frame update
    void Start()
    {
        //clear();
        checkReload();
        moneyText.text = SceneController.gold+""; //change to new script
    }

    public void checkReload() {
        if (SceneController.reload != true)
        { //returning to previous map

            clear();
            randomisation();
        }
        else {
            //first time on map
            clear();
            reload();
        }
    }

    //empty map
    public void clear() {
        
        foreach (Transform child in panel1.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in panel2.transform)
        {
            Destroy(child.gameObject);
        }
        //add ship to map
        //var temp = Instantiate(ship, transform.position, transform.rotation);
        //temp.transform.SetParent(panel1.transform);
    }

    //add items to map
    public void generate() {

        var temp = Instantiate(node, transform.position, transform.rotation);
        temp.tag = "Battle";
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

        clearPanel2();
        randomisation();
    }
}

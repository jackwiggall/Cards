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

    public GameObject node;
    
    //save the list of nodes for loading after, move to scene controller for reloadability
    //public static List<NodeDetails> nodes = new List<NodeDetails>();

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
        save();
    }

    //save current panel2
    public void save() {

        SceneController.nodes.Clear();
        foreach (Transform child in panel2.transform)
        {
            SceneController.nodes.Add(new NodeDetails("Skull"));
            //Debug.Log("saved");
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

        //old in panel1
        foreach (NodeDetails input in SceneController.nodes) { //need to get the string
            //Debug.Log(input.type+" working");
            var temp = Instantiate(node, transform.position, transform.rotation);
            temp.tag = "Battle";
            temp.transform.SetParent(panel1.transform);
            //Debug.Log("adding");
        }
        clearPanel2();
        randomisation();
    }
}

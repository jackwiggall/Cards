using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject panel1;
    public GameObject panel2;

    public GameObject node;
    
    //save the list of nodes for loading after
    public static List<NodeDetails> nodes = new List<NodeDetails>();

    // Start is called before the first frame update
    void Start()
    {
        clear();

        int x = Random.Range(1, 3);
        //Debug.Log(x);
        //creates a random amount of nodes
        for (int i = 0; i < x; i++)
        {
            generate();
        }
        save();
        reload();
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

    //save current panel2
    public void save() {

        nodes.Clear();
        foreach (Transform child in panel2.transform)
        {
            nodes.Add(new NodeDetails("Skull")); //out of range
        }
        clear();
    }

    //return after an event
    public void reload() {

        //old in panel1
        foreach (NodeDetails input in nodes) { //need to get the string
            //Debug.Log(input.type+" working");
            var temp = Instantiate(node, transform.position, transform.rotation);
            temp.tag = "Battle";
            temp.transform.SetParent(panel1.transform);

        }

        //new in panel2
        int x = Random.Range(1, 3);
        //Debug.Log(x);
        for (int i = 0; i < x; i++)
        {
            generate();
        }
    }
}

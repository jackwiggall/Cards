using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


//user clicks on node
public class NodeEvent : MonoBehaviour
{

    //player clicks on node
    public void onClick() {
        string name = EventSystem.current.currentSelectedGameObject.name;

        try
        {
            name = name.Substring(0, name.IndexOf(' '));//shortens so (1) is deleted
        }
        catch {}

        if (EventSystem.current.currentSelectedGameObject.transform.parent.name=="Panel2") { //if node is in right place
            Debug.Log(name + " Clicked");

            if (name == "battleButton") { 
                //save layout, start next game
            }

        } else {
            Debug.Log(name + " Invalid");
        }
    }

}

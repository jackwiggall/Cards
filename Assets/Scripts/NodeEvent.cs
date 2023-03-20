using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//user clicks on node
public class NodeEvent : MonoBehaviour
{

    public GameObject node;

    //player clicks on node
    public void onClick() {
        node = EventSystem.current.currentSelectedGameObject;
        /*string name = node.name;

        try
        {
            name = name.Substring(0, name.IndexOf('('));//shortens so (1) is deleted
        }
        catch {}*/

        if (node.transform.parent.name=="Panel2") { //if node is in right place
            //Debug.Log(name + " Clicked");

            if (node.tag == "Battle") { 
                Debug.Log("Start battle");
                SceneController.LoadBattleScene();
            }else if (node.tag == "Shop")
            {
                Debug.Log("Open shop");
                SceneController.LoadShopScene();
            }else if (node.tag == "Loot")
            {
                Debug.Log("Open loot");
                SceneController.LoadLootScene();
            }

        } else {
            //Debug.Log(name + " Invalid");
        }
    }

}

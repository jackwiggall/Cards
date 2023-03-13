using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CardBackPrefab : MonoBehaviour{

    public GameObject Deck;
    public GameObject It;

    // Start is called before the first frame update
    void Start()
    {
        //Clones a card for the shuffle animation
        Deck = GameObject.Find("Deck Panel");
        It.transform.SetParent(Deck.transform);
        It.transform.localScale = Vector3.one * 1.1f;
        It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        It.transform.eulerAngles = new Vector3(0, 0, 0);
    }

}

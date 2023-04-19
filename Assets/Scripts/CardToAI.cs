using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CardToAI : MonoBehaviour{

    public GameObject Hand;
    public GameObject It;

    // Start is called before the first frame update
    void Start()
    {
        Hand = GameObject.Find("oppHand");
        It.transform.SetParent(Hand.transform);
        It.transform.localScale = Vector3.one * 2f;
        It.transform.position = new Vector3(transform.position.x, transform.position.y, -48);
        It.transform.eulerAngles = new Vector3(0, 0, 0);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBack : MonoBehaviour {

    public GameObject cardBack;

    // Update is called once per frame
    void Update()
    {
        
        if(ThisCard.staticCardBack == true)
        {
            cardBack.SetActive(true);
        }
        else
        {
            cardBack.SetActive(false);
        }

    }
}

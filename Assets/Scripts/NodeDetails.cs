using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class NodeDetails
{
    public string type;

    public NodeDetails() { 
    
    }

    public NodeDetails(string input)
    {
        type = input;
    }
}

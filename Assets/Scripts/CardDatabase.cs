using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class CardDatabase : MonoBehaviour {

public static List<Card> cardList = new List<Card> ();

void Awake ()
{
		cardList.Add (new Card (0,"None", 0, 0, 0,"None", Resources.Load <Sprite>("Cardback") ));
		cardList.Add (new Card (1,"Amachi", 4, 2, 3,"Hyezaki general.", Resources.Load <Sprite>("amachi") ));
		cardList.Add (new Card (2,"Polnia", 5, 3, 4,"Empress of Marn and uniter of men.", Resources.Load <Sprite>("Polnia") ));
		cardList.Add (new Card (3, "Huntress", 3, 1, 2, "Descendant of Wolfcloak.", Resources.Load <Sprite>("hunteress") ));
	}
}

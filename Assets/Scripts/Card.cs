using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card { 

	public int id;
	public string cardName;
	public int cost;
	public int attack;
	//public int health;
	public string description;
	public bool friendly;

	public Sprite thisImage;
	

	public Card()
	{
		
	}

	public Card(int Id, string Name, int Cost,  int Attack, string Description, Sprite ThisImage)
	{
		id = Id;
		cardName = Name;
		cost = Cost;
		attack = Attack;
		//health = Health;
		description = Description;

		thisImage = ThisImage;

		friendly = false; //cards arent yours unless set
	}
	
}
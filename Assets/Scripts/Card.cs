using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card { 

	public int id;
	public string cardName;
	public int cost;
	public int defense;
	public int attack;
	public string cardDescription;

	public Sprite thisImage;
	


	public Card()
	{
		
	}

	public Card(int Id, string CardName, int Cost, int Defense,  int Attack, string CardDescription, Sprite ThisImage)
	{
		id = Id;
		cardName = CardName;
		cost = Cost;
		defense = Defense;
		attack = Attack;
		cardDescription = CardDescription;

		thisImage = ThisImage;
	}
	
}
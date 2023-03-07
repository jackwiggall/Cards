using System.Collections;
using System.Collections.Generic;
using System.Runtime.Versioning;
using UnityEngine;

public class CardDatabase : MonoBehaviour {

	//make different lists for different card types?
	public static List<Card> capList = new List<Card> ();
	public static List<Card> crewList = new List<Card>();

	void Awake ()
{
		//id, cardName, cost, attack, health, desc, img
		//captain costs 0 and added to hand turn 1,
		//all cards cost=0-5? min-attack=1
		capList.Add(new Card(0,"", 0, 0,"Captain", Resources.Load <Sprite>("") )); //min cost 0
		capList.Add(new Card(1, "Kidd", 0, 5, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(2, "Sparrow", 0, 4, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(3, "Kirt", 0, 5, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(4, "Ward", 0, 5, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(5, "Picardo", 0, 4, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(6, "LeChuck", 0, 4, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(7, "Threewood", 0, 5, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(8, "Bellamy", 0, 5, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(9, "Cavendish", 0, 4, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(10, "Archer", 0, 5, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(11, "Hook", 0, 4, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(12, "Fortune", 0, 4, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(13, "America", 0, 5, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(14, "Sisko", 0, 4, "Captain", Resources.Load<Sprite>("")));
		capList.Add(new Card(15, "Barbarossa", 0, 5, "Captain", Resources.Load<Sprite>("")));

		//all crew min cost=1
		crewList.Add(new Card(0, "", 1, 1, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(1,"Guybrush", 1, 1,"Crew", Resources.Load <Sprite>("") ));
		crewList.Add(new Card(2,"Murray", 2, 3,"Crew", Resources.Load <Sprite>(""))); //le skeleton
		crewList.Add(new Card(3, "Reacher", 1, 2, "Crew", Resources.Load <Sprite>("")));
		crewList.Add(new Card(4, "Sir Tzu", 3, 4, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(5, "Baroness", 2, 2, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(6, "Greybeard", 1, 1, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(7, "John Silver", 1, 2, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(8, "Will Taylor", 2, 3, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(9, "Pat Spens", 3, 4, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(10, "Henry Martin", 1, 1, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(11, "Katie Cruel", 4, 5, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(12, "Frank Drake", 2, 3, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(13, "Bart Roberts", 3, 3, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(14, "Ann Bonnie", 3, 4, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(15, "Calico Jake", 2, 3, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(16, "Charlie Vane", 4, 5, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(17, "Hornigold", 2, 4, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(18, "Davy Johns", 2, 3, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(19, "O'Malley", 1, 1, "Crew", Resources.Load<Sprite>("")));
		crewList.Add(new Card(20, "James Cook", 1, 2, "Crew", Resources.Load<Sprite>("")));


	}
}

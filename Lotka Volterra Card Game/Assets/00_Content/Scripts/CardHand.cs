using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardHand : MonoBehaviour {

	//Also needs to know how many cards it has, and it max size, and if they are empty.

	//Will hold cards,
	//Will tell the cards when they should be allowed to be interacted with.
	//Will receive cards, and send cards on.

	private List<OutpostCardObject> outpostCards = new();

	public int MaxHandSize { get; private set; }

	public int HandSize { get {	return outpostCards.Count; } }

	public bool IsFull { get { if (HandSize < MaxHandSize) return false; return true; } }

}

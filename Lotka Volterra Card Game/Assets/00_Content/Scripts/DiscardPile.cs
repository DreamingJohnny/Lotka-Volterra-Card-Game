using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscardPile : MonoBehaviour {

	//So, needs a stack then, that you can send cards to, and then functions for peeking at those and such.
	//Needs a function that can be reached by others, easily,
	//Yeah, it should have a reference to a top card.

	//And a queue
	//And when it gets a card it adds it to the stack, and it sends the topmost on to OutpostCardObject


	//So it has a place for a CardObject
	//And a stack of POCOs just the POCOs

	//I'll want to fix this pretty soon, so that this one actually doesn't have one to begin with, and so that it, as it gets new ones, send the old ones back presumably?
	//Perhaps going by an event for "UnUsedCards" or something like that?
	private CardObject topDiscardCard;

	private Stack<CardScript> cardPile;

	public int AmountOfCards { get { return cardPile.Count; } }

	void Start() {
		cardPile = new Stack<CardScript>();
	}

	public void SendToDiscard(CardScript cardScript) {
		//Should I add a return function here instead? so that if it doesn't have one then nothing happens?
		if (topDiscardCard != null) {
			topDiscardCard.SetCardScriptBase(cardScript);
			topDiscardCard.gameObject.SetActive(true);
		}

		cardPile.Push(cardScript);
		//I'm adding a fast teleport here, just for now.
		topDiscardCard.transform.position = transform.position;
	}
}

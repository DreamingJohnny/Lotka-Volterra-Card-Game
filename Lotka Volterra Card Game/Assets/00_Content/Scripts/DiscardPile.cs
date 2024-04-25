using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscardPile : MonoBehaviour {

	//So, needs a stack then, that you can send cards to, and then functions for peeking at those and such.
	//Needs a function that can be reached by others, easily,
	//In the long run, we probably want this to also handle things about animation and movement of the card and such.
	//In fact, it will probably want to hold it's own card, right?
	//Yeah, it should have a reference to a top card.

	//So it needs an OutpostCardObject,
	//And it should begin with it turned off.
	//And a queue
	//And when it gets a card it adds it to the stack, and it sends the topmost on to OutpostCardObject

	//So we will want to handle the animations in some way... although, shouldn't they maybe be on the actual card? Like isn't the card capable of that.
	//Actually, should this one even have a card to begin with? Isn't it better that it takes the POCO from each cardObject, and then destroys all but the topmost card?

	//It also needs to have a space on the board though, do I just want an object for that?
	//So it has a place for a CardObject
	//And a stack of POCOs

	//I'll want to fix this pretty soon, so that this one actually doesn't have one to begin with, and so that it, as it gets new ones, send the old ones back presumably?
	//Perhaps going by an event for "UnUsedCards" or something like that?
	[SerializeField] private CardObject topDiscardCard;

	private Stack<CardScript> cardPile;

	public int AmountOfCards { get { return cardPile.Count; } }

	void Start() {
		cardPile = new Stack<CardScript>();

		topDiscardCard.gameObject.SetActive(false);
	}

	public void SendToDiscard(CardScript cardScript) {
		//Should I add a return function here instead? so that if it doesn't have one then nothing happens?
		if (topDiscardCard != null) {
			topDiscardCard.SetCardScriptBase(cardScript);
			topDiscardCard.gameObject.SetActive(true);
		}

		cardPile.Push(cardScript);
		//I'm adding a fast teleport here, just for now.
		//topDiscardCard.transform.position = transform.position;
	}
}

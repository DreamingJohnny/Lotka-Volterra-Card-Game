using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscardPile : MonoBehaviour {

	//So, needs a stack then, that you can send cards to, and then functions for peeking at those and such.
	//Needs a function that can be reached by others, easily,
	//Yeah, it should have a reference to a top card.


	//So it has a place for a CardObject
	//And a stack of POCOs just the POCOs

	//I'll want to fix this pretty soon, so that this one actually doesn't have one to begin with, and so that it, as it gets new ones, send the old ones back presumably?
	//Perhaps going by an event for "UnUsedCards" or something like that?
	private CardObject topDiscardCard;

	private Stack<SO_CardData> cardPile;

	public int AmountOfCards { get { return cardPile.Count; } }

	public bool HasTopCardObject { get { if (topDiscardCard == null) return false; return true; } }

	public event Action<CardObject> OnUnUsedCard;
	public event Action<DiscardPile> OnCardNeeded;

	void Start() {
		cardPile = new Stack<SO_CardData>();
		topDiscardCard = null;
	}

	public void GetCard() {
		//So, this function will return the topCard, before that, it will check if it needs a new card, and if yes, it will ask for it.
		//So, this will also need to take the SO out of the list then?

		//What happens if you ask for more than one card? Does each card, as they come in, get the SO from the top?

		//Does it begin by checking that? So if it recieves a card that doesn't have a SO, then it sets it up with one from the top?

	}

	public CardObject GetTopDiscardCard() {
		if (topDiscardCard == null) return null;
		else {
			CardObject temp = topDiscardCard;
			topDiscardCard = null;
			if (AmountOfCards > 1) {
				OnCardNeeded?.Invoke(this);
				//I'm thinking/hoping that this line will remove the CardData from the stack, seeing as the card is removed.
				cardPile.Pop();
			}
			return temp;
		}
	}

	//Pretty sure this method still won't work if you ask for the Data in the top card right?
	public bool GetCardData(int index, out SO_CardData sO_CardData) {
		if (AmountOfCards >= index) {
			List<SO_CardData> tempCardDatas = cardPile.ToListPooled();
			sO_CardData = tempCardDatas[index];

			foreach (var cardData in tempCardDatas) {
				//I need to check what this does to the order of the content
				cardPile.Push(cardData);
			}

			
			//Also here, what should it do if you ask it for a data, it sends it, but then it is empty so it doesn't actually need a card?
			if (AmountOfCards <= 0) OnCardNeeded?.Invoke(this);

			return true;
		}
		else {
			sO_CardData = null;
			return false;
		}
	}

	public void RecieveCard(CardObject card) {
		cardPile.Push(card.CardScript.GetCardData);
		SetTopCard(card);
	}

	private void SetTopCard(CardObject card) {

		card.transform.SetParent(transform, false);

		if (topDiscardCard != null) {
			OnUnUsedCard?.Invoke(topDiscardCard);
		}

		topDiscardCard = card;
	}
}
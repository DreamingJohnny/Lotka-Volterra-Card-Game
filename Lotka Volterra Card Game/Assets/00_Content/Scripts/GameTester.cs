using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTester : MonoBehaviour {

	[SerializeField] private CardZone receivingCardZone;
	[SerializeField] private CardZone secondaryCardZone;
	[SerializeField] private CardZone triaryCardZone;
	//[SerializeField] private CardObject cardObject;
	[SerializeField] private CardPool cardPool;

	[SerializeField] private List<SO_CardData> cardDatas;

	private int alternateIndex = 0;

	void Start() {

	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (alternateIndex <= 5) {
				receivingCardZone.TryAddCard(cardPool.GetCardObject(cardDatas[alternateIndex]));
			}
			else if (alternateIndex <= 10) {
				var receivingCard = receivingCardZone.GetCardsMatching(card => card.CardScript.HasTrait(Trait.Soldier));

				if (receivingCard.Count > 0) {
					Debug.Log($"Returning card {receivingCard[0].name} to the card pool.");
					//TODO: Decide if you really want to remove and returns cards to the card pool like this.
					receivingCardZone.RemoveCard(receivingCard[0]);
					cardPool.ReturnCardObject(receivingCard[0]);
				}
			}
			else if(alternateIndex <= 15) {
				receivingCardZone.TryAddCard(cardPool.GetCardObject(cardDatas[alternateIndex]));
			}
			alternateIndex++;
		}

	}

	//private void DoTestingCardDeck() {
	//	Debug.Log("Testing CardDeck...");
	//	Debug.Log(surfaceDeck.GetCardAmount(out int amount));
	//	if (amount > 0) {
	//		Debug.Log($"There are {amount} cards in the surfaceDeck");
	//		if (surfaceDeck.GetTopCard(out SO_CardData surfaceCardData)) {
	//			Debug.Log($"The top card is {surfaceCardData.name}");
	//		}
	//		else {
	//			Debug.Log("There was no top card in the surfaceDeck");
	//		}
	//	}
	//	else {
	//		Debug.Log("There are no cards in the surfaceDeck");
	//	}

	//	for (int i = 0; i < 10; i++) {
	//		Debug.Log("Shuffling surfaceDeck...");
	//		surfaceDeck.ShuffleDeck();
	//		Debug.Log("Topcard after shuffling:");
	//		if (surfaceDeck.GetTopCardName(out string cardname)) {
	//			Debug.Log(cardname);
	//		}
	//		else {
	//			Debug.Log("There was no top card in the surfaceDeck");
	//		}
	//	}
	//}
}
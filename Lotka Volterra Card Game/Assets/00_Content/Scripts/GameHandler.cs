using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[SerializeField] private CardDeck outpostDeck;
	[SerializeField] private CardHand playerHand;
	
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private SurfaceZone surfaceZone;

	void Start() {
		BruteTestPlayerCardHand();

		BruteTestSurfaceZone();
	}

	private void BruteTestSurfaceZone() {
		//Pull top card from surface deck, give to surfaceZone,
		//SurfaceZone then needs to create a card, set the values, and then move it to the correct spot.
		ScriptableObject scriptableObject = surfaceDeck.GetTopCard();

		surfaceZone.NewSurfaceCard(scriptableObject as SO_SurfaceCard);
	}

	private void BruteTestPlayerCardHand() {
		//Time to test the cardhand then
		while (playerHand.HandSize <= playerHand.MaxHandSize) {

			ScriptableObject scriptableObject = outpostDeck.GetTopCard();

			playerHand.TakeACard(scriptableObject as SO_OutpostCard);
		}
	}

	void Update() {

	}
}

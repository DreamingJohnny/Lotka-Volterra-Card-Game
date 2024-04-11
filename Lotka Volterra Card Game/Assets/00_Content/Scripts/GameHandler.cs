using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[SerializeField] private OutpostDeck outpostDeck;

	[SerializeField] private CardHand playerHand;

	void Start() {
		BruteTestPlayerCardHand();
	}

	private void BruteTestPlayerCardHand() {
		//Time to test the cardhand then
		while (playerHand.HandSize <= playerHand.MaxHandSize) {

			ScriptableObject scriptableObject = outpostDeck.GetTopCard();

			SO_OutpostCard testObject = scriptableObject as SO_OutpostCard;

			playerHand.TakeACard(testObject);
		}
	}

	void Update() {

	}
}

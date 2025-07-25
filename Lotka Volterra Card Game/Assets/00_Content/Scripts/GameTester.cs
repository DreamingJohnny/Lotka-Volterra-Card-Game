using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTester : MonoBehaviour {

	[SerializeField] private CardZone mainCardZone;
	[SerializeField] private CardZone secondaryCardZone;
	[SerializeField] private CardZone triaryCardZone;
	[SerializeField] private CardObject cardObject;
	[SerializeField] private CardPool cardPool;

	[SerializeField] private List<SO_CardData> cardDatas;

	private int testInt = 0;
	private CardZone sending;
	private CardZone receiving;

	void Start() {
		while (testInt < 10) {
			if (testInt % 2 == 0) {
				sending = mainCardZone;
				testInt++;
			}
			else {
				sending = secondaryCardZone;
				testInt++;
			}
			sending.TryAddCard(cardPool.GetCardObject(cardDatas[testInt]));

			if (sending.Cards.Count <= 0) {
				Debug.Log("No cards in zone.");
			}
		}
		sending = secondaryCardZone;
		receiving = triaryCardZone;
	}

	void Update() {

		if (Input.GetKeyDown(KeyCode.Space)) {
			//Get a card from a zone and and it to another zone.
			if (sending.Cards.Count > 0) {
				int randomIndex = UnityEngine.Random.Range(0, sending.Cards.Count);

				CardObject cardToMove = sending.Cards[randomIndex];

				if (!receiving.TryAddCard(cardToMove)) {
					Debug.LogWarning($"Failed to move card {cardToMove.CardScript.GetCardName} from {sending.name} to {receiving.name}.");
				}
			}
			else {
				if (sending == secondaryCardZone) {
					Debug.Log("No cards to move, switching sender and receiver.");
					sending = triaryCardZone;
					receiving = secondaryCardZone;
				}
				else if (sending == triaryCardZone) {
					Debug.Log("No cards to move, switching sender and receiver.");
					sending = secondaryCardZone;
					receiving = triaryCardZone;
				}
			}
		}
	}
}
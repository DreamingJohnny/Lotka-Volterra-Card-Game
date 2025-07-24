using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTester : MonoBehaviour {

	[SerializeField] private CardZone mainCardZone;
	[SerializeField] private CardZone secondaryCardZone;
	[SerializeField] private CardObject cardObject;
	[SerializeField] private CardPool cardPool;

	[SerializeField] private SO_OutpostCardData outpostCardData;

	private int testInt = 0;
	private CardZone designated;

	void Start() {
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log("Trying to add card to zone...");
			if (testInt % 2 == 0) {
				designated = mainCardZone;
				testInt++;
				Debug.Log("Using mainCardZone.");
			} else {
				Debug.Log("Using secondaryCardZone.");
				designated = secondaryCardZone;
				testInt++;
			}
			bool status = designated.TryAddCard(cardPool.GetCardObject(outpostCardData));
			
			Debug.Log($"Card added: {status}");
			Debug.Log($"Card zone now has {designated.Cards.Count} cards.");
			if (mainCardZone.Cards.Count > 0) {
				Debug.Log($"First card in zone: {designated.Cards[0].CardScript.GetCardName}");
			} else {
				Debug.Log("No cards in zone.");
			}
		}
	}
}

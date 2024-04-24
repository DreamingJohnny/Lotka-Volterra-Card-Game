using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[Header("Player")]
	[SerializeField] private CardDeck outpostDeck;
	[SerializeField] private DiscardPile outpostDiscardPile;
	[SerializeField] private CardHand playerHand;
	[SerializeField] private CardZone personalityZone;

	[Header("Surface")]
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private DiscardPile surfaceDiscardPile;
	[SerializeField] private CardZone surfaceZone;

	[Header("General")]
	[SerializeField] private List<SO_SurfaceCardData> sO_SurfaceCardDatas;
	[SerializeField] private List<SO_OutpostCardData> sO_OutpostCardDatas;

	[Header("Ugly Testing")]
	[SerializeField] private SO_CardData testCardData;
	[SerializeField] private CardObject testCard;

	void Start() {

		BruteTestingPersonalityZone();
	}

	private void BruteTestingPersonalityZone() {
		testCard.SetCardScript(new OutpostCardScript(testCardData));
		personalityZone.AddCard(testCard);
	}
}

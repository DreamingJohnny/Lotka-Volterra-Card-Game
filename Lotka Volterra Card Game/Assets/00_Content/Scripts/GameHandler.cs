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
	[SerializeField] private OutpostCardObject testCard;

	void Start() {

		BruteTestingPersonalityZone();

		BruteTestingDiscardPile();
	}

	private void BruteTestingDiscardPile() {
		Instantiate(testCard);
		testCard.SetCardScript(new OutpostCardScript(sO_OutpostCardDatas[0]));
		outpostDiscardPile.SendToDiscard(testCard);

		Instantiate(testCard);
		testCard.SetCardScript(new OutpostCardScript(sO_OutpostCardDatas[1]));
		personalityZone.AddCard(testCard);
		outpostDiscardPile.SendToDiscard(testCard);
	}

	private void BruteTestingPersonalityZone() {
		testCard.SetCardScript(new OutpostCardScript(sO_OutpostCardDatas[0]));
		personalityZone.AddCard(testCard);

		Instantiate(testCard);
		testCard.SetCardScript(new OutpostCardScript(sO_OutpostCardDatas[1]));
		personalityZone.AddCard(testCard);
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

	[Header("Player")]
	[SerializeField] private CardDeck outpostDeck;
	[SerializeField] private DiscardPile outpostDiscardPile;
	[SerializeField] private CardZone playerHand;
	[SerializeField] private CardZone personalityZone;
	[SerializeField] private CardZone outpostZone;
	[SerializeField] private CardZone developmentZone;
	[SerializeField] private OutpostCardObject outpostCardObject;
	private Queue<OutpostCardObject> outpostCards;

	[Header("Surface")]
	[SerializeField] private CardDeck surfaceDeck;
	[SerializeField] private DiscardPile surfaceDiscardPile;
	[SerializeField] private CardZone surfaceZone;
	private Queue<SurfaceCardObject> surfaceCards;

	[Header("General")]
	[SerializeField] private List<SO_SurfaceCardData> sO_SurfaceCardDatas;
	[SerializeField] private List<SO_OutpostCardData> sO_OutpostCardDatas;

	[Header("Interactions")]
	private CardObject selectedCard;

	[Header("Ugly Testing")]
	[SerializeField] private GameObject tabletopCanvas;
	[SerializeField] private SO_CardData testCardData;
	[SerializeField] private OutpostCardObject testCard;
	private int testIndex = 0;

	[SerializeField] private ObjectPool objectPooler;

	void Start() {

		selectedCard = null;

		outpostCards = new Queue<OutpostCardObject>();
		//surfaceCards = new Queue<SurfaceCardObject>();

		//BruteTestingObjectPooling();

		//BruteTestingCardTransfer();

		//BruteTestingDiscardPile(new OutpostCardScript(sO_OutpostCardDatas[1]));

		FirstTestOfSelections();

    }

	private void FirstTestOfSelections() {
		playerHand.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		personalityZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		outpostZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		developmentZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;

		foreach (SO_OutpostCardData cardData in sO_OutpostCardDatas) {
			CardObject temp = GetCardObject(new OutpostCardScript(cardData));
			temp.transform.SetParent(playerHand.transform, false);
			temp.gameObject.SetActive(true);
			Debug.Log("Card created!");
		}

	}

	private void Update() {
		
	}

	private void BruteTestAddingTrait() {

		Debug.Log("Testing to add traits...");

		CardObject cardObject = GetCardObject(new OutpostCardScript(sO_OutpostCardDatas[0]));
		cardObject.transform.SetParent(tabletopCanvas.transform);
		cardObject.transform.position = Vector3.zero;

		cardObject.CardScript.AddTraits(Trait.Assistant);
		cardObject.CardScript.AddTraits(Trait.Commander);
		cardObject.CardScript.AddTraits(Trait.Environment);

		if (cardObject.CardScript.GetTraits(out List<Trait> traits)) {
			foreach (Trait trait in traits) {
				Debug.Log(trait);
			}
		}
	}

	private void BruteTestingCardTransfer() {
		Debug.Log("Sending card to other zone.");
		developmentZone.AddCard(outpostZone.GetCard(0));
	}

	private void BruteTestingOutpostZone() {
		foreach (SO_OutpostCardData cardData in sO_OutpostCardDatas) {
			outpostZone.AddCard(GetCardObject(new OutpostCardScript(cardData)));
		}
	}

	private void BruteTestingObjectPooling() {
		Debug.Log(objectPooler.ObjectPoolAmount);

		GameObject test = objectPooler.GetObject();
		test.SetActive(true);
		test.transform.position = Vector3.zero;
	}

	/// <summary>
	/// Adds the card to the queue of cards and sets the gameobject to inactive
	/// </summary>
	/// <param name="outpostCardObject"></param>
	private void AddUnusedCard(OutpostCardObject outpostCardObject) {
		outpostCards.Enqueue(outpostCardObject);
		outpostCardObject.gameObject.SetActive(false);
	}

	/// <summary>
	/// Adds the card to the queue of cards and sets the gameobject to inactive
	/// </summary>
	/// <param name="surfaceCardObject"></param>
	private void AddUnusedCard(SurfaceCardObject surfaceCardObject) {
		surfaceCards.Enqueue(surfaceCardObject);
		surfaceCardObject.gameObject.SetActive(false);
	}

	/// <summary>
	/// Returns an activated gameobject outpostCardObject populated with the script. Reuses gameobject when possible.
	/// </summary>
	/// <param name="outpostCardScript"></param>
	/// <returns></returns>
	private OutpostCardObject GetCardObject(OutpostCardScript outpostCardScript) {
		if (outpostCards.Count <= 0) {
			Debug.Log("Creating a new outpostcard object");
			OutpostCardObject outpostCard = Instantiate(outpostCardObject);
			outpostCard.SetCardScript(outpostCardScript);
			outpostCard.GetComponent<CardSelection>().OnCardSelected += HandleOnCardSelected;
			return outpostCard;
		}
		else {
			OutpostCardObject outpostCard = outpostCards.Dequeue();
			outpostCard.SetCardScript(outpostCardScript);
			outpostCard.gameObject.SetActive(true);
			return outpostCard;
		}
	}

	private void HandleOnCardSelected(object sender, EventArgs e) {
		Debug.Log($"{sender} was just clicked and the event registered by the GM!");
		
		if(sender.GetType() == typeof(CardObject)) { 
			selectedCard = sender as CardObject;
		}
		else {
			Debug.Log("The GM just registered an event for a object that doesn't seem to be a CardObject");
		}
	}

	private void HandleOnZoneSelected(object sender, EventArgs e) {
		Debug.Log($"{sender} was just clicked and the event registered by the GM!");

		if (selectedCard == null) {
			Debug.Log("SelectedCard was null");
			return;
		} else {
			CardZone cardZone = sender as CardZone;
			selectedCard.transform.SetParent(cardZone.transform, false);
			selectedCard = null;
		}
	}

	/// <summary>
	/// Returns an activated surfaceCardObject-gameobject populated with the script. Reuses gameobject when possible.
	/// </summary>
	/// <param name="surfaceCardScript"></param>
	/// <returns></returns>
	private SurfaceCardObject GetCardObject(SurfaceCardScript surfaceCardScript) {
		if (surfaceCards.Count <= 0) {
			SurfaceCardObject surfaceCard = new();
			surfaceCard.SetCardScript(surfaceCardScript);
			surfaceCard.GetComponent<CardSelection>().OnCardSelected += HandleOnCardSelected;
			return surfaceCard;
		}
		else {
			SurfaceCardObject surfaceCard = surfaceCards.Dequeue();
			surfaceCard.SetCardScript(surfaceCardScript);
			surfaceCard.gameObject.SetActive(true);
			return surfaceCard;
		}
	}

	private void BruteTestingDiscardPile(CardScript cardScript) {
		outpostDiscardPile.SendToDiscard(cardScript);
	}

	private void BruteTestingPersonalityZone(OutpostCardObject outpostCardObject) {
		personalityZone.AddCard(outpostCardObject);
	}
}

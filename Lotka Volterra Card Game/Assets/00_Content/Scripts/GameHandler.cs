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

	[SerializeField] private DiscardPile testCardPile;

	[SerializeField] private ObjectPool objectPooler;

	void Start() {

		selectedCard = null;

		outpostCards = new Queue<OutpostCardObject>();

		FirstTestOfSelections();
	}

	private void FirstTestOfSelections() {
		playerHand.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		personalityZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		outpostZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		developmentZone.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;
		testCardPile.GetComponent<ZoneSelection>().OnZoneSelection += HandleOnZoneSelected;

		foreach (SO_OutpostCardData cardData in sO_OutpostCardDatas) {
			CardObject temp = GetCardObject(new OutpostCardScript(cardData));
			temp.transform.SetParent(playerHand.transform, false);
			temp.gameObject.SetActive(true);
			Debug.Log("Card created!");
		}
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {

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

	private void HandleOnCardSelected(CardSelection card) {

		if (card.TryGetComponent(out CardObject cardObject)) {
			selectedCard = cardObject;
		}
		else {
			Debug.Log("The GM just registered an event for a object that doesn't seem to be a CardObject");
		}
	}

	private void HandleOnZoneSelected(ZoneSelection zone) {

		if (selectedCard == null) {
			Debug.Log("SelectedCard was null");
			return;
		}
		else {
			if (zone.TryGetComponent(out CardZone cardZone)) {
				if (cardZone.IsCardAllowed(selectedCard)) {
					//Later on, I want to have a think here, where I send the card of to a function, and I get it back if it isn't acceptable, what would that be like?
					selectedCard.transform.SetParent(zone.transform, false);
					selectedCard = null;
				}
			}
			else if (zone.TryGetComponent(out DiscardPile discardPile)) {
				discardPile.RecieveCard(selectedCard);
			}
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
}

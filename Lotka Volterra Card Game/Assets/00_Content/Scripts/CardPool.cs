/*
 * CardPool.cs
 * Summary: Handles the object pool for the card objects.
 * Is called by scripts needing card objects, and retrieves them when they should no longer be in use.
 * When receiving cards it will deactivate them and remove their carddata.
 * When asked for a cardobject, it either activates one, or, if there are no inactive ones, it creates a new cardobject, assigns it the carddata is has been given,
 * and then returns that cardobject.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPool : MonoBehaviour {

	private static CardPool instance;

	public static CardPool Instance {
		get {
			if (instance != null) return instance;

			instance = FindAnyObjectByType<CardPool>();
			if (instance != null) return instance;

			GameObject cardPoolObject = new();
			instance = cardPoolObject.AddComponent<CardPool>();
			return instance;
		}
		private set { instance = value; }
	}

	//TODO: Pretty sure that I don't need the serialized references here since I will just instantiate them when I need them?
	//Unsure how necessary these two actually are? Seeing as I cannot instantiate here...
	[SerializeField] private SurfaceCardObject surfaceCardPrefab;
	[SerializeField] private OutpostCardObject outpostCardPrefab;

	private Queue<SurfaceCardObject> surfaceCards = new();
	private Queue<OutpostCardObject> outpostCards = new();

	private void Awake() {
		if (Instance != null && Instance != this) { Destroy(this); } else { Instance = this; }
	}

	/// <summary>
	/// Gets a suitable card object from one of the two card queues pool (or instantiates a new one if the queue is empty),
	/// assigns the given card data, and returns it, still deactivated.
	/// </summary>
	/// <param name="cardData"></param>
	/// <returns></returns>
	public CardObject GetCardObject(SO_CardData cardData) {
		//If the cardScript is a SurfaceCardScript, then we get a SurfaceCardObject.
		if (cardData is SO_SurfaceCardData surfaceCardData) {

			SurfaceCardObject card = (surfaceCards.Count > 0) ? surfaceCards.Dequeue() : Instantiate(surfaceCardPrefab);
			card.SetCardScript(new SurfaceCardScript(surfaceCardData));
			//TODO: Later on, I'll want to be more systematic with when I activate the card, but for now, this is fine.
			card.gameObject.SetActive(true);
			return card;
		}
		else if (cardData is SO_OutpostCardData outpostCardData) {

			OutpostCardObject card = (outpostCards.Count > 0) ? outpostCards.Dequeue() : Instantiate(outpostCardPrefab);
			card.SetCardScript(new OutpostCardScript(outpostCardData));
			//TODO: Later on, I'll want to be more systematic with when I activate the card, but for now, this is fine.
			card.gameObject.SetActive(true);
			return card;
		}
		else {
			Debug.LogError($"CardPool tried to get a card object for a CardData that was not a SurfaceCardData or OutpostCardData. The carddata was: {cardData.name}");
			return null;
		}
	}

	/// <summary>
	/// Receives CardObject, deactivates them and stores them in the appropriate queue.
	/// </summary>
	/// <param name="cardObject"></param>
	public void ReturnCardObject(CardObject cardObject) {
		if (cardObject is SurfaceCardObject surfaceCardObject) {
			if (!surfaceCards.Contains(surfaceCardObject)) {
				//TODO: Check this, shouldn't be done by card, but instead by the zone?
				surfaceCardObject.CurrentZone = null; // Clear the current zone reference
				surfaceCardObject.gameObject.SetActive(false);
				surfaceCards.Enqueue(surfaceCardObject);
			}
			else {
				Debug.Log($"Cardpool received a SurfaceCardObject that was already in the pool. This shouldn't happen, the card returned was: {surfaceCardObject.name}");
			}
		}
		else if (cardObject is OutpostCardObject outpostCardObject) {
			if (!outpostCards.Contains(outpostCardObject)) {
				outpostCardObject.gameObject.SetActive(false);
				outpostCards.Enqueue(outpostCardObject);
			}
			else {
				Debug.Log($"Cardpool received a OutpostCardObject that was already in the pool. This shouldn't happen, the card returned was: {outpostCardObject.name}");
			}
		}
		else {
			Debug.LogError($"CardPool tried to return a CardObject that was not a SurfaceCardObject or OutpostCardObject. The cardobject was: {cardObject.name}");
		}

		Debug.Log($"CardPool returned a card object: {cardObject.name}. It now has {surfaceCards.Count} surface cards and {outpostCards.Count} outpost cards in the pool.");
	}
}
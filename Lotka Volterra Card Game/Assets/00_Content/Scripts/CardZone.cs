using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CardZone : MonoBehaviour {
	/*
	 * Attempting to create a more general way to handle cards that are placed face up on different areas of the board.
	 * Knows a max of amount of cards it can have as children.
	 * And have GM be the one that tells zones if they should light up and be ready to receive cards.
	 * Way of getting if it is full,
	 * How many places it has
	 * Get cards that it holds, if it holds cards.
	 * Should receive cards and place them in their spots, should move them along when a new one comes in.
	 * Need way to handle if there are too many cards
	 */

	[SerializeField] private int cardSlotMax;
	public int CardSlotMax { get { return cardSlotMax; } }

	private List<CardObject> cardObjects;
	public int CardObjectsCount { get { return cardObjects.Count; } }

	//This will cause problems with removing a card surely?
	//For instance, with removing a specific card.
	public bool GetCards(out List<CardObject> cards) {
		if (cardObjects == null) {
			cards = new List<CardObject>();
			return false;
		}
		else {
			cards = cardObjects;
			return true;
		}
	}
	private void OnEnable() {
		cardObjects = new List<CardObject>();
	}

	public void AddCard(CardObject newCard) {

		if (gameObject.transform.childCount > CardSlotMax) {
			Debug.Log($"{name} doesn't have the space to receive a new cardObject.");
			return;
		} else {
			newCard.transform.SetParent(gameObject.transform,false);
		}
	}

	public CardObject GetCard(int cardSlot) {
		CardObject[] cardObjects = GetComponentsInChildren<CardObject>();
		CardObject cardObject = cardObjects[cardSlot];
		cardObject.transform.SetParent(null,false);
		return cardObject;
	}
}

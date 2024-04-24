using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CardZone : MonoBehaviour {
	/*
	 * Attempting to create a more general way to handle cards that should be face up.
	 * That would work for deployment, personality, surface etc.
	 * So, they would need to know how many slots they have, because there is supposedly a max here.
	 * You could make these stupid, and just have them accept cards,
	 * And have GM be the one that tells zones if they should light up and be ready to receive cards.
	 * Then have the cards be the ones that notices if there are cards above them etc.
	 * Needs list of it's children
	 * Way of getting if it is full,
	 * How many places it has
	 * Get cards that it holds, if it holds cards.
	 */

	//Should receive cards and place them in their spots, should move them along when a new one comes in.
	//Need way to handle if there are too many cards

	private List<CardObject> cardObjects;
	public int CardObjectsCount {  get { return cardObjects.Count; } }

	private List<RectTransform> cardSlots;
	public int CardSlotsCount { get { return cardSlots.Count; } }

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

	public void AddCard(CardObject newCard) {

		if(CardObjectsCount >= CardSlotsCount) {
			Debug.Log($"{name} doesn't have the space to receive a new cardObject.");
			return;
		}

        foreach (var slot in cardSlots)
        {
			if(slot.childCount == 0) {
				newCard.transform.SetParent(slot);
				Debug.Log($"{newCard.name} has received a parent. That parents is {slot.name}, it shouldn't have another child.");
				//I'll be teleporting this, for now, to ensure that it works.
				newCard.transform.position = slot.position;
				return;
			}
        }
		Debug.Log($"{name} couldn't find an empty slot for the card it received, even though it should.");
    }

	private void OnEnable() {

		cardObjects = new List<CardObject>();

		//Clears the cardSlots list and adds all RectTransform children to it.
		cardSlots = new List<RectTransform>();
		foreach (RectTransform child in transform) cardSlots.Add(child);
	}
}

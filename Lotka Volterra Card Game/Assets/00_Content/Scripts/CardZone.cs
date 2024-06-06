using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CardZone : MonoBehaviour {

	[SerializeField] private List<CardType> approvedCardTypes = new();

	[SerializeField] private int cardSlotMax;
	public int CardSlotMax { get { return cardSlotMax; } }

	public bool IsFull { get { if (cardSlotMax >= transform.childCount) return false; return true; } }

	public bool IsCardAllowed(CardObject cardObject) {
		if (cardObject == null) return false;
		else if (IsFull) return false;
		else {
            foreach (CardType cardType in approvedCardTypes)
            {
				if (cardType == cardObject.CardScript.GetCardType) return true;
			}
			return false;
        }
	}

	public void AddCard(CardObject newCard) {

		if (!IsCardAllowed(newCard)) {
			Debug.Log($"{name} cannot receive the new card.");
			return;
		}
		else {
			newCard.transform.SetParent(gameObject.transform, false);
			//This feels like a bizzarre and unsafe way to handle this, might want to have more of a method for this somewhere maybe?
			CardSelector.SelectedCard = null;
		}
	}

	public CardObject GetCard(int cardSlot) {
		CardObject[] cardObjects = GetComponentsInChildren<CardObject>();

		if (cardObjects.Length == 0 || cardObjects.Length >= cardSlot) {
			return null;
		}
		else {
			return cardObjects[cardSlot];
		}
	}
}
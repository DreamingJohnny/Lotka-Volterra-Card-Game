using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CardZone : MonoBehaviour {

	[SerializeField] private int cardSlotMax;
	public int CardSlotMax { get { return cardSlotMax; } }

	public bool IsFull { get { if (cardSlotMax >= transform.childCount) return false; return true; } }

	public void AddCard(CardObject newCard) {

		if (IsFull) {
			Debug.Log($"{name} doesn't have the space to receive a new cardObject.");
			return;
		}
		else {
			newCard.transform.SetParent(gameObject.transform, false);
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
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiscardPile : MonoBehaviour {

	private CardObject topDiscardCard;

	private List<CardObject> cardPile;

	public int AmountOfCards { get { return cardPile.Count; } }

	public bool HasTopCardObject { get { if (topDiscardCard == null) return false; return true; } }

	//public event Action<CardObject> OnUnUsedCard;
	//public event Action<DiscardPile> OnCardNeeded;

	void Start() {
		cardPile = new List<CardObject>();
		topDiscardCard = null;
	}

	public CardObject GetCard(int index) {

		if (index < 0 || index > AmountOfCards) {
			Debug.Log($"{name} was asked to hand over a card that was outside the range of cards it currently holds");
			return null;
		}
		else {
			CardObject card = cardPile[index];
			SetupPile();

			return card;
		}
	}

	public CardObject GetTopCard() {
		//Returns the card with the last index in the list.
		CardObject card = cardPile[^1];
		SetupPile();

		return card;
	}

	public void RecieveCard(CardObject card) {
		SetTopCard(card);

		if(card.TryGetComponent(out Collider2D component)) {
			component.enabled = false;
		}
		cardPile.Add(card);
	}

	private void SetupPile() {
		foreach (var cardObject in cardPile) {
			cardObject.gameObject.SetActive(false);
		}

		cardPile[^1].gameObject.SetActive(true);
	}

	private void SetTopCard(CardObject card) {

		foreach (var cardObject in cardPile) {
			cardObject.gameObject.SetActive(false);
		}

		card.transform.SetParent(transform, false);
		card.transform.localPosition = Vector3.zero;
	}
}
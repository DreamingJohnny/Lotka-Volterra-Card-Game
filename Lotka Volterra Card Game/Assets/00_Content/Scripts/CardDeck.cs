using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour {

	[SerializeField] private List<POCO_OutpostCard> cards = new List<POCO_OutpostCard>();

	public bool HasCards {
		get {
			if (cards.Count > 0) return true;
			else return false;
		}
	}

	void Start() {

	}

	public POCO_OutpostCard GetTopCard() {
		if(!HasCards) {
			Debug.Log($"{name} doesn't contain anymore cards but is asked to return a card.");
			return null;
		}

		POCO_OutpostCard topCard = cards[0];
		cards.RemoveAt(0);

		return topCard;
	}

	public string GetTopCardName() {
		//Let's begin with getting the name like this,
		//later on we will need to enforce here in some way that this is some sort of either, OutpostCard or EnemyCard,
		//and then have it send on valuable info.
		if (!HasCards) {
			Debug.Log($"{name} doesn't contain anymore cards but is asked to give the name of the topcard.");
			return null;
		}

		return cards[0].GetCardName;
	}
}

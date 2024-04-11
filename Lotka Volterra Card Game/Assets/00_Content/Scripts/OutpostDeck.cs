using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutpostDeck : MonoBehaviour {

	[SerializeField] private List<ScriptableObject> outpostDeck = new List<ScriptableObject>();

	public bool HasCards {
		get {
			if (outpostDeck.Count > 0) return true;
			else return false;
		}
	}

	void Start() {

	}

	public ScriptableObject GetTopCard() {
		if(!HasCards) {
			Debug.Log($"{name} doesn't contain anymore cards but is asked to return a card.");
			return null;
		}

		ScriptableObject topCard = outpostDeck[0];
		outpostDeck.RemoveAt(0);

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

		return outpostDeck[0].name;
	}
}

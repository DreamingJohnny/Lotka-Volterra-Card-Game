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

			GameObject cardPoolObject = new GameObject();
			instance = cardPoolObject.AddComponent<CardPool>();
			return instance;
		}
		private set { instance = value; }
	}

	//And then receive them as well, and when receiving them, probably clean them out of things as well?

	//Unsure how necessary these two actually are? Seeing as I cannot instantiate here...
	[SerializeField] private SurfaceCardObject surfaceCardPrefab;
	[SerializeField] private OutpostCardObject outpostCardPrefab;

	private List<SurfaceCardObject> surfaceCards = new();
	private List<OutpostCardObject> outpostCards = new();

	private void Awake() {
		if (Instance != null && Instance != this) { Destroy(this); } else { Instance = this; }
	}

	public SurfaceCardObject GetCardObject(SurfaceCardScript surfaceCardScript) {
		if (surfaceCards.Count == 0) {
			SurfaceCardObject temp = Instantiate(surfaceCardPrefab);
			temp.SetCardScript(surfaceCardScript);
			temp.gameObject.SetActive(true);
			return temp;
		}
		else {
			SurfaceCardObject temp = surfaceCards[0];
			surfaceCards.RemoveAt(0);
			temp.gameObject.SetActive(true);
			return temp;
		}
	}

	public OutpostCardObject GetCardObject(OutpostCardScript outpostCardScript) {
		if (outpostCards.Count == 0) {
			OutpostCardObject temp = Instantiate(outpostCardPrefab);
			temp.SetCardScript(outpostCardScript);
			temp.gameObject.SetActive(true);
			return temp;
		}
		else {
			OutpostCardObject temp = outpostCards[0];
			outpostCards.RemoveAt(0);
			temp.gameObject.SetActive(true);
			return temp;
		}
	}

	public void ReceiveCardObject(SurfaceCardObject surfaceCardObject) {
		if (surfaceCards.Contains(surfaceCardObject)) {
			Debug.Log($"Cardpool just received a card that was already on its list of cards. This shouldn't happen, the card received was: {surfaceCardObject.name}");
		}

		surfaceCardObject.gameObject.SetActive(false);
		surfaceCards.Add(surfaceCardObject);
	}

	public void ReceiveCardObject(OutpostCardObject outpostCardObject) {
		if (outpostCards.Contains(outpostCardObject)) {
			Debug.Log($"Cardpool just received a card that was already on its list of cards. This shouldn't happen, the card received was: {outpostCardObject.name}");
		}

		outpostCardObject.gameObject.SetActive(false);
		outpostCards.Add(outpostCardObject);
	}
}
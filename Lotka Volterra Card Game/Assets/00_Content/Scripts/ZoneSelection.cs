using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoneSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	[SerializeField][Range(0f, 1.0f)] private float neutralAlpha = 0.35f;
	[SerializeField][Range(0f, 1.0f)] private float highlightedAlpha = 1.0f;

	private Color available = Color.white;
	private Color unAvailable = Color.gray;
	private Color inActive = Color.black;

	private Image image;

	private void Awake() {
		image = GetComponentInChildren<Image>();
		Debug.Assert(image != null);
		image.color = inActive;
	}

	private void OnEnable() {
		CardSelector.OnCardSelected += HandleOnCardSelected;
	}

	private void OnDisable() {
		CardSelector.OnCardSelected -= HandleOnCardSelected;
	}

	public void OnPointerEnter(PointerEventData pointerEventData) {
		image.color = new Color(image.color.r, image.color.g, image.color.b, highlightedAlpha);
	}

	public void OnPointerClick(PointerEventData pointerEventData) {

		if (TryGetComponent(out CardZone zone)) {
			if(zone.IsCardAllowed(CardSelector.SelectedCard)) {
				zone.AddCard(CardSelector.SelectedCard);
			}

			Debug.Log("Now the card should move!");
		}
	}
	public void OnPointerExit(PointerEventData pointerEventData) {
		image.color = new Color(image.color.r, image.color.g, image.color.b, neutralAlpha);
	}

	private void HandleOnCardSelected(CardObject cardObject) {

		//Here it needs to check on what type of card it is then, like, if it should be available for that.
		if (cardObject == null) {
			image.color = unAvailable;
			return;
		}
		else if (GetComponent<CardZone>().IsCardAllowed(cardObject)) {
			image.color = available;
		}

	}
}
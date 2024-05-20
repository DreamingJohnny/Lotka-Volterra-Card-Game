using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoneSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	//So, this will sit on a zone, firstly we'll want it to just light up when the mouse is above it,
	//Once we've fixed that, the next step should be to have it send an event when the mouse clicks on it,
	//So that the GM, that subscribes to the event, then knows what it is, and can decide if it should recieve the card.

	[SerializeField][Range(0f,1.0f)] private float neutralAlpha = 0.35f;
	[SerializeField][Range(0f, 1.0f)] private float highlightedAlpha = 1.0f;

	public event Action<ZoneSelection> OnZoneSelection;

	private Image image;

	private void Awake() {
		image = GetComponentInChildren<Image>();
		Debug.Assert(image != null);
		image.color = new Color(image.color.r,image.color.g,image.color.b,neutralAlpha);
	}

	public void OnPointerEnter(PointerEventData pointerEventData) {
		image.color = new Color(image.color.r, image.color.g, image.color.b, highlightedAlpha);
	}

	public void OnPointerClick(PointerEventData pointerEventData) {

		OnZoneSelection?.Invoke(this);
	}
	public void OnPointerExit(PointerEventData pointerEventData) {
		image.color = new Color(image.color.r, image.color.g, image.color.b, neutralAlpha);
	}
}

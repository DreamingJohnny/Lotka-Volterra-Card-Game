using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	//So, this will sit on a zone, firstly we'll want it to just light up when the mouse is above it,
	//Once we've fixed that, the next step should be to have it send an event when the mouse clicks on it,
	//So that the GM, that subscribes to the event, then knows what it is, and can decide if it should recieve the card.

	public event EventHandler OnZoneSelection;

	public void OnPointerEnter(PointerEventData pointerEventData) {
	}

	public void OnPointerClick(PointerEventData pointerEventData) {
		//Should send the event to the GM here.

		OnZoneSelection?.Invoke(this, EventArgs.Empty);
	}
	public void OnPointerExit(PointerEventData pointerEventData) {
	}
}

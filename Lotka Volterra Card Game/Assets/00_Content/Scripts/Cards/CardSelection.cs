using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	private Vector3 neutralScale = Vector3.one;
	private Vector3 highlightedScale = new(1.2f, 1.2f, 1.2f);

	private void OnEnable() {
		transform.localScale = neutralScale;
	}

	public void OnPointerEnter(PointerEventData pointerEventData) {
		transform.localScale = highlightedScale;
	}

	public void OnPointerClick(PointerEventData pointerEventData) {

		//So, here we might want either,
			//a way for the card to tell if it should be possible to select it, or
			//perhaps the zone should handle that?
		CardSelector.SelectedCard = GetComponent<CardObject>();
		
	}
	public void OnPointerExit(PointerEventData pointerEventData) {
		transform.localScale = neutralScale;
	}
}

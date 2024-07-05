using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler {

	private Vector3 neutralScale = Vector3.one;
	private Vector3 highlightedScale = new(1.2f, 1.2f, 1.2f);

	[SerializeField] private Sprite selectedHalo;


	private void OnEnable() {
		transform.localScale = neutralScale;
		GetComponent<SpriteRenderer>().sprite = selectedHalo;
		GetComponent<SpriteRenderer>().enabled = false;
	}

	public void OnPointerEnter(PointerEventData pointerEventData) {
		transform.localScale = highlightedScale;
	}

	public void OnPointerClick(PointerEventData pointerEventData) {

		//So, here we might want either,
		//a way for the card to tell if it should be possible to select it, or
		//perhaps the zone should handle that?
		PlayerCursor.SelectedCard = GetComponent<CardObject>();

		EventSystem.current.SetSelectedGameObject(GetComponent<CardObject>().gameObject);
	}

	public void OnPointerExit(PointerEventData pointerEventData) {
		transform.localScale = neutralScale;
	}

	public void OnSelect(BaseEventData eventData) {
		GetComponent<SpriteRenderer>().enabled = true;
	}
	public void OnDeselect(BaseEventData eventData) {
		GetComponent <SpriteRenderer>().enabled = false;
	}
}

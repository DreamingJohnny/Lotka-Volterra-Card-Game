using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ZoneHighlight : MonoBehaviour {

	[SerializeField][Range(0f, 1.0f)] private float neutralAlpha = 0.35f;
	[SerializeField][Range(0f, 1.0f)] private float highlightedAlpha = 1.0f;

	private Color active = Color.white;
	private Color inActive = Color.black;
	private Color allowed = Color.green;
	private Color unAllowed = Color.red;

	private SpriteRenderer spriteRenderer;

	private List<CardType> approvedCardTypes = new();

	private void Awake() {

		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		Debug.Assert(spriteRenderer != null);
		spriteRenderer.color = unAllowed;
	}

	private void OnEnable() {
		approvedCardTypes = GetComponent<CardZone>().GetApprovedCardTypes();
		spriteRenderer.color = active;
		//Pretty sure I want to add here that the collider should be activated here?

		//PlayerCursor.OnCardSelected += HandleOnCardSelected;
	}

	private void OnDisable() {
		spriteRenderer.color = inActive;
		//PlayerCursor.OnCardSelected -= HandleOnCardSelected;
	}

	public void OnMouseEnter() {

		if(approvedCardTypes.Contains(PlayerCursor.SelectedCard.CardScript.GetCardType)) {
			spriteRenderer.color = allowed;
		}
		else {
			//TODO: Will need to add some way here so that the collider is only active when the zone is available. (Otherwise it will show unavailable during mouse over when it is inactive)
			spriteRenderer.color = unAllowed;
		}
	}

	public void OnMouseExit() {
		spriteRenderer.color = active;
	}

	//public void OnPointerEnter(PointerEventData pointerEventData) {
	//	spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, highlightedAlpha);
	//}

	public void OnPointerClick(PointerEventData pointerEventData) {

		if (pointerEventData.button != 0) return;

		if (TryGetComponent(out CardZone zone)) {
			if(zone.IsCardAllowed(PlayerCursor.SelectedCard)) {
				zone.TryAddCard(PlayerCursor.SelectedCard);
			}

			Debug.Log("Now the card should move!");
		}
	}

	//public void OnPointerExit(PointerEventData pointerEventData) {
	//	spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, neutralAlpha);
	//}

	private void HandleOnCardSelected(CardObject cardObject) {

		//Here it needs to check on what type of card it is then, like, if it should be available for that.
		if (cardObject == null) {
			spriteRenderer.color = unAllowed;
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, neutralAlpha);
			return;
		}
		else if (GetComponent<CardZone>().IsCardAllowed(cardObject)) {
			spriteRenderer.color = active;
			spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, neutralAlpha);
		}

	}
}
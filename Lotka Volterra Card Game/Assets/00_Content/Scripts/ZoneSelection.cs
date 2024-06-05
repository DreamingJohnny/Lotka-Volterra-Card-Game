using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ZoneSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	[SerializeField][Range(0f,1.0f)] private float neutralAlpha = 0.35f;
	[SerializeField][Range(0f, 1.0f)] private float highlightedAlpha = 1.0f;

	//Testing out tweaking just the v here
	private float neutralV = 50f;
	private float applicableV = 100f;
	private float unApplicableV = 0f;

	public event Action<ZoneSelection> OnZoneSelection;

	private Image image;

	private void Awake() {
		image = GetComponentInChildren<Image>();
		Debug.Assert(image != null);
		//image.color = new Color(image.color.h)
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

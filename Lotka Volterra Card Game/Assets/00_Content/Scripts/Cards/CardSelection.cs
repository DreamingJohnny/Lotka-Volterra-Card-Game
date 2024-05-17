using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSelection : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

	//So, this script notices when it is selected by a pointer, it then highlights itself, and sends an even to the GM?

	public event Action<CardSelection> OnCardSelected;

	public void OnPointerEnter(PointerEventData pointerEventData) {
		
	}

	public void OnPointerClick(PointerEventData pointerEventData) {
		Debug.Log("Card was clicked!");
		OnCardSelected?.Invoke(this);
	}
	public void OnPointerExit(PointerEventData pointerEventData) {
		
	}
}

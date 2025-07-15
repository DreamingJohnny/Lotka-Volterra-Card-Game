using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SO_CardData : ScriptableObject {

	[SerializeField] private string cardID;
	[SerializeField] private string cardName;

	[SerializeField] private Sprite illustration;

	[SerializeField] private CardType cardType;

	[SerializeField] private List<Trait> traits;

	[TextArea(15, 20)]
	[SerializeField] private string cardEffectDescription;

	public string CardID { get { return cardID; } }
	public string CardName { get { return cardName; } }
	public Sprite Illustration { get { return illustration; } }
	public CardType CardType { get { return cardType; } }
	public List<Trait> Traits { get { return traits; } }
	public string CardEffectDescription { get { return cardEffectDescription; } }
}
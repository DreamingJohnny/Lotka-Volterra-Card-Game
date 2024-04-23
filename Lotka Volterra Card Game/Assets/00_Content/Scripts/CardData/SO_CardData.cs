using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SO_CardData : ScriptableObject {

	[SerializeField] private string cardID;
	[SerializeField] private string cardName;

	[SerializeField] private Sprite illustration;

	[SerializeField] private OutpostCardType cardType;

	[SerializeField] private List<Keyword> keywords;

	[TextArea(15, 20)]
	[SerializeField] private string cardEffect;

	public string CardID { get { return cardID; } }
	public string CardName { get { return cardName; } }
	public Sprite Illustration { get { return illustration; } }
	public OutpostCardType CardType { get { return cardType; } }
	public List<Keyword> Keywords { get { return keywords; } }
	public string CardEffect { get { return cardEffect; } }
}

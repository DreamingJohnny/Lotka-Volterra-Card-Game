using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "SurfaceCard", menuName = "ScriptableObjects/SO_SurfaceCard")]

public class SO_SurfaceCard : ScriptableObject {

	[SerializeField] private string cardID;
	[SerializeField] private string cardName;

	[SerializeField] private Image illustration;

	[SerializeField] private SurfaceCardType surfaceCardType;

	[SerializeField] private List<string> keywords;

	[TextArea(15, 20)]
	[SerializeField] private string cardEffect;

	[SerializeField] private int threatLevel;

	[SerializeField] private int alertness;

	[SerializeField] private int toughness;

	public string CardID { get { return cardID; } }
	public string CardName { get { return cardName; } }
	public Image Illustration { get { return illustration; } }
	public SurfaceCardType SurfaceCardType { get { return surfaceCardType; } }
	public List<string> Keywords { get { return keywords; } }
	public string CardEffect { get { return cardEffect; } }
	public int ThreatLevel { get { return threatLevel; } }
	public int Alertness { get {  return alertness; } }
	public int Toughness { get { return toughness; } }
}

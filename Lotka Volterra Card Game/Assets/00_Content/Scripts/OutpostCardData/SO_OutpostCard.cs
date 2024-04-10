using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "OutpostCard", menuName = "ScriptableObjects/SO_OutpostCard")]
public class SO_OutpostCard : ScriptableObject {

	[SerializeField] private CardRarity rarity;
	[SerializeField] private IdeologyType ideology;
	[SerializeField] private Daycycle daycycle;

	[SerializeField] private string cardID;
	[SerializeField] private string cardName;
	
	[SerializeField] private int developmentCost;
	[SerializeField] private int resourceCost;
	[SerializeField] private int hourCost;
	[SerializeField] private int upkeepCost;

	[SerializeField] private Image illustration;

	[SerializeField] private OutpostCardType cardType;

	[TextArea(15,20)]
	[SerializeField] private string cardEffect;

	[SerializeField] private int scavengeValue;
	[SerializeField] private int interveneValue;
	[SerializeField] private int developmentValue;

	public string CardID { get { return cardID; } }
	public string CardName { get { return cardName; } }
	public int DevelopmentCost { get { return developmentCost; } }
	public int ResourceCost { get { return resourceCost; } }
	public int HourCost { get { return hourCost; } }
	public int UpkeepCost { get { return upkeepCost; } }
	public Image Illustration { get { return illustration; } }
	public string CardEffect { get { return cardEffect; } }
	public int ScavengeValue { get {  return scavengeValue; } }
	public int InterveneValue { get { return interveneValue; } }
	public int DevelopmentValue { get { return developmentValue; } }
}

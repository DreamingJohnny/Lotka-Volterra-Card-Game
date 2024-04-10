using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OutpostCard", menuName = "ScriptableObjects/SO_OutpostCard")]
public class SO_OutpostCard : ScriptableObject {

	[SerializeField] private CardRarity rarity;

	[SerializeField] private OutpostCardType cardType;
	[SerializeField] private string cardName;
	[SerializeField] private string cardID;

	[SerializeField] private Sprite illustration;

	[SerializeField] private IdeologyType ideology;
	[SerializeField] private Daycycle daycycle;

	[SerializeField] private int Dev;
	[SerializeField] private int Hrs;
	[SerializeField] private int Res;
	[SerializeField] private int Upk;
	[SerializeField] private int SCA;
	[SerializeField] private int INT;
	[SerializeField] private int DEV;

	[TextArea(15,20)]
	[SerializeField] private string cardEffect;
}

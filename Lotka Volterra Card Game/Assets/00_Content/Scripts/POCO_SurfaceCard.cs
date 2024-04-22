using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POCO_SurfaceCard : CardScript
{
	public SO_OutpostCard OutpostCardData;

	public POCO_SurfaceCard(SO_CardData cardData) : base(cardData) {
		this.OutpostCardData = cardData as SO_OutpostCard;
	}
}

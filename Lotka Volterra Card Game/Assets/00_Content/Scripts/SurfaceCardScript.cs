using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceCardScript : CardScript
{
	public SO_SurfaceCardData SurfaceCardData;

	public SurfaceCardScript(SO_CardData cardData) : base(cardData) {
		this.SurfaceCardData = cardData as SO_SurfaceCardData;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POCO_OutpostCard {

	private SO_OutpostCard outpostCardData;

	public POCO_OutpostCard(SO_OutpostCard outpostCardData) {
		this.outpostCardData = outpostCardData;
	}

	public string GetCardID { get { return outpostCardData != null ? outpostCardData.CardID : null; } }
	public string GetCardName { get { return outpostCardData != null ? outpostCardData.CardName : null; } }


	private int developmentCostAddition = 0;
	private int developmentCostMultiplier = 1;

	public bool GetDevelopmentCost(out int developmentCost) {
		if (outpostCardData == null || outpostCardData.DevelopmentCost < 0) {
			developmentCost = -1;
			return false;
		}
		else {
			float tempDevelopmentCost = (outpostCardData.DevelopmentCost + developmentCostAddition) * developmentCostMultiplier;
			tempDevelopmentCost = (tempDevelopmentCost < 0) ? 0 : tempDevelopmentCost;
			developmentCost = Mathf.FloorToInt(tempDevelopmentCost);
			return true;
		}

	}
	public Image GetIllustration { get { return outpostCardData.Illustration != null ? outpostCardData.Illustration : null; } }

	//So this one will need a series of modifiers then, that can be increased and decreased,
	//That will be send along with the value from the SO then? Well...
	//so this one will send on a lot of values. Such as name for instance.
	//But then the traits, I suppose we want it to set those no? Yeah, we probably want this one to set those in the constructor actually.
	//Let's say you want to raise a value, you then add to the trait here...
	//If the trait was "null", then this one needs a protection in that case, saying that it was set to null, so it cannot be raised.
	//While a value that has 0, that one can be raised. Correct?

	//Suppose I have a trait, that's from the SO, and I need it to be both increased, and then multiplied, then I'd need to save those separately?
	//So I'd want a trait add, and a trait multiply? Yeah because I need to be able to halve values, right?
}

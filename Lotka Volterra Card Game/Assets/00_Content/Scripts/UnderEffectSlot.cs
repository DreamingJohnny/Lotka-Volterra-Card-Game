using UnityEngine;

public class UnderEffectSlot {
	[SerializeField] private CardZone effectZone;

	[SerializeField] private CardZone underEffectSlot;

	//So, when asked, takes the complete value of the relevant trait from the zone, and compares that to the value of the card.

	public void CheckToFlipCard() {
		if (underEffectSlot.CurrentCardCount <= 0) { return; }

		if (effectZone.CurrentCardCount <= 0) { return ; }

		//TODO: Need to add so that card has two sides and can be flipped through, probably, the CardObject in some way
		Debug.Log("Here, the card should be flipped, but we lack that functionality for now.");

		//TODO: Here, most likely, something will need to check if the card that is now flipped over, should be sent to some other zone, since that should happen at this point.
	}

	public void ApplyValues() {
		//Start by just getting it to work, later on, we will want to either, change this into two similar, one that just makes a simple check, and one that allows the values to accumulate.
		//Going even further, we might already here want to look at what value it is that we will be comparing, if that, in some way, could be sent into this function.
		//For instance, imagine if we created a slot, for now, that held a small UI element, then we could update that, right?

		//Okay, so, now we can ask a zone for specific values, and then apply those values somewhere else...

		//So, to begin with, get the values, compare them to develop... threshold...?

		//So, it will need to do something like... "is the slot occupied"? If yes, ask zone, compare values?

		//So, underEffectSlot is actually just a zone with just one size? Yes...

		if (underEffectSlot.CurrentCardCount <= 1) {
			//So, here it needs to ask for the correct aggregated value then? Yes...
			//So, how will this zone then know what value to ask for? Let's begin by hardcoding it, later on, we will want to set them per zone or something...

			//So, we begin by pretending that this is a development zone, ONLY a development zone.

			//So it needs to get the value and then add it together.
			int development = effectZone.GetTotalValue(cardScript => {
				if (cardScript is OutpostCardScript outpostCardScript) {
					outpostCardScript.GetDevelopmentValue(out int developmentValue);
					return developmentValue;
				}
				return 0;
			});

			//So, now that I have gotten all of the values, (but only provided this is a outpostScript obviously so, if this should be generic, should it check that continually then?)
			//I can get and compare them to the value on the other card then?

			//So, it needs to ask for the card then, and, once it's gotten it, look at values? Hm... If it has values and fullfills it, it will need to send it on then?
			//So, even if this is attached to the same zone... 

			//So, it could possibly ask for the collected developmentcost... although, it would be cleaner if it could ask a card I suppose.
			//If it asked for the first matching card... and looked at that then?
			//Hm, so, when it comes to development slots, we will want to save the value, and we will want to compare it... attack is similar, and actually, so is hm...
			//So, we ask for the combined value here as well then? although it should really only be one.

			//Returns if the value is zero, since if it is, no progress will be made.
			//Check how true this is for turning cards over however, if we want to generalize this.
			if(development == 0) {return; }

			int developmentCost = underEffectSlot.GetTotalValue(cardScript => {
				if (cardScript is OutpostCardScript outpostCardScript) {
					outpostCardScript.GetDevelopmentCost(out int developmentCostValue);
					return developmentCostValue;
				}
				//What to do if it returns zero here? Actually, that might be an issue at all right? But do we in some way want to check here if it contains cards that are meant to be developed?
				return 0;
			});


			// So, if we move this up to the GH soon, it will basically be able to ask and send values to different ones...
			//And then it will need to know about those values then?

			//So, what if this was just attached to the transform then? Would that work?
			//So, it would have a card? And then, it would get called, and when it did, then it would do stuff...

			//You have the slot, it gets the value, it does stuff with the value, depending on what it is?

			//So, the GH, who knows, it will then direct them differently? telling it to either add or do stuff?


			/*
			 * Then, either attack, if it was sent attack...
			 * And then it has develop separately,
			 * And attack as its own.
			 */
		}
	}
}

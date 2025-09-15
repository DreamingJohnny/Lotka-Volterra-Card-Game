using UnityEngine;

public class UnderEffectSlot
{
    [SerializeField] private CardZone effectZone;

    [SerializeField] private CardZone underEffectSlot;

    //So, when asked, takes the complete value of the relevant trait from the zone, and compares that to the value of the card.

    public void ApplyValues() {
        //Start by just getting it to work, later on, we will want to either, change this into two similar, one that just makes a simple check, and one that allows the values to accumulate.
        //Going even further, we might already here want to look at what value it is that we will be comparing, if that, in some way, could be sent into this function.
        //For instance, imagine if we created a slot, for now, that held a small UI element, then we could update that, right?

        //Okay, so, now we can ask a zone for specific values, and then apply those values somewhere else...

        //So, to begin with, get the values, compare them to develop... threshold...?

        //So, it will need to do something like... "is the slot occupied"? If yes, ask zone, compare values?
    }
}

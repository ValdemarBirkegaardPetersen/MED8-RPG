using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHaircutEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 2)
        {
            return "We appreciate your business, but please come back when you can afford it";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 4;
        var outcome3 = 2 * eg.getCharisma();

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setCurrency(eg.getCurrency() - 2);
            eg.setCharisma(eg.getCharisma() - 1);
            eg.setIntelligence(eg.getIntelligence() - 1);
            eg.setHealth(eg.getHealth() - 25);
            return "You pay the barber 2 coins to cut and style your hair. In the middle of the haircut, a group of thugs show up and start extorting the barbershop owner. You speak up, mostly out of confusion and they beat you on the head with a club. You get thrown out without a say, suffering a concussion and terrible unfinished haircut";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 2);
            eg.setCharisma(eg.getCharisma() + 1);
            return "You pay the barber 2 coins to cut and style your hair. You definitely seem more approachable now";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 2);
            eg.setCharisma(eg.getCharisma() - 1);
            return "It is a busy day at the barber, and unfortunately you get stuck getting a haircut by the inexperienced new guy. You end up getting a terribly ugly bowl cut. What a waste of money";
        }
        else if (finalOutcome == 3)
        {
            eg.setCharisma(eg.getCharisma() + 1);
            return "The barber seems delighted to see you and seems in a good mood. \"Take a seat, this one is on the house\" he says";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

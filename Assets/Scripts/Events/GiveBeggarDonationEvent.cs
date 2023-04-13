using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveBeggarDonationEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 1)
        {
            return "Oh, you don't have any coin to spare? perhaps you should be the one begging ha ha ha!";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 4;
        var outcome3 = eg.getCurrency() / 5;


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setCurrency(eg.getCurrency() - 8);
            eg.setIntelligence(0);
            eg.setKarma(eg.getKarma() + 0.2f);
            return "You give the beggar a coin. He seems appreciative, however when you aren't looking he pickpockets you for more of your coin. You notice him and he takes off running. You attempt to chase him, but end up falling and hitting your head on the pavement. You suffer serious brain damage";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 1);
            eg.setKarma(eg.getKarma() + 0.2f);
            return "You give the beggar a coin. He thanks you and wishes you good fortune going forward";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 1);
            eg.setKarma(eg.getKarma() + 0.2f);
            eg.setIntelligence(eg.getIntelligence() + 2);
            return "You give the beggar a coin. He seems very appreciative and in return he teaches you a couple of life lessons he learned throughout his life";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(0);
            eg.setKarma(eg.getKarma() + 0.2f);
            return "You pull out your coin pouch and reach in, but all of a sudden you are surrounded by a flock of thugs. They demand all your coin, and afraid of what they are going to do, you comply and give them the coin.";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

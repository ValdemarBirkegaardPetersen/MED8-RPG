using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBreadFromBaker_Event : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getEntropy() > 0.9f)
        {
            return "Due to unknown circumstances, the bakery has closed down.";
            // exit event here
        }
        
        if (eg.getCurrency() < 3)
        {
            return "\"You think this bakery is a charity? Come back when you have more coin\" \n(Not enough Currency)";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 2 * eg.getCharisma();
        var outcome3 = 10;

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setCurrency(eg.getCurrency() - 3);
            eg.setHealth(eg.getHealth() - 15);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You pay the baker 3 coins for some bread. You eat it, but it didn't seem very fresh. You experience som slight food poisoning. \n(Health -15, Currency -3)";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 3);
            eg.setHealth(eg.getHealth() + 15);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You pay the baker 3 coins for some bread. You eat it and feel restored. \n(Health +15, Currency -3)";
        }
        else if (finalOutcome == 2)
        {
            eg.setHealth(eg.getHealth() + 15);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "The owner seems delighted to see you. They smile at you and gives you a piece of bread free of charge. You eat it and feel restored. \n(Health +15)";
        }
        else if (finalOutcome == 3)
        {
            eg.setHealth(eg.getHealth() + 25);
            eg.setCurrency(eg.getCurrency() - 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "The baker is having a sale on bread. It is very crowded but you manage to get the last two pieces of bread for a single coin each. Although a bit stale, you eat them and feel restored. \n(Health +25, Currency -2)";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

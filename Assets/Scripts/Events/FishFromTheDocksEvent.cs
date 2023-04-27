using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFromTheDocksEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() > 0.8f)
        {
            return "Recent illegal activities have resulted in the fishing spot being restricted to civilians";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 3;
        var outcome3 = 2 * eg.getStrength();
        var outcome4 = 10; 

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 40);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You notice a sign that says 'Caution!' which usually isn't there, but you decide to ignore it at fish anyway. All of a sudden an alligator lurking in the sewer pipe lunges out and attacks you, grabbing and biting you. A few nearby guards help fend off the alligator, and attempt to treat your bleeding wounds as best as they can";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() + 5);
            eg.setCharisma(eg.getCharisma() - 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend hours fishing. Although you return smelling like fish and sewage, you manage to sell the catch for 5 gold profit";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 75);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend hours fishing with no luck. But then all of a sudden you see a glimpse of gold in the water and attempt to hook it with your fishing rod. You fish it up and uncover an ancient golden idol. You sell it for 75 coins to the highest bidder";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 25);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "While fishing you stumble across a huge tuna. You struggle to pull it in, and while you usually never have success reeling such a huge catch in today you have succes. You sell the catch and make some good profit for the day.";
        }
        else if (finalOutcome == 4)
        {
            eg.setCurrency(eg.getCurrency() + 1);
            eg.setCharisma(eg.getCharisma() - 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend hours fishing and now smell like fish and sewage. Your catch was pretty lousy too, with only a few sardines to sell for a single coin total.";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

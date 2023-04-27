using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitNobleGardenPartyEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCharisma() < 6)
        {
            return "You approach the party but you are escorted off the grounds because they don't recognize you as a noble person";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 5;
        var outcome3 = 10 - eg.getIntelligence();
        var outcome4 = 5;


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 20);
            eg.setEntropy(eg.getEntropy() + 0.05f);

            return "While wining and dining with the other guests, all of a sudden a fire is started and chaos spreads among the guests. As it turns out some rebelling arsonists are setting the party ablaze as a political movement. As you escape you manage to catch a few burns.";
        }
        else if (finalOutcome == 1)
        {
            eg.setCharisma(eg.getCharisma() + 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend the entire night wining and dining at the fine garden party, You make a good impression with the noble men and women as you scoff at the poor population.";
        }
        else if (finalOutcome == 2)
        {
            eg.setCharisma(eg.getCharisma() - 5);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend the night at the garden party, but you get a little too drunk and start making a fool of yourself. You wake up in the mud on the street next morning. You don't exactly remember what happened, but you have a feeling people aren't as enthusiastic about you as they were the day before.";
        }
        else if (finalOutcome == 3)
        {
            eg.setHealth(eg.getHealth() + 10);
            eg.setCharisma(eg.getCharisma() - 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "As a guest at the party you start mingling with the other guests. At first you have some good conversations, but soon the topics start venturing into fields of literature and politics where you can't keep up with the conversation. Although you feast on the great food, you end the night with the reputation of being uncultured.";
        }
        else if (finalOutcome == 4)
        {
            eg.setStrength(eg.getStrength() + 1);
            eg.setHealth(eg.getHealth() + 20);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You waste no time on the guests and spend the entire night feasting on the amazing food. You wake up the next day nourished and full of energy.";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

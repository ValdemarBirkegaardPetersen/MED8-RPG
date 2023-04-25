using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitBathhouseEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 5)
        {
            return "This bathhouse is too prestigious to house common folk without any coin";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10 - eg.getCharisma();
        var outcome3 = eg.getStrength();


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setCurrency(0);
            eg.setCharisma(eg.getCharisma() - 5);
            eg.setEntropy(eg.getEntropy() + 0.025f);

            return "You pay the bathhouse 5 coins and you spend the day having a nice bath. Just as you are about to leave you notice your clothes, shoes and money have been stolen. You find some rags on the street you decide to wear as it is better than nothing";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setCharisma(eg.getCharisma() + 2);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You pay the bathhouse 5 coins and you spend the day having a nice bath, and end up much cleaner and nicer smelling than before";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "After having paid the entrance fee, you see some of the patrons whispering behind your back to each other and the staff. You are then approached by the staff and told to leave. You ask why, but they refuse to answer your question and throw you out without a refund";
        }
        else if (finalOutcome == 3)
        {
            eg.setCharisma(eg.getCharisma() + 2);
            eg.setEntropy(eg.getEntropy() + 0.025f); 
            return "As you pay the entry fee and undress, a few noble women are impressed by your physique and invite you to join them. You converse and have a good time, and they decide to pay for your bathhouse fee";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

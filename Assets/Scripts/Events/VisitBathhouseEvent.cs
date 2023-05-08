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
            return "This bathhouse is too prestigious to house common folk without any coin. \n(Not enough Currency)";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10 - eg.getCharisma();
        var outcome3 = eg.getStrength();


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setCurrency(eg.getCurrency() - 12);
            eg.setCharisma(eg.getCharisma() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);

            return "You pay the bathhouse 5 coins and you spend the day having a nice bath. Just as you are about to leave you notice some of your clothes and coin have been stolen. Unlucky. \n(Currency -5, Charisma +1, Currency -7)";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setCharisma(eg.getCharisma() + 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You pay the bathhouse 5 coins and you spend the day having a nice bath, and end up much cleaner and nicer smelling than before. \n(Currency -5, Charisma +2)";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "After having paid the entrance fee, you see some of the patrons whispering behind your back to each other and the staff. You are then approached by the staff and told to leave. You ask why, but they refuse to answer your question and throw you out without a refund. \n(Currency -5)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCharisma(eg.getCharisma() + 2);
            eg.setEntropy(eg.getEntropy() + 0.05f); 
            return "As you pay the entry fee and undress, a few noble women are impressed by your physique and invite you to join them. You converse and have a good time, and they decide to pay for your bathhouse fee. \n(Currency -5, Charisma +2, Currency +5)";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

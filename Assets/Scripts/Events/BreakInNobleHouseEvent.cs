using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakInNobleHouseEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() > 0.9f)
        {
            return "Because of recent events, the nobleman has decided to hire an abundance of personal guards to protect his belongings. There is no way you would be able to steal from him.";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 5 + (10 * eg.getPatrol());
        var outcome2 = 3 * eg.getStrength();
        var outcome3 = 2 * eg.getIntelligence(); ;



        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);


        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 30);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You silently break in to the nobles house, and while looking for items of value to steal you accidentally trigger a rigged tripwire trap, which results in poison darts shooting at you. You run away the same way you came in but feeling nauseous from the poison you attempt to rest while recovering. \n(Health -30)";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setStrength(eg.getStrength() - 2);
            eg.setHealth(eg.getHealth() - 10);
            eg.setPatrol(eg.getPatrol() + 0.5f);
            eg.setKarma(eg.getKarma() - 0.2f);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You slip into the nobles house but after accidentally making some noise you are caught and unable to escape. You pay a huge fine and serve some time in jail. Guard patrols are increased in the city, and when you are let out you are very malnourished by the poor and rotten jail food. \n(Health -10, Currency -10, Strength -2)";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 25);
            eg.setPatrol(eg.getPatrol() + 0.5f);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "Attempting to sneakily enter the house, you bulkily stumble into some furniture and make some noise. A guard notices you but afraid of engaging you in combat, flees to warn the other guards. Before the other guards return you manage to escape with quite a handful of coin and jewelry which you sell on the black market for profit. Guard patrols are increased in the city.  \n(Currency +25)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 20);
            eg.setKarma(eg.getKarma() - 0.2f);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You extensively plan a theft heist and sneak into the nobles house undetected. You grab what you easily can carry and avoid the guards patrol routes flawlessly. You manage to slip out silently with coin and jewelry, which you sell on the black market for profit. They never knew what hit them. \n(Currency +20)";
        }


        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

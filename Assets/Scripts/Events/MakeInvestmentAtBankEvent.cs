using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInvestmentAtBankEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() > 0.6f)
        {
            return "The bank is closed due to recent disturbances in the city. Multiple guards are patrolling inside.";
        }

        if (eg.getCurrency() < 5)
        {
            return "\"Sir, we would be happy to help you in your investment journey, but the investment cost is 5 coins.\" \n(Not enough Currency)";
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10;
        var outcome3 = 2 * eg.getIntelligence();

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 25);
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "Just as you are about to invest your 5 coins, an armed robbery takes place and all the bank employees and visitors are robbed for some fo their coin. The robbers seem to recognize you. You attempt to resist but you suffer a sword wound as they steal some coin. \n(Currency -10, Health -25)";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() + 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "With help from the bankers you happily invest 5 coins in various short term funds. After some time, the bankers pull out your investment for a slight profit. \n(Currency -5, Currency +7)";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "With help from the bankers you happily invest 5 coins in various short term funds. After some time, the bankers pull out your investment for a slight loss. \n(Currency -5, Currency +3)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 15);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "Using your own expertise you take initiative on some wise short term investment opportunities. You make a huge profit over a very short period of time before pulling your funds. \n(Currency -5, Currency +20)";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

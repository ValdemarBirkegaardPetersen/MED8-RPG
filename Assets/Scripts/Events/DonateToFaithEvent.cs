using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonateToFaithEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();


        if (eg.getPatrol() > 0.4f)
        {
            return "The preacher is under protection from multiple guards because of recent events. No one is allowed to approach him, so you cannot give him a donation";
            // exit event here
        }

        if (eg.getCurrency() < 5)
        {
            return "We appreciate all the financial help we can get, but by decree we cannot accept less than 5 coins. Please come back if you get the chance and have the coin to spare another time";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10 * eg.getPatrol();
        var outcome3 = 10 * (0.5f + (eg.getKarma() / 2));


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);


        if (finalOutcome == 0)
        {
            eg.setPatrol(1.0f);
            eg.setKarma(eg.getKarma() + 0.4f);
            eg.setCurrency(eg.getCurrency() - 5);
            return "After you donate your 5 coins to the preacher, he announces the faith has begun to fund zealots in the city to help keep the city safe and secure";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setKarma(eg.getKarma() + 0.4f);
            return "You participate in a sermon and personally donate 5 coins to the faith preacher. He responds very gratuitously and wishes you good luck and faith going forward";
        }
        else if (finalOutcome == 2)
        {
            eg.setKarma(eg.getKarma() + 0.2f);
            return "For unknown reasons, the sermon by the faith preacher has been cancelled. He tells you that he cannot with good conscience accept any donations for the time being, but seems appreciative nonetheless";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setCharisma(eg.getCharisma() + 3);
            eg.setKarma(eg.getKarma() + 0.4f);
            return "You participate in a sermon and personally donate 5 coins to the faith preacher. He responds very gratuitously and is happy that you participated in the sermon. He goes on to speak very highly of your character to the other people there";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

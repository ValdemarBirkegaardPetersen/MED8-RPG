using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StealShipSuppliesEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() > 0.8f)
        {
            return "The docks are patrolled by too many guards. You won't be able to steal anything undetected.";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 30 * eg.getPatrol();
        var outcome2 = 30 - (30 * eg.getPatrol());
        var outcome3 = eg.getIntelligence();


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setCurrency(eg.getCurrency() - 20);
            eg.setHealth(eg.getHealth() - 40);
            eg.setEntropy(eg.getEntropy() + 0.05f);

            return "You sneak in and attempt to steal some ship supplies, however you are caught by a couple of guards. They seem to be working for their own interests and allow you to escape as long as you pay them a hefty bribe. Before managing to pull out your coin purse, they beat you up and take some of the coin from your purse. While they don't take you to jail they do leave you in the street bleeding without help.";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setStrength(eg.getStrength() - 2);
            eg.setHealth(eg.getHealth() - 10);
            eg.setPatrol(eg.getPatrol() + 0.4f);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You attempt to steal some supplies, but you are caught. After serving some time in jail you pay a fine and are let out. You are very malnourished by the poor and rotten jail food. Patrols in the city are increased.";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 15);
            eg.setPatrol(eg.getPatrol() + 0.4f);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You attempt to steal some supplies, and although you are detected you manage to escape with some goods which you sell for a profit on the black market. Patrols in the city are increased.";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 15);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You thoroughly form a plan to steal the supplies at night. Although there are guards you manage, with quick wit, to evade them and remain undetected while escaping with some goods, which you sell for a profit on the black market.";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

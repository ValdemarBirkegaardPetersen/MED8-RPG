using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SabotageGuardArmoryEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() < 0.2f)
        {
            return "The guard armory is locked and not in use. You see no way or reason to sabotage the armory for now";
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = eg.getStrength();
        var outcome2 = 20 * eg.getPatrol();
        var outcome3 = 10;

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setPatrol(eg.getPatrol() + 0.4f);
            eg.setKarma(eg.getKarma() - 0.4f);
            eg.setCurrency(eg.getCurrency() - 20);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            eg.setStrength(eg.getStrength() - 3);
            return "Just as you break in, the guards surround you and you are sent to jail with a hefty fine. When they let you out you are very malnourished by the poor and rotten jail food and guard patrols are increased in the city.";
        }
        else if (finalOutcome == 1)
        {
            eg.setPatrol(eg.getPatrol() - 0.5f);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            eg.setKarma(eg.getKarma() - 0.4f);
            return "You successfully break in through the barred back door. You sabotage the weaponry and guard storage and escape without being caught. The city now has fewer resources to support the guard patrols.";
        }
        else if (finalOutcome == 2)
        {
            eg.setPatrol(eg.getPatrol() - 0.5f);
            eg.setKarma(eg.getKarma() - 0.4f);
            eg.setEntropy(eg.getEntropy() + 0.025f);

            return "The guard armory has been left completely empty as all the guards are out on patrol. You successfully sabotage the weaponry and storage. The city now has fewer resources to support the guard patrols.";
        }
        else if (finalOutcome == 3)
        {
            eg.setPatrol(eg.getPatrol() + 0.4f);
            eg.setKarma(eg.getKarma() - 0.4f);
            eg.setCurrency(eg.getCurrency() - 20);
            eg.setStrength(eg.getStrength() - 3);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "Just as you break in, the guards surround you and you are sent to jail with a hefty fine. When they let you out you are very malnourished by the poor and rotten jail food and guard patrols are increased in the city.";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

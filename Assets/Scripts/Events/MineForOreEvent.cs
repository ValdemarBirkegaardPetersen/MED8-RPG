using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineForOreEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getStrength() < 3)
        {
            return "You attempt to lift a pickaxe but it is way too heavy for you. \n(Strength too low)";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 20;
        var outcome2 = 2 * eg.getStrength();
        var outcome3 = eg.getStrength();


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 40);
            eg.setCharisma(eg.getCharisma() - 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You grab a pickaxe and start mining. After a while the ground starts shaking with tremors and all of a sudden a sinkhole appears underneath you. You fall down and experience multiple blunt impacts on your body and you break your jaw. After getting helped out, the hole is filled and you are left with a dislocated jaw, a speech impediment, and serious injuries on your body. \n(Health -40, Charisma -2)";
        }
        else if (finalOutcome == 1)
        {
            eg.setStrength(eg.getStrength() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You grab a pickaxe and start prospecting for rare minerals. You barely find any ore and you are only able to cover the food and water you consumed during mining with the payout. You feel strengthened from swinging the pickaxe however. \n(Strength +1)";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 5);
            eg.setStrength(eg.getStrength() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You grab a pickaxe and start prospecting for rare minerals. Because of your strength you are able to mine a lot more ore than usual and you make some decent profit along with feeling stronger. \n(Strength +1, Currency +5)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 40);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You grab a pickaxe and start prospecting for rare minerals. Just as you begin to mine, you see a rare gem in the rock which you uncover. It is a rare emerald, which you sell for a lot of profit. Lucky you. \n(Currency +40)";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

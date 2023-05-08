using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEquipmentBlacksmithEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 25)
        {
            return "\"Like what you fancy?\" The blacksmith asks. Unfortunately, the blacksmith's wares cost more than you can afford so you leave. \n(Not enough Currency)";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 20;
        var outcome2 = 20;
        var outcome3 = 20 * eg.getPatrol();



        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);


        if (finalOutcome == 0)
        {
            eg.setCurrency(eg.getCurrency() - 25);
            eg.setStrength(eg.getStrength() + 3);
            eg.setHealth(eg.getHealth() - 20);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "While looking at some of the different equipment the blacksmith sells, you decide to buy a black chainmail. While wearing it you feel much stronger, however unknowingly this piece of cursed equipment also drains your lifeforce. \n(Health -20, Currency -25, Strength +3)";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 25);
            eg.setStrength(eg.getStrength() + 5);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "The blacksmith forges up some steel armor, fitted perfectly for you. While it is still not a full set of armor, the weight and resistance of the armor increases your physical strength and resistance. \n(Currency -25, Strength +5)";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 25);
            eg.setStrength(eg.getStrength() + 3);
            eg.setCharisma(eg.getCharisma() + 3);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "The blacksmith forges up some gold trimmed steel armor perfectly fitted for you. While not as practically efficient as raw steel armor, wearing the armor you feel stronger, more protected, and more respected. \n(Currency -25, Strength +3, Charisma +3)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() - 25);
            eg.setStrength(eg.getStrength() + 4);
            eg.setCharisma(eg.getCharisma() - 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "Because of the increased amount of guards patrolling the city recently, the blacksmith has a lack of quality steel. You pay him 25 coins for some armor and he gives you a piece of rusty iron armor. While not very pretty, this armor strengthens you as a whole. \n(Currency -25, Strength +4, Charisma -2)";
        }


        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntInForestEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getStrength() < 3)
        {
            return "You have the supplies to go hunt for game, however you are too weak to be able to carry any game back to the city to sell it so you decide to call it off";
            // exit event here
        }
        
        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10 - eg.getStrength();
        var outcome2 = eg.getStrength();
        var outcome3 = 5 + (10 * eg.getPatrol());


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 65);
            eg.setStrength(eg.getStrength() - 4);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You go out to the forest with your hunting equipment. While on the hunt you are approached by an aggressive black bear. You attempt to make an escape but it chases you down and mauls you. You suffer a lot of physical damage as the bear leaves and a group of hunters find you and carry you back to town. You have multiple flesh wounds and broken bones";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() + 5);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You go hunt for game in the forest and successfully shoot a deer with your bow and arrow. Being unable to carry all of it you attempt to make it back with as much as possible. You sell it to the butcher for a bit of coin";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 10);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You go hunt for game in the forest and successfully shoot a deer with your bow and arrow. Being strong enough, you manage to carry the entire deer back to the city, which you sell to the butcher for a good amount of coin";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() - 15);
            eg.setEntropy(eg.getEntropy() + 0.05f); 
            return "You go hunt for game in the forest and successfully shoot a deer with your bow and arrow. While carrying it back however, you are robbed by a gang of highwaymen who steal your game, and some of your coin";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

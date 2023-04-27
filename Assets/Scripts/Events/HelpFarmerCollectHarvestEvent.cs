using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpFarmerCollectHarvestEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCharisma() < 2)
        {
            return "The farmer looks like he would need some help with collecting his harvest, however he refuses your help because he recognizes you as a disreputable person";
        }

        if (eg.getStrength() < 2)
        {
            return "The farmer looks at you and laughs. 'You don't look like you would be of much help carrying anything', he says apologetically";
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = eg.getStrength();
        var outcome2 = 10 - eg.getStrength();
        var outcome3 = eg.getIntelligence();

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setStrength(eg.getStrength() - 3);
            eg.setHealth(eg.getHealth() - 30);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You go to collect some vegetables, but after a while you notice most of the farm has rotten fruit with rodents running around. Not only do you end the day with some lousy pay because of the bad harvest, but you have also caught some sort of minor plague infection by the rats. While it doesn't last for so long, you do become extremely malnourished";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() + 3);
            eg.setStrength(eg.getStrength() + 1);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You help the farmer collect vegetables from the farm. Carrying around heavy pumpkins all day, you end up making a few coins. You also feel slightly stronger from the workout";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 1);
            eg.setHealth(eg.getHealth() + 10);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You help the farmer collect and sort tomatoes. The harvest has been pretty poor this time around however, so the farmer cannot afford to pay you as much. To make up for it he gives you a few tomatoes which you eat to feel restored";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 13);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You start working and notice the farm could use some improvements. Not only do you collect various vegetables for the farmer, but you also give him some tips about agriculture for better harvest in the future. He thanks you and gives you a bonus for the tip";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

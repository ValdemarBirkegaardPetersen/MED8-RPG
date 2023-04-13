using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobTheBankEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() > 0.5f)
        {
            return "You scout a plan to rob the bank, but leave disappointed as you simply cannot find any possible way to rob it with the high amount of guards on patrol";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10 - eg.getIntelligence();
        var outcome3 = 10 - eg.getStrength();
        var outcome4 = 10 - eg.getCharisma();


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 30);
            eg.setPatrol(eg.getPatrol() + 0.8f);
            eg.setStrength(eg.getStrength() - 5);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You thoroughly plan a robbery heist with a crew and finally sneak in during the night to steal from the vault. After reaching the vault, you find it completely empty and are ambushed by the bank guards. Someone tipped them off. Your crew frantically attempts to escape, and although you manage to escape the way you came in you break your arm and are seriously wounded from multiple sword slash wounds.";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() + 40);
            eg.setPatrol(eg.getPatrol() + 0.8f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You thoroughly plan a robbery heist with a crew and finally sneak in during the night to steal from the vault with all the coin you can carry. You were undetected, but the city increases its patrols significantly because of the robbery.";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 20);
            eg.setStrength(eg.getStrength() - 2);
            eg.setHealth(eg.getHealth() - 10);
            eg.setPatrol(eg.getPatrol() + 0.8f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You plan the robbery heist with a crew, but due to poor planning you trip the alarm system and are caught. After serving some time in jail you pay a huge fine and are let out. You are very malnourished by the poor and rotten jail food.";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 15);
            eg.setPatrol(eg.getPatrol() + 0.6f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You plan the robbery heist with a crew, but after successfully infiltrating the vault you are unable to carry as many coins as you thought. You manage to escape stealthily but the profits could have been better.";
        }
        else if (finalOutcome == 4)
        {
            eg.setCurrency(eg.getCurrency() - 20);
            eg.setStrength(eg.getStrength() - 2);
            eg.setHealth(eg.getHealth() - 10);
            eg.setPatrol(eg.getPatrol() + 0.8f);
            eg.setKarma(eg.getKarma() - 0.2f);
            return "You plan the robbery heist with a crew, but they betray you and lock you in the vault as they escape. You are later caught by the guards. After serving some time in jail you pay a huge fine and are let out. You are very malnourished by the poor and rotten jail food";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

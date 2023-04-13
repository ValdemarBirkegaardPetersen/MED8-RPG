using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllegalGamblingEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCharisma() > 6)
        {
            return "The bouncer looks at you, and tells you these are back-alley games. \"Go to a dinner party where you belong fancy pants\" he says";
        }
        if (eg.getCurrency() < 10)
        {
            return "Hey chump! the buy in for the game is 10 coins. get lost";
        }


        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 5;
        var outcome3 = 20 - (eg.getStrength() * 2);
        var outcome4 = eg.getStrength() * 2;


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setCurrency(0);
            eg.setHealth(eg.getHealth() - 40);
            return "You sit down at a table and you are joined by an infamous known mob boss. With no way to withdraw you start playing gambling all your money away. All of a sudden you find yourself in huge debt to the boss unable to pay him. They beat you up and tell you to get lost. You end up bruised and bleeding on the street";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            return "You play for a few games for the 10 coin buy-in, but luck is not on your side as you lose it all";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 20);
            return "You play for a few games for the 10 coin buy-in, and have some good luck in the games as you win big";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setHealth(eg.getHealth() - 20);
            return "As you sit at a gambling table, a couple of thugs on the other side start sizing you up. You get into some arguments with them and you end up in a brawl. You manage to get a swing or two in but you take a beating and all of you are thrown out. You end up in the street bruised and bleeding";
        }
        else if (finalOutcome == 4)
        {
            eg.setCurrency(eg.getCurrency() + 20);
            return "As you sit at a gambling table, a couple of thugs on the other side start sizing you up. You get into some arguments with them and you end up in a brawl. You defend yourself and manage to beat them in a fist fight. They are thrown out and you continue to play winning a bit of coin in the process";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

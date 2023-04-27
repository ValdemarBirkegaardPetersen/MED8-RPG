using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeSpicesEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 3)
        {
            return "Looking around, a bunch of traders are selling and buying merchandise. You feel like you could make a profit doing some trading but you need at least 3 coins to get the ball rolling";
            // exit event here
        }

        if (eg.getCharisma() < 2)
        {
            return "As you are about the do some trading you notice all the traders scoffing at you. No one wants to trade with you, so you decide to leave instead";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10;
        var outcome3 = eg.getIntelligence();
        var outcome4 = eg.getCharisma();

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);
        if (finalOutcome == 0)
        {
            eg.setCharisma(eg.getCharisma() + 2);
            eg.setHealth(eg.getHealth() - 20);
            eg.setEntropy(eg.getEntropy() + 0.05f);

            return "While trading at the market you stumble upon some new perfumes, which you believe could earn you some profit. You buy them and sell them to people for a slight profit. At the end of the day, while you do smell nice to other people, you get a deadly allergic reaction, and suffer damage to your respiratory before you can get medical help.";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "Using your 3 coins, you buy and sell different wares at the market, but you end up making some bad deals and losing a bit of coin.";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() + 6);
            eg.setCharisma(eg.getCharisma() - 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "Using your 3 coins, you buy and sell different wares at the market. You make great profit during the day, but you get a bit of a poor reputation because of your aggressive trading.";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 8);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "Using your 3 coins, you buy and sell different wares at the market. Using your knowledge about the current market economy, supply and demand you manage to make a lot of profit.";
        }
        else if (finalOutcome == 4)
        {
            eg.setCurrency(eg.getCurrency() + 3);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "Using your 3 coins, you buy and sell different wares at the market. Using your talent for negotiation, you make a bit of profit.";
        }


        Debug.Log("Error in outcome calculcation");
        return "404";
    }


}

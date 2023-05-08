using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAleAtTavernEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 2)
        {
            return "Not being able to afford an ale, you are asked to give up the seat for paying customers. Come back when you can spend some coin. \n(Not enough Currency)";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10;
        var outcome3 = eg.getIntelligence();
        var outcome4 = 10 - eg.getIntelligence();


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);
        if (finalOutcome == 0)
        {
            eg.setCurrency(eg.getCurrency() - 15);
            eg.setIntelligence(eg.getIntelligence() - 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You go and order an ale which you quickly finish. You can't stop yourself from getting another. One ale turns into two, which turns into three and before you know it. You wake up having sparse memory of the night prior. You spent more coin than you initially planned and now have a massive headache making it hard to think. \n(Currency -15, Intelligence -1)";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 2);
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You buy an ale and start making conversation with the other tavern customers. You hear about their stories and learn a couple of life lessons. \n(Currency -2, Intelligence +1)";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 8);
            eg.setCharisma(eg.getCharisma() + 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "One ale becomes a few and you end up drinking and having a good time with the other tavern customers all night. You wake up the next day slightly hung over, but with some great memories. \n(Currency -8, Charisma +2)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() + 10);
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You get an ale and someone invites you to play a game of chess. You play for fun to begin with, but you start getting competitive and play for money. With an increasing audience watching you play you manage to win multiple times making a bit of profit. \n(Currency +10, Intelligence +1)";
        }
        else if (finalOutcome == 4)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You get an ale and someone invites you to play a game of chess. You play for fun to begin with, but you start getting competitive and play for money. With an increasing audience watching you play you manage to lose multiple times losing a bit of money. \n(Currency -10, Intelligence +1)";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

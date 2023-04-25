using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHealingMixtureEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 10)
        {
            return "An old alchemist greets you - \"feel free to look at my remedies, but you need 10 coins if you want to buy anything. Sorry\"";
            // exit event here
        }

        if (eg.getCharisma() < 2)
        {
            return "The alchemist has rich patrons visiting and won't let you enter because of your status";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10 * eg.getPatrol();
        var outcome3 = 20 - (2 * eg.getStrength());
        var outcome4 = 25 - (eg.getHealth() / 4);


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            // misses stats?
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "After approaching the alchemist for a healing mixture, he starts mixing together ingredients. He starts to worry as the cauldron unexpectedly starts bubbling more and more. The cauldron then shoots up a gross tar-like substance. He apologizes and gives you a refund as he closes the shop.";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setHealth(eg.getHealth() + 20);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You pay the alchemist 10 coins, and he starts brewing a potion from the ingredients in his laboratory. After a while, he hands you a potion and tells you to drink it now, before it goes bad. You do and feel very restored.";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setHealth(eg.getHealth() + 10);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You go to buy a potion from the alchemist, but because of recent guard visits, he has a lack of the required ingredients. He instead offers to prepare a less potent healing remedy, which you agree on. You pay him 5 coins and feel slightly restored from the remedy.";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setStrength(eg.getStrength() + 4);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "When you enter, the alchemist informs you that the potions can be quite dangerous if you have a weak body, and instead suggests buying a strength potion. Although you don't think your body is that weak, you agree and buy the strength potion for 10 coins instead. He mixes the potion and you drink it, and although you don't feel different at first, you start feeling very strong after some time.";
        }
        else if (finalOutcome == 4)
        {
            eg.setCurrency(eg.getCurrency() - 10);
            eg.setCharisma(eg.getCharisma() - 3);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            eg.setIntelligence(eg.getIntelligence() - 3);
            eg.setHealth(eg.getHealth() + 80);
            return "The alchemist looks at you and can tell you look very unhealthy. He instead makes a experimental potion for the same price. This potion, while restores health significantly more than other potions, also takes its toll with decreased mind clarity and unnappealing skin boils";
        }
        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

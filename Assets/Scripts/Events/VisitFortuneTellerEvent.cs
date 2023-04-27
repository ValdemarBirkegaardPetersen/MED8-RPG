using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitFortuneTellerEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getCurrency() < 3)
        {
            return "A woman is sitting with a crystal ball - \"Sorry honey, it costs 3 coins to have your fortune told\"";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 20 * (0.5f + (eg.getKarma() / 2));
        var outcome2 = 20 - (20 * (0.5f + (eg.getKarma() / 2)));
        var outcome3 = 10;



        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);


        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 6);
            eg.setEntropy(eg.getEntropy() + 0.05f);

            return "The fortune teller tells you to take a seat and starts waving her hands around a glass orb. She mumbles for a bit, but then all of a sudden the glass orb starts shaking and explodes, throwing glass shards everywhere. With both of you lying on the ground bleeding, she screams at you to leave. You manage to stumble away and remove most of the glass shards. You have experienced serious blood loss";
        }
        else if (finalOutcome == 1)
        {
            eg.setCurrency(eg.getCurrency() - 3);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You pay the fortune teller 3 coins and she tells you that your fate is out of your hands, but you can still influence how you are remembered. She tells you that your past actions have consequences, and that your future is shrouded by mystery and adventure";
        }
        else if (finalOutcome == 2)
        {
            eg.setCurrency(eg.getCurrency() - 3);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You pay the fortune teller 3 coins and she tells you that your fate is out of your hands, but you can still influence how you are remembered. She tells you that your past actions have consequences, and that your future is covered in a dark shroud";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() - 3);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setIntelligence(eg.getIntelligence() + 1);
            return "You pay the fortune teller 3 coins and she helps you reflect on your past. You ask questions, which she doesn't seem to answer outright, but through careful consideration and reflection you leave with a more clear mind";
        }


        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

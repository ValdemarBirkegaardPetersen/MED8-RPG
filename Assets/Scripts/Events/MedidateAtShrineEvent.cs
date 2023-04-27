using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedidateAtShrineEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() > 0.75f)
        {
            return "You want to sit quietly and meditate, but there is too much noise from the rabble with the amount of guards patrolling and shouting";
            // exit event here
        }

        if (eg.getKarma() < -0.5f)
        {
            return "You sit down to meditate, but you cannot find peace of mind, with constant negative thoughts running through your mind";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10 * (0.5f + (eg.getKarma() / 2));
        var outcome3 = 10 - (10 * (0.5f + (eg.getKarma() / 2)));
        var outcome4 = 2;


        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3, outcome4);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 20);
            eg.setIntelligence(eg.getIntelligence() - 2);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You sit down at the shrine and start to meditate. You have visions that start becoming more and more worrying. Sinisters thoughts and horrifying nightmares enter your mind as you start hyperventilating. You collapse and hit your head on the ground. You wake up with a clouded mind, feeling memory loss and migrains everytime you think";
        }
        else if (finalOutcome == 1)
        {
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend hours reflecting on your life choices and what you could have done differently. You feel slightly wiser as a result";
        }
        else if (finalOutcome == 2)
        {
            eg.setKarma(eg.getKarma() + 0.5f);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend hours resting and meditating at the shrine with peaceful thoughts. You feel more good-minded and positive after a while";
        }
        else if (finalOutcome == 3)
        {
            eg.setKarma(eg.getKarma() - 0.5f);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You spend hours meditating at the shrine, however your thoughts are very restless and intense. After the meditation you end up feeling much more anxious, untrusting and deceptive than before";
        }
        else if (finalOutcome == 4)
        {
            eg.setIntelligence(10);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You sit down to meditate, and meaningless thoughts fleet through your mind. Hours pass with no progress, but then all of a sudden you have an intense epiphany, like all of your questions are being answered and that you no longer have any doubts. You open your eyes and feel almost omnipotent with knowledge you had no idea about previously";
        }
        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

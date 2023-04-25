using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformRitualEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        // Check requirements
        if (eg.getIntelligence() < 4)
        {
            return "You want to perform the unsanctioned ritual, but you lack the required knowledge";
        }
        if (eg.getKarma() > -0.2f)
        {
            return "You start to perform the ritual, but nothing happens. Reading one of the ritual books you can see that you have to be evil at heart, or the ritual cannot commence.";
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10;
        var outcome3 = 10;

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(0);
            eg.setKarma(-1);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You start the ritual by drawing signs on the floor. You read the incantations aloud and bloodlet with a sacrificial knife. All of a sudden your surroundings start to shake, and while your instinct tells you to stop, you succumb to the lust for power. Dark shrouded shadows enter your body and start eating you from within. After the ritual you are nothing but a pile of dust.";
        }
        else if (finalOutcome == 1)
        {
            eg.setHealth(eg.getHealth() - 30);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            eg.setIntelligence(10);
            return "You start the ritual by drawing signs on the floor. You read the incantations aloud and bloodlet with a sacrificial knife. You have visions lasting for hours, and when you wake up, you feel that you learned all life's secrets. You fumble around looking for a bandage as you have an intense blood loss.";
        }
        else if (finalOutcome == 2)
        {
            eg.setHealth(eg.getHealth() - 30);
            eg.setStrength(10);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You start the ritual by drawing signs on the floor. You read the incantations aloud and bloodlet with a sacrificial knife. You have visions lasting for hours, and when you wake up, you feel that nothing can rival your physically empowered strength. You fumble around looking for a bandage as you have an intense blood loss.";
        }
        else if (finalOutcome == 3)
        {
            eg.setHealth(eg.getHealth() - 30);
            eg.setCurrency(eg.getCurrency() + 100);
            eg.setEntropy(eg.getEntropy() + 0.025f);
            return "You start the ritual by drawing signs on the floor. You read the incantations aloud and bloodlet with a sacrificial knife. You have visions lasting for hours, and when you wake up, you find yourself covered in bloody coins. You fumble around looking for a bandage as you have an intense blood loss.";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

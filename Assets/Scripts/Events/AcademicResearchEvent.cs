using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcademicResearchEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getIntelligence() < 3)
        {
            return "You look around the university and see scholars of all different types. You do not seem qualified to be able to research at the institute so you leave again. Perhaps you will return when you are more capable. \n(Intelligence too low)";
            // exit event here
        }

        if (eg.getCharisma() == 0)
        {
            return "As you are about to enter the institute you are escorted off the grounds. \"Get out of here, we don't want your kind here, you're making us look bad\" the staff says. \n(Charisma too low)";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 20;
        var outcome2 = 2 * eg.getIntelligence();
        var outcome3 = 10 - eg.getIntelligence();

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);


        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 35);
            eg.setIntelligence(eg.getIntelligence() - 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setCurrency(eg.getCurrency() - 15);
            return "You read through a bunch of books and, while under some strict deadlines, you rush some risky experiments too quickly resulting in a spontaneous combustion. You suffer burns and cranial damage from the explosion, and have to pay compensation to the institute. \n(Health -35, Currency -15, Intelligence -1)";
        }
        else if (finalOutcome == 1)
        {
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You read through a bunch of books, and do a couple of experiments. You don't make any breakthroughs but you learn from your experience. \n(Intelligence +1)";
        }
        else if (finalOutcome == 2)
        {
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setCurrency(eg.getCurrency() + 20);
            return "You read through a bunch of books, and do a couple of experiments. You make some significant strides in your field and the institute sponsor you some coin to further your research. \n(Intelligence +1, Currency +20)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCharisma(0);
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You read through some books, but accidentally venture into some illegal fields of research. Caught but the fascination of your research you delve too deeply and are caught by your peers. They discard your research and they brand you as a despicable academic, spreading a poor reputation throughout the city. \n(Intelligence +1, Charisma -10)";
        }


        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

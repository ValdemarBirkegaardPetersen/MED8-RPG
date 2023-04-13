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

        if (eg.getIntelligence() < 4)
        {
            return "You look around the university and see scholars of all different types. You do not seem qualified to be able to research at the institute so you leave again. Perhaps you will return when you are more capable";
            // exit event here
        }

        if (eg.getCharisma() <= 2)
        {
            return "As you are about to enter the institute you are escorted off the grounds. 'Get out of here, we don't want your kind here, you're making us look bad' the staff says";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 20;
        var outcome2 = 2 * eg.getIntelligence();
        var outcome3 = 15 - eg.getIntelligence();

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);


        if (finalOutcome == 0)
        {
            eg.setCharisma(eg.getCharisma() - 2);
            eg.setIntelligence(eg.getIntelligence() - 2);
            eg.setCurrency(eg.getCurrency() - 30);
            return "You read through a bunch of books and, while under some strict deadlines, you rush some risky experiments too quickly resulting in a spontaneous combustion. You suffer burns and cranial damage from the explosion, and have to pay compensation to the institute";
        }
        else if (finalOutcome == 1)
        {
            eg.setIntelligence(eg.getIntelligence() + 1);
            return "You read through a bunch of books, and do a couple of experiments. You don't make any breakthroughs but you learn from your experience";
        }
        else if (finalOutcome == 2)
        {
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setCurrency(eg.getCurrency() + 20);
            return "You read through a bunch of books, and do a couple of experiments. You make some significant strides in your field and the institute sponsor you some coin to further your research";
        }
        else if (finalOutcome == 3)
        {
            eg.setCharisma(0);
            eg.setIntelligence(eg.getIntelligence() + 1);
            return "You read through some books, but accidentally venture into some illegal fields of research. Caught but the fascination of your research you delve too deeply and are caught by your peers. They discard your research and they brand you as a despicable academic, spreading a poor reputation throughout the city";
        }


        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

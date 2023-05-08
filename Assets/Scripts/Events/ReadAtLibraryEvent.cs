using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadAtLibraryEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getIntelligence() < 1)
        {
            return "You grab a book and attempt to read it, but you just cannot make sense of any of the letters. \n(Intelligence too low)";
            // exit event here
        }

        var outcome0 = 100 * (eg.getEntropy() * eg.getEntropy());
        var outcome1 = 16;
        var outcome2 = 4;
        var outcome3 = 4;
    
        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 25);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You stumble upon a black humming book, you are blinded by your pursuit of knowledge as you foolishly start reading being absorbed more and more until you pass out. The cursed book has drained you of your lifeforce, as the library helps you recover. \n(Health -25)";
        }
        else if (finalOutcome == 1)
        {
            eg.setIntelligence(eg.getIntelligence() + 1);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You grab a book and start reading for hours on end. You end up leaving feeling you learned something new. \n(Intelligence +1)";
        }
        else if (finalOutcome == 2)
        {
            eg.setIntelligence(eg.getIntelligence() + 3);
            eg.setStrength(eg.getStrength() - 1);
            eg.setHealth(eg.getHealth() - 10);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            return "You find a huge ancient dusty tome hidden away. Curious you dust it off and carry the heavy book to a nearby table spraining a muscle in the process. But reading through the book you uncover hidden life knowledge. You attempt to recover from your sprain injury as best as you can. \n(Health -10, Strength -1, Intelligence +3)";
        }
        else if (finalOutcome == 3)
        {
            eg.setCurrency(eg.getCurrency() - 5);
            eg.setEntropy(eg.getEntropy() + 0.05f);
            eg.setIntelligence(eg.getIntelligence() + 1);
            return "You grab a book and start reading for hours on end learning something new. Just as you are about to leave you accidentally spill water on the book. The library workers are upset and you end up paying some coins in restitution. \n(Intelligence +1, Currency -5)";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

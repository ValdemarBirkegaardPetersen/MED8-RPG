using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadingShipGoodsEvent : MonoBehaviour
{
    // To get and set stats
    EventUtility eg;

    public string Run()
    {
        eg = new EventUtility();

        if (eg.getPatrol() > 0.4f)
        {
            return "You offer to work unload the ships good, but the guards are on strict orders not to let anyone touch the goods, because of recent criminal activities in the city.";
        }

        if (eg.getStrength() < 3)
        {
            return "You approach the ship supply crew to offer to help unload the ships good for a couple of coin, but they refuse your help because you look too weak to work";
        }

        var outcome0 = 100 * (eg.getEntropy() + eg.getEntropy());
        var outcome1 = 10;
        var outcome2 = 10;
        var outcome3 = 2 * eg.getStrength();

        var finalOutcome = eg.CalculateOutcome(outcome0, outcome1, outcome2, outcome3);
        // Debug.Log(finalOutcome);

        if (finalOutcome == 0)
        {
            eg.setHealth(eg.getHealth() - 60);
            eg.setStrength(eg.getStrength() - 6);
            return "You start working for a low wage, carrying boxes from the ship onto the dock storage area. Out of nowhere a lift crane swings out and knocks you down. Crates fall on top of you and you suffer broken bones as the other workers pull you out";
        }
        else if (finalOutcome == 1)
        {
            eg.setStrength(eg.getStrength() + 1);
            eg.setCurrency(eg.getCurrency() + 5);
            return "You spend all day carrying crates from the ship into the dock storage area. Not only do you earn a bit of coin, but you also feel stronger";
        }
        else if (finalOutcome == 2)
        {
            eg.setStrength(eg.getStrength() + 1);
            return "You spend all day carrying crates from the ship into the dock storage area, however you drop and ruin some of the cargo along the way. They are reimbursed from your wage, so you earn no coin for your work. You do feel stronger though";
        }
        else if (finalOutcome == 3)
        {
            eg.setStrength(eg.getStrength() + 1);
            eg.setCurrency(eg.getCurrency() + 10);
            return "You spend all day carrying crates from the ship into the dock storage area. You work twice as well as any other dock worker and you are rewarded for your efficiency. You gain a nice coin bonus as well as feeling stronger from all the hard work";
        }

        Debug.Log("Error in outcome calculcation");
        return "404";
    }

    
}

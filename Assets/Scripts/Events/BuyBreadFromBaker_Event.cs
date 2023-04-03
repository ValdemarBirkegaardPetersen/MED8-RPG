using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyBreadFromBaker_Event : MonoBehaviour
{
    // The different possible outcomes for the event
    private string outcome1 = "Outcome 1 text";
    private string outcome2 = "Outcome 2 text";
    private string outcome3 = "Outcome 3 text";
    private string outcome4 = "Outcome 4 text";

    // The text to display if the requirements aren't met
    private string invalidRequirementsText = "You don't meet the requirements for this event.";

    // To get and set stats
    EventGetter eg;

    void Start()
    {
        eg = new EventGetter();

        if (eg.getEntropy() > 0.75f)
        {
            invalidRequirementsText = "Due to unknown circumstances, the bakery has closed down";
            // exit event here
        }

        if (eg.getCurrency() < 3)
        {
            invalidRequirementsText = "You think this bakery is a charity? Come back when you have more coins";
            // exit event here
        }

        // TODO: 

        
        
    }

    // Update is called once per frame
    void Update()
    {


    }
}

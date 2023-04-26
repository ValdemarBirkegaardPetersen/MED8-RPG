using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int currency;
    public int charisma;
    public int intelligence;
    public int strength;
    public int health;

    public float entropy;
    public float patrol;
    public float karma;

    public GameObject stats;

    private Text statsText;

    void Awake()
    {
        currency = 10;
        charisma = 3;
        intelligence = 3;
        strength = 3;
        health = 100;

        entropy = 0.00f;
        patrol = 0f;
        karma = 0f;

        statsText = stats.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        updateStatsUI();
        
        // containing the stats in a range of 0-10 or 0-1 or -1-1
        if (currency < 0) { currency = 0; }

        if (charisma < 0) { charisma = 0; }
        if (charisma > 10) { charisma = 10; }

        if (intelligence < 0) { intelligence = 0; }
        if (intelligence > 10) { intelligence = 10; }

        if (strength < 0) { strength = 0; }
        if (strength > 10) { strength = 10; }

        if (health <= 0) { health = 1; }

        if (entropy < 0) { entropy = 0; }
        if (entropy > 1) { entropy = 1; }

        if (patrol < 0) { patrol = 0; }
        if (patrol > 1) { patrol = 1; }

        if (karma < -1) { karma = -1; }
        if (karma > 1) { karma = 1; }
    }


    public void updateStatsUI ()
    {
        //var statsText = stats.GetComponent<Text>();
        statsText.text =
            "Health: " + health + "\n" +
            "Currency: " + currency + "\n" +
            "Strength: " + strength + "\n" +
            "Charisma: " + charisma + "\n" +
            "Intelligence: " + intelligence;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int currency;
    public int charisma;
    public int intelligence;
    public int strength;
    public int health;

    private bool waitForDeathScene;
    
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

        waitForDeathScene = false;

        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += "The players stats at the beginning of the game: \n";
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += "Health: " + health + "\n" +
                                                                                                "Currency: " + currency + "\n" +
                                                                                                "Strength: " + strength + "\n" +
                                                                                                "Charisma: " + charisma + "\n" +
                                                                                                "Intelligence: " + intelligence + "\n" +
                                                                                                "Patrol: " + patrol + "\n" +
                                                                                                "Karma: " + karma + "\n";

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

        if (health <= 0) {
            health = 0;

            if (waitForDeathScene == false)
            {
                GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += "Player died at the last event. \n\nThe players stats at the end of the game: \n";
                GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += "Health: " + health + "\n" +
                                                                                                        "Currency: " + currency + "\n" +
                                                                                                        "Strength: " + strength + "\n" +
                                                                                                        "Charisma: " + charisma + "\n" +
                                                                                                        "Intelligence: " + intelligence + "\n" +
                                                                                                        "Patrol: " + patrol + "\n" +
                                                                                                        "Karma: " + karma + "\n";

                Debug.Log(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput); // for debugging, can be deleted
            }

            if (health <= 0)
            {
                waitForDeathScene = true;
            }

            if (Input.GetKeyDown(KeyCode.Z) && waitForDeathScene)
            {
                SceneManager.LoadScene("DeathScene");
            }



        }

        if (health >= 100)
        {
            health = 100;
        }

        if (entropy < 0) { entropy = 0; }
        if (entropy > 1) { entropy = 1; }

        if (patrol < 0) { patrol = 0; }
        if (patrol > 1) { patrol = 1; }

        if (karma < -1) { karma = -1; }
        if (karma > 1) { karma = 1; }
    }


    public void updateStatsUI()
    {
        string tempHealth = "";
        string tempStrength = "";
        string tempCharisma = "";
        string tempIntelligence = "";

        if (health >= 100)
        {
            tempHealth = " (MAX)";
        }
        if (strength >= 10)
        {
            tempStrength = " (MAX)";
        }
        if (charisma >= 10)
        {
            tempCharisma = " (MAX)";
        }
        if (intelligence >= 10)
        {
            tempIntelligence = " (MAX)";
        }


        //var statsText = stats.GetComponent<Text>();
        statsText.text =
            "Health: " + health + tempHealth + "\n" +
            "Currency: " + currency + "\n" +
            "Strength: " + strength + tempStrength + "\n" +
            "Charisma: " + charisma + tempCharisma + "\n" +
            "Intelligence: " + intelligence + tempIntelligence;
    }
}

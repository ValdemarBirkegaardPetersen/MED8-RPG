using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconToggler : MonoBehaviour
{
    public GameObject icon;
    public GameObject icon2;
    public PlayerStats playerStats;
    public PlayerController playerController;
    public GameObject gameObjectEvent;
    public int reqCurrency;
    public int reqIntelligence;
    public int reqStrength;
    public int reqCharisma;
    public float reqKarma;
    public float reqPatrol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObjectEvent.name == playerController.lastVisitedEvent){
            //Debug.Log("disabled");
            icon.SetActive(false);
            icon2.SetActive(false);
        } else {
            if(playerStats.charisma < reqCharisma || playerStats.intelligence < reqIntelligence || playerStats.currency < reqCurrency || playerStats.strength < reqStrength || playerStats.karma < reqKarma || playerStats.patrol > reqPatrol){
                icon.SetActive(false);
                icon2.SetActive(true);
            } else {
                icon.SetActive(true);
                icon2.SetActive(false);
            }
            //Debug.Log("enabled");

        }
        //Debug.Log("event: "+gameObjectEvent.name+"     last event: "+playerController.lastVisitedEvent);
    }
}

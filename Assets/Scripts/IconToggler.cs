using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconToggler : MonoBehaviour
{
    public GameObject icon;
    public PlayerController playerController;
    public GameObject gameObjectEvent;
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
        } else {
            //Debug.Log("enabled");
            icon.SetActive(true);
        }
        //Debug.Log("event: "+gameObjectEvent.name+"     last event: "+playerController.lastVisitedEvent);
    }
}

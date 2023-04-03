using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int currency = 10;
    public int charisma = 3;
    public int intelligence = 3;
    public int strength = 3;
    public int health = 100;

    public float entropy = 0;
    public float patrol = 0;
    public float karma = 0;

    void Start()
    {
        currency = 10;
        charisma = 3;
        intelligence = 3;
        strength = 3;
        health = 100;

        entropy = 0;
        patrol = 0;
        karma = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

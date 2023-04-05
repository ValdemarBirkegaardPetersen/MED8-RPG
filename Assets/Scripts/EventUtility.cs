using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUtility : MonoBehaviour
{

    public void Start()
    {
        
    }



    public int getCharisma()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().charisma;
    }

    
    public int getCurrency()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().currency;

    }

    public int getIntelligence()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().intelligence;
    }

    public int getStrength()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().strength;
    }

    public int getHealth()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().health;
    }

    public float getEntropy()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().entropy;
    }

    public float getPatrol()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().patrol;
    }

    public float getKarma()
    {
        return GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().karma;
    }


    public void setCurrency(int curr)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().currency = curr;
    }

    public void setCharisma(int charis)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().charisma = charis;
    }

    public void setIntelligence(int intel)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().intelligence = intel;
    }

    public void setStrength(int str)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().strength = str;
    }

    public void setHealth(int hp)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().health = hp;
    }

    public void setEntropy(float e)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().entropy = e;
    }

    public void setPatrol(float p)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().patrol = p;
    }

    public void setKarma(float k)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().karma = k;
    }

    public int CalculateOutcome(params float[] outcomes)
    {
        List<int> oContainer = new List<int>();
        float totalSum = 0;
        float totalLength = outcomes.Length;

        foreach (float v in outcomes)
        {
            oContainer.Add((int)v);
            totalSum += v;
        }

        System.Random rnd = new System.Random();
        float randomValue = rnd.Next(0, (int)totalSum);

        int previous = 0;
        int start = 0;
        int i = 0;
        for (i = 0; i < oContainer.Count - 1; i++)
        {
            previous += oContainer[i];
            if (randomValue >= start && randomValue <= previous)
            {
                break;
            }

            start += oContainer[i];
        }
        return i;
    }

}

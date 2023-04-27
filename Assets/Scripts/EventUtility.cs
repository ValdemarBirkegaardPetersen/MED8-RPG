using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventUtility : MonoBehaviour
{    

    public void Start()
    {

    }

    public void Update()
    {
        //chatgptObject.GetComponent<PlayerController>().chatgptInput += "hey";
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
        string temp = "-";
        if (GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().currency < curr)
        {
            temp = "+";
        }
        
        string diff = Mathf.Abs(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().currency - curr).ToString();
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().currency = curr;
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += temp + diff + " gold" + ", ";
    }
    public void setCharisma(int charis)
    {
        string temp = "-";
        if (GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().charisma < charis)
        {
            temp = "+";
        }             
        
        string diff = Mathf.Abs(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().charisma- charis).ToString();
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().charisma = charis;
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += temp + diff + " charisma" + ", ";
    }

    public void setIntelligence(int intel)
    {
        string temp = "-";
        if (GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().intelligence < intel)
        {
            temp = "+";
        }
        
        string diff = Mathf.Abs(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().intelligence - intel).ToString();
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().intelligence = intel;
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += temp + diff + " intelligence" + ", ";
    }

    public void setStrength(int str)
    {
        string temp = "-";
        if (GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().strength < str)
        {
            temp = "+";
        }

        string diff = Mathf.Abs(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().strength - str).ToString();
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().strength = str;
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += temp + diff + " strength" + ", ";
    }

    public void setHealth(int hp)
    {
        string temp = "-";
        if (GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().health < hp)
        {
            temp = "+";
        }

        string diff = Mathf.Abs(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().health - hp).ToString();
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().health = hp;
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += temp + diff + " health/HP" + ", ";
    }

    public void setEntropy(float e)
    {
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().entropy = e;
    }

    public void setPatrol(float p)
    {
        string temp = "-";
        if (GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().patrol < p)
        {
            temp = "+";
        }
        
        string diff = Mathf.Abs(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().patrol - p).ToString();
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().patrol = p;
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += temp + diff + " patrol" + ", ";
    }

    public void setKarma(float k)
    {
        string temp = "-";
        if (GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().karma < k)
        {
            temp = "+";
        }
        
        string diff = Mathf.Abs(GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().karma - k).ToString();
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerStats>().karma = k;
        GameObject.FindGameObjectWithTag("x").GetComponent<PlayerController>().chatgptInput += temp + diff + " karma" + ", ";
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

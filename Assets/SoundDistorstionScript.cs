using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDistorstionScript : MonoBehaviour
{
    public PlayerStats playerStats;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch = 1.125f-(playerStats.entropy/4);
        //Debug.Log("entropy: "+playerStats.entropy + " pitch: "+audioSource.pitch);
    }
}

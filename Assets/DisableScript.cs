using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisableScript : MonoBehaviour
{
    public GameObject screen;
    public TextMeshProUGUI text;
    private float timer;
    private float fade;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        fade = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //text = GetComponent<TextMeshProUGUI>();
        if(timer >= 2){
            fade += Time.deltaTime/4;
            text.enabled = true;
            text.color = new Color(1.0f, 1.0f, 1.0f, fade);

            if (Input.GetKeyUp(KeyCode.Space)){
                screen.SetActive(false);
            }
        }

    }
}

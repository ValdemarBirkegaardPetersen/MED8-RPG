using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledOrDisabled : MonoBehaviour
{
    public GameObject img;

    public void Trigger(){
        if(img.activeInHierarchy == false){
            img.SetActive(true);

        }
        else{
            img.SetActive(false);
        }
    }
}
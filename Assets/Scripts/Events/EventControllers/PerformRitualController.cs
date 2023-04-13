using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformRitualController : MonoBehaviour, Interactable
{
    [SerializeField] Dialog dialog;
    public void Interact(string outcomestr)
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog, outcomestr));
    }

}
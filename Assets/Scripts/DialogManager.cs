using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    [SerializeField] int lettersPerSecond;

    public event Action OnShowDialog;
    public event Action OnHideDialog;
    public PlayerStats playerStats;
    public GameObject blackScreen;

    public static DialogManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    Dialog dialog;
    int currentLine = 0;
    bool isTyping;
    public IEnumerator ShowDialog(Dialog dialog, string outcomeStr)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke();

        this.dialog = dialog;
        dialogBox.SetActive(true);
        dialog.Lines[0] = outcomeStr;
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public void changeDialogLine(Dialog dialog, string event_outcome_text)
    {
        dialog.Lines[0] = event_outcome_text;
    }

    public void HandleUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isTyping == false)
        {
            if(playerStats.waitForDeathScene){
                blackScreen.SetActive(true);
                //SceneManager.LoadScene("DeathScene");
            }
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
            }
            else
            {
                dialogBox.SetActive(false);
                currentLine = 0;
                OnHideDialog?.Invoke();
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach(var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }

}

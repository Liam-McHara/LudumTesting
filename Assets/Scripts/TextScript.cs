using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    Text textComponent;
    PanelManager pm;
    public string textToWrite;
    [Range(0.01f, 0.03f)]
    public float timeLapse;
    float lastUpdate;
    public bool writing = false;

    void Start()
    {
        textComponent = this.GetComponent<Text>();
        pm = FindObjectOfType<PanelManager>();
    }

    private IEnumerator BuildText()
    {
        pm.HideOptions();   // oculta les opcions mentre s'escriu
        writing = true;
        int i = 0;
        while (i < textToWrite.Length & writing)
        {
            i++;
            string text = textToWrite.Substring(0, i);
            if (i <= textToWrite.Length)    // Escriu els carácters restants invisibles, perque mantinguin l'espai que ocuparan
            {
                text += "<color=#00000000>" + textToWrite.Substring(i) + "</color>";
            }
            textComponent.text = text;
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSeconds(timeLapse);
            
        }
        if (!writing)   // si es cancela a mitja operació, escriu el que falta
        {
            textComponent.text = textToWrite;
        }
        pm.ShowOptions();   // mostra les opcions un cop acaba d'escriure
        writing = false;
    }

    public void CancelWrite()
    {
        writing = false;
    }

    public void Write(string newText)
    {
        
        textToWrite = newText;
        StartCoroutine(BuildText());
    }
    public void Clear()
    {
        textComponent.text = "";
    }
}

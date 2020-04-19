using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    Text textComponent;
    PanelManager pm;
    public string text;
    [Range(0.01f, 0.03f)]
    public float timeLapse;
    float lastUpdate;
    public bool writing = false;

    void Start()
    {
        textComponent = this.GetComponent<Text>();
        pm = FindObjectOfType<PanelManager>();
        //textComponent.text = "";
        StartCoroutine(BuildText());
    }

    private IEnumerator BuildText()
    {
        pm.HideOptions();   // oculta les opcions mentre s'escriu
        writing = true;
        int i = 0;
        while (i < text.Length & writing)
        {
            textComponent.text = string.Concat(textComponent.text, text[i]);
            //Wait a certain amount of time, then continue with the for loop
            yield return new WaitForSeconds(timeLapse);
            i++;
        }
        if (!writing)   // si es cancela a mitja operació, escriu el que falta
        {
            while (i < text.Length)
            {
                textComponent.text = string.Concat(textComponent.text, text[i]);
                i++;
            }
        }
        pm.ShowOptions();   // mostra les opcions un cop acaba d'escriure
        Debug.Log("SHOW OPTIONS");
        writing = false;
    }

    public void CancelWrite()
    {
        writing = false;
    }

    public void Write(string newText)
    {
        text = newText;
        StartCoroutine(BuildText());
    }
    public void Clear()
    {
        textComponent.text = "";
    }
}

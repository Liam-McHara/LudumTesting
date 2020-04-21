using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public Text textComponent;
    IntroManager im;
    public string text;
    [Range(0.01f, 0.03f)]
    public float timeLapse;
    float lastUpdate;
    public bool writing = false;

    void Start()
    {
        textComponent = this.GetComponent<Text>();
        im = FindObjectOfType<IntroManager>();

        //TESTING
        //textComponent.text = "";
        //StartCoroutine(BuildText());
    }

    private IEnumerator BuildText()
    {
        //im.HideButton();
        writing = true;
        int i = 0;
        
        while (i < text.Length & writing)
        {
            textComponent.text = textComponent.text + text[i];
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
        im.ShowButton();   // mostra les opcions un cop acaba d'escriure
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

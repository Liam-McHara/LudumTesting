using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameController gc;
    public TextScript ts;
    public GameObject background;
    public GameObject[] optionButtons;
    public string[] options;
    public bool visible = true;

    // ESPECIALITOS
    bool textInputOption = false;   // quan TRUE, fem malabars per introduir text en comptes de clicar opcions
    public GameObject specialOption1;

    public void ShowPanel(string str)   // Mostra el panel amb el text que toqui
    {
        background.SetActive(true);
        ts.Clear();
        ts.Write(str);
        visible = true;
    }

    public void UpdateText(string str)  // Actualitza el text del panel
    {
        ts.Clear();       // Activa o desactiva segons tipus de text  <<<<<<<<<<<<<<<<<<< CANVIAR SI TEXT FLUID a lo 80 DAYS
        HideOptions();
        ts.Write(str);
    }

    public void HidePanel()
    {
        background.SetActive(false);
        ts.Clear();
        visible = false;
        HideOptions();
    }



    public void ShowOptions()
    {
        Debug.Log("SHOW OPTIONS");

        if (textInputOption)    // Si es un dels casos especials, mostra un text input en comptes de botons
        {
            specialOption1.SetActive(true);
            textInputOption = false;    // baixa el flag
        }
        else        // NORMALMENT: Mostra les opcions estàndar
        {
            int opt = options.Length;
            for (int i = 1; i <= 4; ++i)
            {
                if (i <= opt)
                {
                    Debug.Log("Showing " + i);
                    optionButtons[i - 1].GetComponent<Text>().text = options[i - 1];    // Canvia el nom de la opció
                    optionButtons[i - 1].SetActive(true);   // Mostra la opció
                }
            }
        }
    }
    public void HideOptions()
    {
        for (int i = 1; i <= 4; ++i)
        {
            optionButtons[i - 1].SetActive(false);
        }
        specialOption1.SetActive(false);
    }

    // Actualitza les opcions disponibles
    public void UpdateOptions(string op1)
    {
        options = new string[] { op1 };

    }
    public void UpdateOptions(string op1, string op2)
    {
        options = new string[] { op1, op2 };
    }
    public void UpdateOptions(string op1, string op2, string op3)
    {
        options = new string[] { op1, op2, op3 };
    }
    public void UpdateOptions(string op1, string op2, string op3, string op4)
    {
        options = new string[] { op1, op2, op3, op4 };
    }
    public void UpdateOptions(int special)
    {
        switch (special)
        {
            case 1:
                textInputOption = true;
                break;
            default:
                break;
        }
    }

    public void Faster()    // Makes the UI interaction go faster
    {
        if (visible)
        {
            if (ts.writing) // Accelerates text showing
            {
                ts.CancelWrite();
            }
            else if (optionButtons.Length == 1)   // Si només hi ha una opció, la selecciona
            {
                // Selecciona la primera opció (SEGUR???)
            }
            
        }
    }
    
    public void TextInput()     // Envia el text introduit al GameController
    {
        string ans = specialOption1.GetComponentInChildren<InputField>().text;
        gc.TextOption(ans);
    }
}
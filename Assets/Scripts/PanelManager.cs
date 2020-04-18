using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameController gc;
    public TextScript ts;
    public Image background;
    public GameObject[] optionButtons;
    public string[] options;
    public bool visible = true;

    // ESPECIALITOS
    bool textInputOption = false;   // quan TRUE, fem malabars per introduir text en comptes de clicar opcions
    public GameObject specialOption1;

    public void ShowPanel(string str)   // Mostra el panel amb el text que toqui
    {
        background.enabled = true;
        ts.UpdateText(str);
        visible = true;
    }

    public void UpdateText(string str)  // Actualitza el text del panel
    {
        ts.UpdateText(str);
    }

    public void HidePanel()
    {
        background.enabled = false;
        visible = false;
        HideOptions();
    }



    public void ShowOptions()
    {
        if (textInputOption)    // Si es un dels casos especials, mostra un text input en comptes de botons
        {
            specialOption1.SetActive(true);
        }
        int opt = options.Length;
        for (int i = 1; i <= 4; ++i)
        {
            if (i <= opt)
            {
                optionButtons[i - 1].SetActive(true);
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
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    GameController gc;
    PanelManager pm;
    public IntroScript intS;
    public GameObject background;
    public GameObject beginButton;
    public bool visible = true;

    string intro1 = "Last night I had that nightmare again. My precious sunflower, withered, dead. Murdered.\nI don’t know what to do anymore. I know it’s going to happen tonight, I just know. So I have to find the murderer first.\nOh, my sunflower, the light of my days. My loyal companion... Even in my darkest hour I kept nurturing it, and that’s all that kept me sane.\nI don’t want it to die...\nI don’t want to be alone...\nI have to keep it alive.";
    string introN = "Once again, it happened. They managed to kill the sunflower. Am I trapped here for all eternity? Is this ever going to end? How many times will I have to go back and watch my beloved sunflower die? Why is this happening to me?! \nShush… I have to be strong, now. I have to quiet the voices. This diary is all that’s keeping me sane. I will relive the loop as many times as I must, until I find a way to stop it. A way to get out of here.\nA way to save my sunflower.";

    private void Start()
    {
        pm = FindObjectOfType<PanelManager>();
        gc = FindObjectOfType<GameController>();
    }

    public void ShowIntro(int l)
    {
        Debug.Log("Showing Intro " + l);
        background.SetActive(true);
        pm.HideMap();
        intS.Clear();
        if (l == 1) intS.Write(intro1);
        else intS.Write(introN);
        visible = true;
    }

    public void HideIntro()
    {
        Debug.Log("Hiding Intro ");
        background.SetActive(false);
        pm.ShowMap();
        intS.Clear();
        visible = false;
        beginButton.SetActive(false);
    }

    public void ShowButton()
    {
        beginButton.SetActive(true);
    }
    public void HideButton()
    {
        beginButton.SetActive(false);
    }

    public void Faster()    // Makes the UI interaction go faster
    {
        if (visible)
        {
            if (intS.writing) // Accelerates text showing
            {
                intS.CancelWrite();
            }
        }
    }
}

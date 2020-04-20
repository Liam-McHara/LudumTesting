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
    public string lastText = "";

    string intro1 = "Last night I had that nightmare again. My precious sunflower, withered, dead. Murdered.\nI don’t know what to do anymore. I know it’s going to happen tonight, I just know. So I have to find the murderer first.\nOh, my sunflower, the light of my days. My loyal companion... Even in my darkest hour I kept nurturing it, and that’s all that kept me sane.\nI don’t want it to die...\nI don’t want to be alone...\nI have to keep it alive.";
    string introN = "Once again, it happened. They managed to kill the sunflower. Am I trapped here for all eternity? Is this ever going to end? How many times will I have to go back and watch my beloved sunflower die? Why is this happening to me?! \nShush… I have to be strong, now. I have to quiet the voices. This diary is all that’s keeping me sane. I will relive the loop as many times as I must, until I find a way to stop it. A way to get out of here.\nA way to save my sunflower.";
    string endIntro1 = "It’s night time and I’m sitting here, at home, all alone. Waiting for them. I knew they were coming, but I can’t help but wonder. Have my preparations been enough? Have I been able to outsmart them?";
    string endIntro2 = "It’s night time and I’m sitting here, at home, all alone. Waiting for them. I knew they were coming, but I can’t help but wonder. Have my preparations been enough? Have I been able to outsmart them this time?";
    string str;

    private void Start()
    {
        pm = FindObjectOfType<PanelManager>();
        gc = FindObjectOfType<GameController>();
    }

    public void ShowIntro(int l)
    {
        
        Debug.Log("Showing Intro " + l);
        background.SetActive(true);
        if (l > 1) pm.HideMap();
        HideButton();
        if (l == 1)
        {
            lastText = "intro1";
            intS.Write(intro1);
        }
        else if (l == 2)
        {
            lastText = "endIntro1";
            intS.Write(endIntro1);
            gc.infoLoop = true;
        }
        else
        {
            lastText = "endIntro2";
            intS.Write(endIntro2);

        }
        visible = true;
    }

    public void Next()
    {
        if (lastText == endIntro1 | lastText == endIntro2)
        {
            // ------------------------------------   COSSOS   ------------------------------------------------
            if (!gc.itemLove)
            {
                lastText = "cos";
                str = "Suddenly, I hear a noise. The balcony window implodes, and my neighbour appears on my living room, fully geared with abseiling equipment. I didn’t anticipate that. She climbed down all the way from her own flat, two floors up. \nTime seems to freeze as she throws a final smile of triumph. She’s too close to the sunflower, and suddenly I know there’s nothing I can do to stop her. Not anymore. \nThen she pulls a string from her suit, and she immolates herself and the sunflower.\n… The world ends.";
                gc.infoNeighbour = true;
                intS.Write(str);
            }
            else if (!gc.itemGun)
            {
                lastText = "cos";
                str = "As the seconds tick away, I let out a small sigh of relief. Seems like I finally got rid of my neighbour. Perhaps this time… but no. As if it had been summoned by my thoughts, a sniper shoots an explosive bullet at the sunflower from one of the nearby roofs, engulfing the sunflower in a shroud of fire.\n… The world ends.";
                gc.infoSniper = true;
                intS.Write(str);
            }
            else if (!gc.infoEvilGirl)
            {
                lastText = "cos";
                str = "Has it been years? Months? I don’t know anymore. I look back at the time when a neighbour abseiling down from her flat and immolating herself was all it took to defeat me. Hah. I was so foolish, back then. So naive. But they keep using the same strategies, making the same moves. The same mistakes. Only I keep learning, improving. And this time, this time I shall get it right. The neighbour, the sniper, the poison, I got rid of them all. Long live the sunflower!\nSuddenly, the lights go out. I look around, confused. I hear a spraying sound, and I start feeling sleepy. So sleepy. \nThen I hear the voice. It’s a female voice. Cheerful, soft. I know it’s her. She’s the one I’ve been fighting all along. The Destroyer of Suns. And I’m sure I’ve heard her before… somewhere.\n“It’s all right”, she whispers. “Why do you resist it so much? A world without time won’t be so bad, you know. According to my calculations, we will all be young forever. Don’t you want to live forever...?”\n… The world ends.";
                gc.infoFinalboss = true;
                intS.Write(str);
            }
        }
        else if (lastText == "cos")
        {
            intS.Write(introN);
        }
    }

    public void HideIntro()     // RESETEJAR VARIABLES DE LOOP AQUI
    {
        Debug.Log("Hiding Intro ");
        background.SetActive(false);
        pm.ShowMap();
        intS.Clear();
        visible = false;
        beginButton.SetActive(false);
        gc.ResetItems();
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

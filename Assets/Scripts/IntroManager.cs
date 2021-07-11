using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    GameController gc;
    PanelManager pm;
    public IntroScript intS;
    public IntroScript endIntS;
    [SerializeField] private Image endImage;
    public GameObject background;
    public GameObject continueButton;
    public bool visible = true;
    public string lastText = "";

    [Header("End Sprites")]
    [SerializeField] private Sprite endSpriteNoLove;
    [SerializeField] private Sprite endSpriteNoGun;
    [SerializeField] private Sprite endSpriteNoPoison;
    [SerializeField] private Sprite endSpriteNoEvil;
    [SerializeField] private Sprite endSpriteVictory;

    string intro1 = "Last night I had that nightmare again. My precious sunflower, withered, dead. Murdered.\nI don’t know what to do anymore. I know it’s going to happen tonight, I just know. So I have to find the murderer first.\nOh, my sunflower, the light of my days. My loyal companion... Even in my darkest hour I kept nurturing it, and that’s all that kept me sane.\nI don’t want it to die...\nI don’t want to be alone...\nI have to keep it alive.";
    string introN = "Once again, it happened. They managed to kill the sunflower. Am I trapped here for all eternity? Is this ever going to end? How many times will I have to go back and watch my beloved sunflower die? Why is this happening to me?! \nShush… I have to be strong, now. I have to quiet the voices. This diary is all that’s keeping me sane. I will relive the loop as many times as I must, until I find a way to stop it. A way to get out of here.\nA way to save my sunflower.";

    string endIntro1 = "It’s night time and I’m sitting here, at home, all alone. Waiting for them. I knew they were coming, but I can’t help but wonder. Have my preparations been enough? Have I been able to outsmart them?\n";
    string endIntro2 = "It’s night time and I’m sitting here, at home, all alone. Waiting for them. I knew they were coming, but I can’t help but wonder. Have my preparations been enough? Have I been able to outsmart them this time?\n";
   
    // cosos Ending
    string noLove = "Suddenly, I hear a noise. The balcony window implodes, and my neighbour appears on my living room, fully geared with abseiling equipment. I didn’t anticipate that. She climbed down all the way from her own flat, two floors up.";
    string noLove2 = "Time seems to freeze as she throws a final smile of triumph. She’s too close to the sunflower, and suddenly I know there’s nothing I can do to stop her. Not anymore. \nThen she pulls a string from her suit, and she immolates herself and the sunflower.\n… The world ends.";
    string noGun = "As the seconds tick away, I let out a small sigh of relief. Seems like I finally got rid of my neighbour. Perhaps this time… but no. As if it had been summoned by my thoughts, a sniper shoots an explosive bullet at the sunflower from one of the nearby roofs, engulfing the sunflower in a shroud of fire.\n… The world ends.";
    string noPoison = "This time it will work, I tell myself. I made so many preparations. I’m even starting to forget what the world was like before the loop. This time I got rid of my neighbour, and I destroyed the sniper’s weapon. There’s nothing that should go wrong now…";
    string noPoison2 = "Suddenly, I wake up with a shiver, realizing I have fallen asleep. It’s morning, and the sun shines. I look at my phone, and the date shows the next day. I did it, I finally… oh. Wait. Something’s wrong with the sunflower. I look at it with disbelief. The leaves are withered. It is dying. How could it be? I’m sure nobody entered the flat. Perhaps it was… poison?\n… The world ends.";
    string noEvil = "Has it been years? Months? I don’t know anymore. I look back at the time when a neighbour abseiling down from her flat and immolating herself was all it took to defeat me. Hah. I was so foolish, back then. So naive. But they keep using the same strategies, making the same moves. The same mistakes. Only I keep learning, improving. And this time, this time I shall get it right. The neighbour, the sniper, the poison, I got rid of them all. Long live the sunflower!";
    string noEvil2 = "Suddenly, the lights go out. I look around, confused. I hear a spraying sound, and I start feeling sleepy. So sleepy. \nThen I hear the voice. It’s a female voice. Cheerful, soft. I know it’s her. She’s the one I’ve been fighting all along. The Destroyer of Suns. And I’m sure I’ve heard her before… somewhere.";
    string noEvil3 = "''It’s all right'', she whispers. ''Why do you resist it so much? A world without time won’t be so bad, you know. According to my calculations, we will all be young forever. Don’t you want to live forever...?''\n… The world ends.";
    string victory = "First, it was the neighbour. Then the sniper. Then poison. Then, her. \nI sit calmly in my sofa.I look, but I no longer see the world. I only see causality. The universe is under my spell.I own the trajectory of every fly, of every speck of dust.Of everything that lives and moves.\nI am millenary.";
    string victory2 = "And then she comes, like she has to. Believing she has won, like always. But not this time. She may be brilliant beyond comprehension, but she’s still a slave of causality. I can see through her every feint, her every plan and counterplan.";
    string victory3 = "We meet on the roof, by moonlight. She looks at me. A little girl, just eight years old. I know how long until she blinks again. I know how long she will exhale for. She looks at me, and she knows I know.\n''It seems my calculations were wrong, after all. Destroying the Guiding Sunflower doesn’t stop time… just resets it. But not for you. How long have you been trapped in here?'', she wonders.\n''Eons''.";
    string victory4 = "I look at the clouds and I realize that, suddenly, I am no longer God. This is all new time, out of the loop, beyond my kingdom. I look at the world and it all seems alien, unfathomable. What was it like to live without knowing everything? Who was I before this began? I no longer remember.But who cares. ";
    string str;

    private void Start()
    {
        pm = FindObjectOfType<PanelManager>();
        gc = FindObjectOfType<GameController>();
    }

    public void ShowIntro(int l)
    {
        lastText = "";
        HideButton();
        AudioManager.PlayMusic(AudioManager.Music.opening);
        // Debug.Log("Showing Intro " + l);
        background.SetActive(true);
        if (l > 1) pm.HideMap();
        if (l == 1)
        {
            lastText = "intro1";
            intS.Write(intro1);
        }
        else if (l == 2)
        {
            lastText = "endIntro1";     // END INTRO 1
            intS.Write(endIntro1);
            gc.infoLoop = true;
        }
        else
        {
            lastText = "endIntro2";     // END INTRO 2
            intS.Write(endIntro2);

        }
        visible = true;
    }

    public void Next()
    {
        AudioManager.PlaySound(AudioManager.Sound.click);
        // Debug.Log("Lastext: " + lastText);
        if (lastText == "endIntro1" | lastText == "endIntro2")
        {
            // ------------------------------------   COSSOS   ------------------------------------------------
            intS.Clear();
            endIntS.Clear();
            HideButton();
            if (!gc.itemLove)
            {
                lastText = "noLove";        // noLove Ending
                endIntS.Write(noLove);
                endImage.color = Color.white;
                endImage.sprite = endSpriteNoLove;
                gc.infoNeighbour = true;
            }
            else if (!gc.itemGun)
            {
                lastText = "noGun";         // noGun Ending
                endIntS.Write(noGun);
                endImage.color = Color.white;
                endImage.sprite = endSpriteNoGun;
                gc.infoSniper = true;
            }
            else if (!gc.itemPoison)
            {
                lastText = "noPoison";      // noPoison Ending
                endIntS.Write(noPoison);
                gc.infoFinalboss = true;
            }
            else if (!gc.infoEvilGirl)
            {
                lastText = "noEvil";        // noEvil Ending    (part1)
                endIntS.Write(noEvil);
                gc.infoFinalboss = true;
            }
            else
            {
                lastText = "victory";       // victory Ending    (part1)
                endIntS.Write(victory);
            }
        }
        else if (lastText == "noLove")      
        {
            lastText = "noLove2";           // noLove Ending (p2)
            HideButton();
            endIntS.Clear();
            endIntS.Write(noLove2);
        }
        else if (lastText == "noPoison")
        {
            lastText = "noPoison2";           // noPoison Ending (p2)
            HideButton();
            endImage.color = Color.white;
            endImage.sprite = endSpriteNoPoison;
            endIntS.Clear();
            endIntS.Write(noPoison2);
        }
        else if (lastText == "noEvil")
        {
            lastText = "noEvil2";           // noEvil Ending (p2)
            HideButton();
            endImage.color = Color.white;
            endImage.sprite = endSpriteNoEvil;
            endIntS.Clear();
            endIntS.Write(noEvil2);
        }
        else if (lastText == "noEvil2")
        {
            lastText = "noEvil3";           // noEvil Ending (p3)
            HideButton();
            endIntS.Clear();
            endIntS.Write(noEvil3);
        }

        else if (lastText == "victory")
        {
            lastText = "victory2";          // victory Ending    (part2)
            HideButton();
            endImage.color = Color.white;
            endImage.sprite = endSpriteVictory;
            endIntS.Clear();
            endIntS.Write(victory2);
        }
        else if (lastText == "victory2")
        {
            lastText = "victory3";          // victory Ending    (part3)
            HideButton();
            endIntS.Clear();
            endIntS.Write(victory3);
        }
        else if (lastText == "victory3")
        {
            lastText = "victory4";          // victory Ending    (part4)
            HideButton();
            endIntS.Clear();
            endIntS.Write(victory4);
        }
        else if (lastText == "victory4")
        {
            Debug.Log("GAME OVER");
            // GAME OVER :D          <--- Aquí se suposa que ja s'ha completat el joc i s'ha mostrat el text de victoria. What's next?
            HideButton();
            endIntS.Clear();
            endIntS.Write("GAME OVER :)");
        }

        else if (lastText == "noLove" | lastText == "noLove2" | lastText == "noGun" | lastText == "noPoison" | lastText == "noEvil3")   // després del cos...
        {
            endIntS.Clear();
            endImage.color = new Color(0,0,0,0);
            HideButton();
            lastText = "introN";    // INTRO 2
            intS.Write(introN);
        }
        else HideIntro();
    }

    public void HideIntro()     // RESETEJAR VARIABLES DE LOOP AQUI
    {
        AudioManager.PlayMusic(AudioManager.Music.map);

        // Debug.Log("Hiding Intro ");
        background.SetActive(false);
        pm.ShowMap();
        intS.Clear();
        endIntS.Clear();
        endImage.color = new Color(0, 0, 0, 0);

        visible = false;
        continueButton.SetActive(false);
        gc.ResetItems();
    }

    public void ShowButton()
    {
        continueButton.SetActive(true);
    }
    public void HideButton()
    {
        continueButton.SetActive(false);
    }

    public void Faster()    // Makes the UI interaction go faster
    {
        // SoundManager.PlaySound(SoundManager.Sound.click);
        if (visible)
        {
            if (intS.writing) // Accelerates text showing
            {
                intS.CancelWrite();
            }
            if (endIntS.writing)
            {
                endIntS.CancelWrite();
            }
        }
    }
}

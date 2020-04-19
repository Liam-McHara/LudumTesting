using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    AudioManager am;
    PanelManager pm;

    
    // VARIABLES
    public int fase;    // fase del día (1 - 5)
    public int loop = 1;

    public string continueText = ">";

    /*  0 - mapa
     *  1 - casa
     *  2 - parc
     *  3 - abocador
     *  4 - almacen
     *  5 - pizzeria
     *  6 - planta processament d'aigua
     *  7 - passeig
     *  8 - escola
     */
    public int place = 0;

    

    // Variables de coneixement (permanents)
    public bool knowX = false;

    // Character paths  // DEPRECATED???
    public int charAPath = 1;

    // Condicions temporals (es resetejen a cada bucle)
    public bool v7_001, v7_009 = false;     // passeig

    // Ultima part de narracio mostrada
    public string lastText;



    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponentInChildren<AudioManager>();
        pm = FindObjectOfType<PanelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) pm.Faster(); // accelera la UI (text, opcions predefinides...)
    }


    // MAPA
    public void GotoCasa()
    {
        //pm.ShowPanel("Going to CASA");
        Debug.Log("Going to CASA");
        place = 1;

        pm.ShowPanel("a sdoif aoisdnf oansdfo nasdof \nnosdf osdnfo ndof nsadofn osdn foiadsof noasdnfo nasdofna sdfpmsadpf mas");
    }
    public void GotoParque()
    {
        Debug.Log("Going to PARQUE");
        place = 2;

    }
    public void GotoAbocador()
    {
        Debug.Log("Going to ABOCADOR");
        place = 3;

    }
    public void GotoAlmacen()
    {
        Debug.Log("Going to ALMACEN");
        place = 4;

    }
    public void GotoPizza()
    {
        Debug.Log("Going to PIZZA");
        place = 5;

    }
    public void GotoAigua()
    {
        Debug.Log("Going to AIGUA");
        place = 6;

    }
    public void GotoPasseig()                   // TESTING SCENE <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    {
        Debug.Log("Going to PASSEIG");
        place = 7;
        lastText = "001";   //    < 001 >
        // Prepara el text
        string str;
        if (!v7_001) str = "My search for new clues led me to the main avenue of the town. Everyone passes through here at some point, so I figured that, logically, the assassin would do so too. As soon as I came to the avenue, my attention was caught by...";
        else
        {
            v7_001 = true;
            str = "I came back to the Avenue. I could feel there was something left for me to do there. As soon as I got there, I headed to…";
        }
        // Prepara les opcions...
        string op1 = "...a suspicious alleway...";
        string op2 = "...an innocent looking girl...";
        string op3 = "...a chocolate store...";
        pm.UpdateOptions(op1, op2, op3);    // ...i les actualitza
        // Mostra el panell amb text i opcions corresponents
        pm.ShowPanel(str);

    }
    public void GotoEscola()
    {
        Debug.Log("Going to ESCOLA");
        place = 8;

    }

    public void GotoMapa()
    {
        Debug.Log("Going to MAPA");
        place = 0;
        ++fase;
        if (fase > 5) TimeTravel();
        pm.HidePanel();
    }


    // OPCIONES
    public void Option1()
    {
        Debug.Log("Option 1");
        switch (place)
        {
            case 7: // PASSEIG
                if (lastText == "001")
                {
                    lastText = "002";       // < 002 >
                    string str = "a suspicious alleway. If I was a murderer of sunflowers, that’s clearly kind of play where I would hide to plot my evil plans. \nThe alleway was empty except for a dirty dog and some broken bottles. I was about to leave when I heard a mysterious voice that seemed to come from nowhere in particular.  \n“Pssst, you! Yeah, you! Do you know how many times the sun rose today?”";
                    pm.UpdateOptions(1);
                    pm.UpdateText(str);
                }
                else if (lastText == "002b")
                {
                    lastText = "003";       // < 003 >
                    string str = "“Well, I am quite worried about my sunflower”, I admitted. \n“Ah, and as well you should”, assured the Voice, seriously. “Remember you are not alone in your endeavor, noble Guardian.There are others like you, others who oppose the tyranny of the Destroyer of Suns. By their love of sunflowers you shall recognize them.And now go in peace, young Guardian.”";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "003" | lastText == "005" | lastText == "006" | lastText == "007")
                {
                    lastText = "008";   //      < 008 > 
                    string str = "After that came only silence, and I was left alone feeling quite unsure of what exactly had happened.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "006";    //      < 006 >
                    string str = "“I’d say you’re just an idiot hiding under a sewer door…” I replied, losing my temper. \n“Brother, you’re not really angry with me, but with yourself. Sunflowers, grant patience to this lost lamb. He’ll be back once he’s ready to hear the Truth”.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                else if (lastText == "008") GotoMapa(); 
                break;
            default:
                break;
        }

    }
    public void Option2()
    {
        Debug.Log("Option 2");
        switch (place)
        {
            case 7: // PASSEIG
                if (lastText == "001")
                {
                    lastText = "009";   //    < 009 >
                    string str;
                    if (!v7_001) str = "an innocent looking girl, about eight or nine years old. She was jumping rope on the sidewalk, but as soon as I approached her she flashed me a charming smile. “Good evening, sir! Did you get lost?”, she asked with wide eyes.";
                    else str = "an innocent looking girl. ”Hey, it’s you again!” she said, “Are you still lost?”";
                    string op1, op2, op3;
                    op1 = "“No… I’m just looking for someone, although I don’t really know who.”";
                    op2 = "“All my life. How about you?”";
                    op3 = "“Do you like chocolate?”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "002b")
                {
                    lastText = "004";      //    < 004 > 
                    string str = "“And who the hell are you?”, I asked quite briskly. I admit I don’t take too kindly to invisible strangers startling me in small alleways. \n“Worry not, sunflower Brother. As I said, I am the Mysterious Voice™, Protector of the Poor and Helpless, Saver of Worlds, and Professional Adventure Advisor.”";
                    string op1, op2;
                    op1 = "“I’d say you’re just an idiot hiding under a sewer door…”";
                    op2 = "“If you say so…”";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "007";      //    < 007 >
                    string str = "“If you say so…”, I said, hesitating. \n“Of course I say so”, replied the Voice with unwavering confidence. “Now go save a space-time continuum or two. And remember me when you find yourself in need of a friendly, mysterious Voice.”";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                break;
            default:
                break;
        }
    }
    public void Option3()
    {
        Debug.Log("Option 3");
        switch (place)
        {
            case 7: // PASSEIG

                break;
            default:
                break;
        }

    }
    public void Option4()
    {
        Debug.Log("Option 4");
        switch (place)
        {
            case 7: // PASSEIG

                break;
            default:
                break;
        }

    }

    // ------------------------------------------------- SPECIAL OPTIONS (text)------
    public void TextOption(string ans)      
    {
        Debug.Log("Text answer: " + ans);
        
        switch (place)
        {
            case 7:     // PASSEIG
                if (lastText == "002")
                {
                    lastText = "002b";      //  < 002b >
                    // Prepara el nou text
                    string s1, s2, str;
                    if (ans == loop.ToString())
                        s1 = "The voice chuckled to itself. “Indeed, brother. Indeed. Anyway,";
                    else
                        s1 = "“Oh, dear, so innocent. It rose " + loop.ToString() + " times already. Anyway,";
                    s2 = "you look kind of down. Seems like you might need some advise from your friendly next door mysterious voice, amirite?”\nAt first I thought I was imagining voices again, but this one seemed too real to be a figment. In fact, as I listened I realized the sound seemed to be coming from the sewer door directly under my feet. ";
                    str = s1 + s2;
                    // Prepara les noves opcions
                    string op1, op2;
                    op1 = "Well, I am quite worried about my sunflower…";
                    op2 = "And who the hell are you?";
                    if (loop < 2) pm.UpdateOptions(op1, op2);
                    else
                    {
                        string op3 = "I think I’m trapped in a time loop!";
                        pm.UpdateOptions(op1, op2, op3);
                    }
                    // Mostra el nou panell amb text i opcions
                    pm.UpdateText(str);
                }
                break;
            default:
                break;
        }

    }


    public void TimeTravel()
    {
        ++loop;   // Actualitza el contador de loops
        fase = 1;   // Torna a la fase 1


        //Reseteja condicions temporals
        v7_001 = false;
    }
}
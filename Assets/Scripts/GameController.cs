using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // TESTING
    public bool showIntro = true;
    AudioManager am;
    PanelManager pm;
    IntroManager im;

    
    // VARIABLES
    public int fase;    // fase del día (1 - 5)
    public int loop = 1;



    public string continueText = ">";
    public string beginLoopText = "Start";

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
    public bool infoCrash, infoVistNena = false;

    // Condicions temporals (es resetejen a cada bucle)
    public bool v7_001, v7_009, itemDeadGirl, itemChocolate = false;     // passeig

    // Ultima part de narracio mostrada
    public string lastText;

    string str, op1, op2, op3, op4;


    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponentInChildren<AudioManager>();
        pm = FindObjectOfType<PanelManager>();
        im = FindObjectOfType<IntroManager>();
        
        im.ShowIntro(loop);     //      < FIRST LOOP >
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
        if (!v7_001) str = "My search for new clues led me to the main avenue of the town. Everyone passes through here at some point, so I figured that, logically, the assassin would do so too. As soon as I came to the avenue, my attention was caught by...";
        else
        {
            v7_001 = true;
            str = "I came back to the Avenue. I could feel there was something left for me to do there. As soon as I got there, I headed to…";
        }
        // Prepara les opcions...
        op1 = "...a suspicious alleway...";
        op2 = "";
        op3 = "...a chocolate store...";
        if (fase > 3)
        {
            op2 = "...an innocent looking girl...";
            infoVistNena = true;
        } 
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
            case 7:                         //  >>PASSEIG<<
                if (lastText == "001")
                {
                    lastText = "002";       // < 002 >
                    str = "a suspicious alleway. If I was a murderer of sunflowers, that’s clearly the kind of place where I would hide to plot my evil plans. \nThe alleway was empty except for a dirty dog and some broken bottles. I was about to leave when I heard a mysterious voice that seemed to come from nowhere in particular. \n“Pssst, you! Yeah, you! Do you know how many times the sun rose today?”";
                    pm.UpdateOptions(1);
                    pm.UpdateText(str);
                }
                else if (lastText == "002b")
                {
                    lastText = "003";       // < 003 >
                    str = "“Well, I am quite worried about my sunflower”, I admitted. \n“Ah, and as well you should”, assured the Voice, seriously. “Remember you are not alone in your endeavor, noble Guardian.There are others like you, others who oppose the tyranny of the Destroyer of Suns. By their love of sunflowers you shall recognize them.And now go in peace, young Guardian.”";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "003" | lastText == "005" | lastText == "006" | lastText == "007")
                {
                    lastText = "008";   //      < 008 > 
                    str = "After that came only silence, and I was left alone feeling quite unsure of what exactly had happened.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "006";    //      < 006 >
                    str = "“I’d say you’re just an idiot hiding under a sewer door…” I replied, losing my temper. \n“Brother, you’re not really angry with me, but with yourself. Sunflowers, grant patience to this lost lamb. He’ll be back once he’s ready to hear the Truth”.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008") GotoMapa(); //  [ RETURN ]
                else if (lastText == "009")
                {
                    lastText = "010";       //  < 010 >
                    str = " “No… I’m just looking for someone, although I don’t really know who,” I answered feeling a bit down.\n“Oh, that seems tricky,” she said, and then her face lit up. “You know what? Maybe I can help you find this person!” she said brightly.";
                    op1 = "“No, you wouldn’t know someone like that”.";
                    op2 = "“Sure, why not”.";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "010")
                {
                    lastText = "011";       //  < 011 >
                    str = "“No, you wouldn’t know someone like that. But thanks anyway for asking”. \nShe smiled at me again, and then began jumping the rope again.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "014";       //  < 014 >
                    str = "“Why are they so busy, if I may ask? Does it have anything to do with sunflowers?”, I asked, eyeing her suspiciously. She smiled at me innocently, not seeming to notice my tension. \n“Oh, you know. My mom’s a teacher at the local school, so she’s always busy with homework, and my dad works double shifts as a security guard at the water processing plant.” \nShe raised her head and stared frankly into my eyes. “Being an adult isn’t too fun, is it?”\nI didn’t really know what to answer to that.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "017")
                {
                    lastText = "018";       //  < 018 >
                    str = "“No, it was just a thought,” I said, feeling sorry for her face of disappointment.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "025";       //  < 025 >
                    str = "his favourite chocolate. “Ahhh, hard to say, hard to say…” he muttered to himself, before finally handing me a bar of 80% homemade organic chocolate. \nI paid in cash and asked if he had seen anyone who looked like they might hate sunflowers, but the shopkeeper just stared blankly at me, so I left.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "011" | lastText == "012" | lastText == "013" | lastText == "014" | lastText == "015" | 
                    lastText == "016" | lastText == "017" | lastText == "018" | lastText == "019")
                {
                    if (fase == 4)
                    {
                        lastText = "021";   //  < 021 >
                        str = "I left the main avenue feeling lost and lonely among the crowd of passers-by. It was getting dark already, and I had a sunflower to protect at home.";
                        pm.UpdateOptions(continueText);
                        pm.UpdateText(str);
                    }
                    else if (fase == 5)
                    {
                        lastText = "022";   //  < 022 >
                        infoCrash = true;
                        str = "I was about to say goodbye when suddenly a huge van crashed against a red mailbox less than five meters away from us. I yelped and jumped away, terrified, but apparently everyone was fine, including the driver. With all the chaos I lost sight of the girl, and soon afterwards I left as well.";
                        pm.UpdateOptions(continueText);
                        pm.UpdateText(str);
                    }
                }
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            default:
                Debug.Log("Default caseB: Going to MAPA");
                GotoMapa();  //  [ RETURN ]
                break;
        }

    }
    public void Option2()
    {
        Debug.Log("Option 2");
        switch (place)
        {
            case 7:                         //  >> PASSEIG <<
                if (lastText == "001")
                {
                    lastText = "009";   //    < 009 >
                    if (!v7_001) str = "an innocent looking girl, about eight or nine years old. She was jumping rope on the sidewalk, but as soon as I approached her she flashed me a charming smile. “Good evening, sir! Did you get lost?”, she asked with wide eyes.";
                    else str = "an innocent looking girl. ”Hey, it’s you again!” she said, “Are you still lost?”";
                    op1 = "“No… I’m just looking for someone, although I don’t really know who.”";
                    op2 = "“All my life. How about you?”";
                    op3 = "“Do you like chocolate?”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "002b")
                {
                    lastText = "004";      //    < 004 > 
                    str = "“And who the hell are you?”, I asked quite briskly. I admit I don’t take too kindly to invisible strangers startling me in small alleways. \n“Worry not, sunflower Brother. As I said, I am the Mysterious Voice™, Protector of the Poor and Helpless, Saver of Worlds, and Professional Adventure Advisor.”";
                    op1 = "“I’d say you’re just an idiot hiding under a sewer door…”";
                    op2 = "“If you say so…”";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "007";      //    < 007 >
                    str = "“If you say so…”, I said, hesitating. \n“Of course I say so”, replied the Voice with unwavering confidence. “Now go save a space-time continuum or two. And remember me when you find yourself in need of a friendly, mysterious Voice.”";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "009")
                {
                    lastText = "013";       //  < 013 >
                    str = "“All my life. How about you?” I asked back.\n“Oh, I live right over there,” she said, waving vaguely to the right. “But I get bored at home. My dad and my mom are always so busy... “ she said, pouting. ";
                    
                    op1 = "“Why are they so busy?”";
                    op2 = "“Why don’t you get a plant?”";
                    op3 = "“I get lonely too”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "010")
                {
                    lastText = "012";       //  < 012 >
                    str = " “Sure, why not. Do you know someone with a murderous hatred for sunflowers?”, I asked, glad to finally find someone willing to help. \nShe pondered at this quite seriously for a few seconds, wrinkling her forehead. “You mean... those cute yellow flowers that are always facing the sun? Why would anyone hate that?”.\n“My thoughts exactly,” I agreed quite passionately. “It’s okay, forget about it”.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "015";       //  < 015 >
                    str = "“Why don’t you get a plant? That’s what I did”, I offered helpfully. \n“A plant? What kind of plant?”\n“A sunflower” I replied automatically. \nShe eyed me curiously. “I will think about it. Maybe mom would get me one if I ask”, she finally said before resuming her rope jumping. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "017")
                {
                    lastText = "019";       //  < 019 >
                    str = "“Sure, here you are,” I said, handing her the chocolate bar I had bought before.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "026";       //  < 026 >
                    str = "his most expensive chocolate. “Well, I have some Amedei Porcelana from Tuscana, Italy. It’s an amazing dark chocolate, but it’s certainly not cheap... “\nI paid in cash and asked the shopkeeper if he had seen anyone who looked like they might hate sunflowers, but he just stared blankly at me, so I left. ";
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
            case 7:                         //  >> PASSEIG <<
                if (lastText == "001")
                {
                    lastText = "024";       //  < 024 >
                    str = "a chocolate store. What can I say - I may cherish sunflowers, but I have a love for all edible seeds, and chocolate is no exception. \nThe shop was well stocked, and the shopkeeper was a smiling old man with a bushy beard. I asked him for… ";
                    op1 = "...his favourite chocolate...";
                    op2 = "...his most expensive chocolate...";
                    if (infoVistNena)
                    {
                        op3 = "...whatever a child might like...";
                        pm.UpdateOptions(op1, op2, op3);
                    }
                    else pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "002b")
                {
                    lastText = "005";       //  < 005 >
                    str = "“My, my. I’m glad to see the Guiding Sunflower has such a perceptive guardian. Keep in mind that not everyone follows the exact same patterns every loop. Something to do with quantum decoherence in the brain microtubules, I’m told. Anyway, make good use of the gift the Guiding Sunflower has bestowed upon you to save It, and to save us all. Go in peace, young guardian.”";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "009")
                {
                    lastText = "017";       //  < 017 >
                    str = "“Do you like chocolate?” I asked, ignoring her question. Her face brightened up immediately. \n“Of course!” she yelled in delight. “Why, do you have some?”";
                    op1 = "“No, it was just a thought”";
                    if (itemChocolate) op2 = "“Sure, here you are”";
                    if (itemChocolate & infoCrash) op3 = "“Sure, but I need your help”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "016";       //  < 016 >
                    str = "“I get lonely too”, I said. I had never told anyone anything like that before, but I was feeling a strange kind of connection with this little girl. Perhaps it was because somehow, under her cheerful appearance, she seemed as sad as I was. “To be honest, sometimes I feel like my only reason for going through the day is taking care of my sunflower”.\nShe gave me a sympathetic smile and said nothing else. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "017")
                {
                    lastText = "020";       //  < 020 >
                    itemDeadGirl = true;
                    str = "“Sure, but I need your help”, I said slowly. “Do you see that red mailbox over there? I need you to put that letter in for me, and then I’ll give you the chocolate.”\nJust as she was leaning against the mailbox to throw in the letter, the van crashed against both of them, just as I had predicted. I heard someone calling for an ambulance, but I was already far away by then. \nI can’t say I’m proud of what I did, but desperate circumstances call for desperate measures.  And, in my defense, I knew she was going to be fine as soon as the loop reset. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "027";       //  < 027 >
                    str = "whatever a child might like, thinking of the little girl I had seen playing outside. \nI paid in cash and asked the shopkeeper if he had seen anyone who looked like they might hate sunflowers, but he just stared blankly at me, so I left.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
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
            case 7:                         //  >> PASSEIG <<

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
                    
                    op1 = "Well, I am quite worried about my sunflower…";
                    op2 = "And who the hell are you?";
                    if (loop < 2) pm.UpdateOptions(op1, op2);
                    else
                    {
                        op3 = "I think I’m trapped in a time loop!";
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
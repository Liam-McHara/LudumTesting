using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Variables de coneixement (permanents)
    public bool infoCrash, infoVistNena, infoGorra, infoWarehouse = false;

    // Condicions temporals (es resetejen a cada bucle)
    public bool item2b1, itemWater, itemFlowers, itemLove, itemKillLady = false;    // parc
    public bool v7_001, v7_009, itemDeadGirl, itemChocolate = false;     // passeig

    // Hobo
    bool hobo = false;

    // TESTING
    public bool showIntro = true;

    AudioManager am;
    PanelManager pm;
    IntroManager im;

    public int t;    // turno del día (1 - 5)
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
    
    public string lastText;  // Ultima part de narracio mostrada
    string str, op1, op2, op3, op4;


    void Start()
    {
        am = this.GetComponentInChildren<AudioManager>();
        pm = FindObjectOfType<PanelManager>();
        im = FindObjectOfType<IntroManager>();

        if (showIntro) im.ShowIntro(loop);     //      < FIRST LOOP >
        else im.HideIntro();

        hobo = Random.value > 0.5f; // Mou el hobo
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) pm.Faster(); // accelera la UI (text, opcions predefinides...)
    }


    // MAPA
    public void GotoCasa()
    {
        Debug.Log("Going to CASA");
        place = 1;
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      CASA < 001 >
        
    }
    public void GotoParque()
    {
        Debug.Log("Going to PARQUE");
        place = 2;
        lastText = "001";       //      PARK < 001 >
        str = "I decided to take a stroll through the town’s park, thinking that perhaps it would help me clear my thoughts. It was almost silent there, except for the refreshing sound of the wind through the leaves. I liked the park even though it had no sunflowers - I had looked.\nAs I was walking around, I spotted…";
        op1 = op2 = op3 = op4 = "";
        if (t < 5) op1 = "a gardener, tending to his plants.";
        if (!itemKillLady) op2 = "a really old lady sitting on a bench.";
        op3 = "my favourite sitting spot.";
        if (t < 4 & !item2b1) op4 = "a street sweeper, cleaning the park avenue.";
        else if (t > 3) op4 = "a group of children chasing each other.";
        pm.UpdateOptions(op1, op2, op3, op4);
        pm.ShowPanel(str);
    }
    public void GotoAbocador()
    {
        Debug.Log("Going to ABOCADOR");
        place = 3;
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      ABOCADOR < 001 >
        str = "This town has always had this old dumpster full of junk. Piles of trash, car wheels, metal doors, and plastic. You can find almost anything in here if you search long enough, but almost no one comes here. That’s precisely why I figured this could be the perfect hiding place for the murderer.";
        if (hobo) str = str + "\nI thought I’d be alone, but apparently I’ve got some company. I spot the town’s hobo leaning against a broken car, probably drunk. I wondered if it wouldn’t be best to just ignore him.";
        str = str + "\nI decided to...";
        op1 = "...find the murderer’s hideout.";
        op2 = "...search for useful junk.";
        if (hobo) op3 = "...go talk to the hobo.";
        pm.UpdateOptions(op1, op2, op3);
        pm.UpdateText(str);
    }
    public void GotoAlmacen()
    {
        Debug.Log("Going to ALMACEN");
        place = 4;
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      ALMACEN < 001 >

    }
    public void GotoPizza()
    {
        Debug.Log("Going to PIZZA");
        place = 5;
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      PIZZA < 001 >

    }
    public void GotoAigua()
    {
        Debug.Log("Going to AIGUA");
        place = 6;
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      AIGUA < 001 >

    }
    public void GotoPasseig()                   
    {
        Debug.Log("Going to PASSEIG");
        place = 7;
        lastText = "001";       //      PASSEIG < 001 >
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
        if (t > 3)
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
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      ESCOLA < 001 >

    }

    public void GotoMapa()
    {
        Debug.Log("Going to MAPA");
        place = 0;
        ++t;
        if (t > 5) TimeTravel();
        pm.HidePanel();
    }


    // OPCIONES
    public void Option1()   //--------------------------------------------------------------------  1   ---
    {
        op1 = op2 = op3 = op4 = "";     // buida noms d'opcions
        Debug.Log("Option 1 - from: "+ lastText );
        switch (place)
        {
            case 1:                         //  >> CASA <<

                if (lastText == "001") Debug.Log("caca");
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 2:                         //  >> PARC <<
                if (lastText == "001" & !itemWater)
                {
                    lastText = "002";       // < 002 >
                    str = " a gardener, tending to his plants. I hold a deep respect for all gardeners, but, given the circumstances, I couldn’t help but mistrust him. After all, if you know how to keep a plant alive, you also know how best to kill it. I had to ask the question.\n“What’s your favourite flower?” I heard right then, interrupting my thoughts. I raised my head and saw the gardener smiling at me. There was a serene sadness in his eyes.";
                    op1 = "“Sunflowers”";
                    op2 = "“Su… Roses”";
                    op3 = "“Hey, that’s what I wanted to ask!”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "001" & itemWater)
                {
                    lastText = "006";       // < 006 >
                    str = "a gardener, tending to his plants, or at least trying to. At the moment, he was mostly looking at his empty water hose with a mourning face. \n“They cut the water”, he said sadly, as if he had just woken from a beautiful dream. “How am I supposed to water my plants now?”.";
                    op1 = "“I heard there was a problem at the water processing plant”.";
                    op2 = "“Cheer up, it should only last a few hours”.";
                    op3 = "“I like flowers”.";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "027")
                {
                    lastText = "027b";       //      PARC < 027b >
                    str = "Then they started talking about a new girl that had recently moved to town and was attending second grade.\nApparently, her mother was a new teacher at the school. They all seemed to like the new girl, but they complained that she was always seemed to be busy for some reason, and they almost never got a chance to play with her.\nAfter a while I got tired of their talk and went home.  ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "002")
                {
                    lastText = "003";       //      PARC < 003 >
                    itemFlowers = true;
                    str = "“Sunflowers,” I replied without hesitation. The gardener’s smile broadened, and he said, “yes, you do look like the sunflower type. Not many left around these days, huh?” he added with a mournful voice. \n“No, sadly not,” I agreed, wondering if I had given myself away too soon. The gardener looked at me once more with that rueful smile, and said “here, take these gardenias. A gift, from a fellow lover of flowers to another”.\nI thanked him and left, not knowing quite what to make of him.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "006")
                {
                    lastText = "007";       //      PARC < 007 >
                    str = "“I heard there was a problem at the water processing plant”. \nAs soon as I said those words, he looked up at me with a shine to his eyes. “Really? Well, we can’t allow that, can we? No, no, no. I will have to go there immediately. Oh, yes. They shall hear about this. What kind of water processing plant stops processing the water for my plants on such an important day? Oh, no, no, no, I will have none of that”.\nHe kept on muttering to himself as he stood up and left in direction to the water plant, but all I heard were some isolated words like “fire”, “massacre” and “thermonuclear punishment”. \nAfter he left, I noticed he had forgotten some recently cut flowers and a sandwich. ";
                    op1 = "I took both.";
                    op2 = "I took the sandwich";
                    op3 = "I took nothing.";
                    pm.UpdateOptions(op1,op2,op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "010";       //      PARC < 010 >
                    str = "Seemed like he wasn’t going to need them anyway, where he was going.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "014";       //      PARC < 014 >
                    str = "Approach him, but as soon as he noticed me he stopped talking abruptly and shot me a guilty glance. All I could overhear was ”my love”, “destroy” and “warehouse”, but that was enough. Why else would he be looking at me with such a look of guilt painted all over his face?";
                    op1 = "“You’re the sunflower murderer!”";
                    op2 = "“You, uhm... what were you talking about just now?”";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "014")
                {
                    lastText = "015";       //      PARC < 015 >
                    str = "“You’re the sunflower murderer!”, I screamed in a fit of rage, and then I tackled him. I don’t recall the exact details of what happened next. There might have been a moment when I bit his finger off? I hope it was an finger and not an ear, but, to be honest, it’s hard to tell. All I’m certain of is that he managed to escape at some point, and that I by the time I regained my wits I had an awful lot of blood on my t-shirt. Most of which was probably not mine. \nPerhaps I should hone my diplomacy skills a bit.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    lastText = "017";       //      PARC < 017 >
                    str = "“You’re right, I don’t wanna hear this”, I said, and I left. Humans are scary.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "018")
                {
                    lastText = "019";       //      PARC < 019 >
                    str = "“Sure you can,” I said, not really knowing what I was talking about. All of my love has and shall always be for my sunflower. \n“Yeah, but what would happen then?”, he countered. “The world would be ruined. Everything would be lost. No, I just cannot do it. I can’t. It hurts and it’s unfair, but I have to suck it up and do what’s right”.\n”Uh...  okay”, I answered, not really knowing what else to say. And he left. What am I supposed to make of that that? This case needs someone who actually understands people…";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "025";       //      PARC < 025 >
                    str = "“Err, I... no.”\n“Oh”, she said. “Oh. So who are you, then? Did you come for me at last, O Grim Reaper? Is that what this is? The time of my parting, the final curtain, the eternal rest finally embracing me in its soft arms, forever? Well, then, I am ready. Yes, I may have sinned, and not a little, but I regret nothing. Every ounce of joy, every inch of pleasure and rebellion I scraped out of this dull, gray world, it was all worth it. Mary Antoniette’s lips upon mine, and to hell with whatever they said. And her sister’s lips, later on. Ah, the orgies. The ecstasy. The bliss. Yes, it was all worth it. You may take me, O Death. Take me and do with this old body what you will, for my spirit has soared high as any other.”";
                    itemKillLady = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "025")
                {
                    lastText = "025b";       //      PARC < 025b >
                    str = "What was I supposed to do? I couldn’t just leave, not after that. I was left with no option but to give her what she was asking for. I tried to be gentle, but choking someone to death is never a walk in the park.\nOne way or another, though, in the end she got the rest she wanted.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "021")
                {
                    lastText = "021b";       //      PARC < 021b >
                    str = "“This… might help?”, I tried.\n“You really think so?”\n“Yes?” No.\n“Well, that’s beautiful. No one had ever given me flowers before. I… really, thanks. Maybe I should actually give love a try, you know. All my life I did what was expected of me as a member of a secret holy order, and what did I really get out of that? Yeah, saved the world a couple times, stopped one or two apocalypses. Well, that’s not the kind of thing that will warm me at night when I’m old, you know what I mean? No, I’ve had enough. I deserve this. I’ve got to think about myself, at least once in my life. Thank you, my friend, for showing me the way. I shall not forget this.”";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "021b")
                {
                    lastText = "021c";       //      PARC < 021c >
                    str = "And with these words he left. I didn’t really understand any of what he’d said, but hey, it’s not like I thought I would. I’m just a guy who randomly says “flowers”.";
                    itemLove = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 3:                         //  >> ABOCADOR <<

                if (lastText == "001") Debug.Log("caca");
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 4:                         //  >> MAGATZEM <<

                if (lastText == "001") Debug.Log("caca");
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 5:                         //  >> PIZZA <<

                if (lastText == "001") Debug.Log("caca");
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 6:                         //  >> AIGUA <<

                if (lastText == "001") Debug.Log("caca");
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 7:                         //  >> PASSEIG <<
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
                    if (t == 4)
                    {
                        lastText = "021";   //  < 021 >
                        str = "I left the main avenue feeling lost and lonely among the crowd of passers-by. It was getting dark already, and I had a sunflower to protect at home.";
                        pm.UpdateOptions(continueText);
                        pm.UpdateText(str);
                    }
                    else if (t == 5)
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
            case 8:                         //  >> ESCOLA <<
                if (lastText == "001") Debug.Log("caca");
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
    public void Option2()   //--------------------------------------------------------------------  2   ---
    {
        op1 = op2 = op3 = op4 = "";     // buida noms d'opcions
        Debug.Log("Option 2 - from: " + lastText);
        switch (place)
        {
            case 1:                         //  >> CASA <<

                break;
            case 2:                         //  >> PARC <<
                if (lastText == "001")
                {
                    lastText = "024";       //      PARC < 024 >
                    str = "a really old lady sitting in a bench, so peacefully. I went to sit next to her, and she seemed startled for a second until she squeezed her eyes and said, “Timothy? Is that you, dear?”";
                    op1 = "“Err, I... no.”";
                    op2 = "“Certainly.”";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "002")
                {
                    lastText = "004";       //      PARC < 004 >
                    itemFlowers = true;
                    str = "“Su… Roses,” I replied shrewdly. I wasn’t so dumb to reveal my true allegiances to a complete stranger just like that. What if he was the sunflower murderer?\n“Ah”, he said, looking somehow disappointed with my answer. “Well, I do have some roses, if you want them”. \nSeedless flowers hold no appeal to me, but I took the roses anyway, not wanting to give myself away.\nI was getting more and more uncomfortable with my charade, as if I had betrayed my pure devotion of sunflowers, so I thanked the gardener and walked away soon after that.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "006")
                {
                    lastText = "008";       //      PARC < 008 >
                    str = "“Cheer up, it will only last a few hours”, I said, trying to help. I wasn’t sure he was actually on my side, but he was nice to his flowers. \n“Yes”, he said absentmindedly. “Yes, I suppose you’re right”. \nAfter that he just sat there, waiting, and a while later I decided to leave. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "011";       //      PARC < 011 >
                    str = "I took the sandwich. What can I say? I was hungry, and it was a really good looking sandwich.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "022";       //      PARC < 022 >
                    str = "Leave him alone. We all need our privacy from time to time. Perhaps later would be a better time.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "014")
                {
                    lastText = "016";       //      PARC < 016 >
                    str = "“You, uhm... what were you talking about just now?”, I tried to ask as casually as I could. \nHe was still startled, but he looked at me and sighed. \n“I, uh… it’s complicated,” he said.";
                    op1 = "“You’re right, I don’t wanna hear this”.";
                    op2 = "“I have time”.";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    lastText = "018";       //      PARC < 018 >
                    str = "“I have time”.\n “Well… I, I don’t know you, but I don’t really have anyone else to talk with. I, uh... it’s a woman. I love her, I truly do... but to be with her, I would have to betray everything I believe in. And I can’t just do that, can I?”";
                    op1 = "“Sure you can”";
                    op2 = "“That’s right. You have a duty”";
                    if (itemFlowers) op3 = "Flowers";
                    pm.UpdateOptions(op1,op2,op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "018")
                {
                    lastText = "020";       //      PARC < 020 >
                    string s1, s2, s3, s4, s5 = "";
                    s1 = "“That’s right. You have a duty”, I said. He nodded to himself, seemingly absorbed in his own thoughts.";
                    s3 = "\n”Yeah”, he said at last";
                    s5 = ". “Yeah. You’re right. Thanks bro. I needed that”. He gave a small squeeze on my shoulder, and then he left.";
                    if (loop > 1)
                    {
                        s2 = "”Look at my case. Sometimes I don’t like being trapped in an endless time loop either, searching for a way to save my sunflower, you know? But it is what it is.";
                        s4 = ", although I wasn’t sure if he had really heard me";
                        str = s1 + s2 + s3 + s4 + s5;
                    }
                    else str = s1 + s3 + s5;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "026";       //      PARC < 026 >
                    str = "“Certainly.”\n“Oh, Timothy. Such a good lad, such a good lad. And so grown, too, as of late,” she added, squeezing her eyes again to see me better, unsuccesfully. I could now see that she was almost completely blind, but that didn’t stop her from gazing towards me with a look of deep affection in her face. We sat there in that bench for more than two hours, holding each other’s hands, saying almost nothing. \nWe didn’t need to.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                break;
            case 3:                         //  >> ABOCADOR <<

                break;
            case 4:                         //  >> MAGATZEM <<

                break;
            case 5:                         //  >> PIZZA <<

                break;
            case 6:                         //  >> AIGUA <<

                break;
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
            case 8:                         //  >> ESCOLA <<

                break;
            default:
                break;
        }
    }
    public void Option3()   //--------------------------------------------------------------------  3   ---
    {
        op1 = op2 = op3 = op4 = "";     // buida noms d'opcions
        Debug.Log("Option 3 - from: " + lastText);
        switch (place)
        {
            case 1:                         //  >> CASA <<

                break;
            case 2:                         //  >> PARC <<
                if (lastText == "001")
                {
                    lastText = "028";       //      PARC < 028 >
                    str = "my favourite sitting spot. \nAs I lay there, breathing slowly, drinking it all in, I could almost feel all my problems beginning to fade away. If only I could stay there forever, enjoying that nice breeze and thinking of nothing… \nBut I couldn’t. I still had a murderer to catch, and a sunflower to save.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "002")
                {
                    lastText = "005";       //      PARC < 005 >
                    str = "“Hey, that’s what I wanted to ask!” I protested. He had stolen my question! Would he steal my sunflower too?\nThe gardener laughed out loud, shook his head and kept on tending to the plants. \n“My favourite flowers are Fire Lilies”, he said after a while. “If most people had half their intensity, we would live in a much more interesting world”. Then he looked at me once more with that rueful smile, and said “here, take these gardenias. A gift, from a fellow lover of flowers to another”. I thanked him and left, not knowing quite what to make of him.";
                    itemFlowers = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "006")
                {
                    lastText = "009";       //      PARC < 009 >
                    str = "“I like flowers”, I said. \nHe looked up at me, his eyes still unfocused, and slowly he came back to his senses. \n“Yes… yes, me too. Here, you can have some, if you want”, he muttered. \nI thanked him and left, as he seemed ill-disposed at the moment.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "023";       //      PARC < 023 >
                    str = "Spy on him. He had the sign of the sunflower, after all. I had to get this. \nAs I approached, hiding through the bushes, I could clearly overhear his conversation. \n“Yes. Yes sir. No, I won’t let love get in the way, sir. I know we have to destroy it. Yes, it’s for the greater good. I’ll be at the warehouse on Roller Street in the afternoon, right after I finish my work here. Over.”Well, well. Seemed like I was finally getting somewhere. The old warehouse on Roller Street, this afternoon. I would have to take a look at that.";
                    infoWarehouse = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "018")
                {
                    lastText = "021";       //      PARC < 021 >
                    str = "“Flowers”, I said. \n “What?”, he asked, perplexed.\nTo be honest, I had never really intended to say anything. I just randomly mutter the word “flowers” from time to time, especially when I get nervous, ever since I can remember, just like other people get a hiccup. Well, me, I never get a hiccup. I just say “flowers”. \nBut since I was actually engaged on a mission of deception, I handed him the flowers I had obtained a while back from the gardener. Trouble was, he still looked at me as if expecting me to say something.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                break;
            case 3:                         //  >> ABOCADOR <<

                break;
            case 4:                         //  >> MAGATZEM <<

                break;
            case 5:                         //  >> PIZZA <<

                break;
            case 6:                         //  >> AIGUA <<

                break;
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
            case 8:                         //  >> ESCOLA <<

                break;
            default:
                break;
        }

    }
    public void Option4()    //--------------------------------------------------------------------  4   ---
    {
        op1 = op2 = op3 = op4 = "";     // buida noms d'opcions
        Debug.Log("Option 4 - from: " + lastText);
        switch (place)
        {
            case 1:                         //  >> CASA <<

                break;
            case 2:                         //  >> PARC <<
                if (lastText == "001" & t < 4)
                {
                    lastText = "013";       //      PARC < 013 >
                    string s1 = "a street sweeper, cleaning the park avenue. At the moment, he seemed to be talking very agitatedly with someone over the phone.";
                    string s2 = " A sudden realization hit me right then when I looked at him: his uniform showed the exact same sign I had found on that cap in the warehouse a while ago. The sign of the sunflower!";
                    string s3 = " I decided to…";
                    if (infoGorra) str = s1 + s2 + s3;
                    else str = s1 + s3;
                    op1 = "Approach him...";
                    op2 = "Leave him alone...";
                    if (infoGorra) op3 = "Spy on him...";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "001" & t > 3)
                {
                    lastText = "024";       //      PARC < 024 >
                    str = "a group of children chasing each other. They seemed so happy, there in the park, like they didn’t have a worry on this world.\nAs I approached and sat on a bench near the playground, some of them looked at me warily, but after a while they resumed their game.\nWhile sitting on the bench I could easily overhear their conversation, although most of it was of no interest to me, having nothing to do with sunflowers. Apparently, a substitute teacher named Martin had been expected at the school this morning, but in the end he had never showed up.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                break;
            case 3:                         //  >> ABOCADOR <<

                break;
            case 4:                         //  >> MAGATZEM <<

                break;
            case 5:                         //  >> PIZZA <<

                break;
            case 6:                         //  >> AIGUA <<

                break;
            case 7:                         //  >> PASSEIG <<

                break;
            case 8:                         //  >> ESCOLA <<

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
        t = 1;   // Torna a la fase 1

        hobo = Random.value > 0.5f; // Mou el hobo

        //Reseteja condicions temporals
        v7_001 = false;
    }
}
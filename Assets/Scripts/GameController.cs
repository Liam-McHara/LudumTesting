using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Variables de coneixement (permanents)
    public bool infoCrash, infoVistNena, infoGorra, infoWarehouse, infoLoop, infoNeighbour, infoSniper, infoEvilGirl, 
        infoFinalboss, infoFermat, infoHoboSandwich, infoAllergy, infoPoison, infoWeapon, infoGirlParents, infoSchoolNeighbour = false;

    // Condicions temporals (es resetejen a cada bucle)
    public bool item2b1, itemWater, itemFlowers, itemLove, itemKillLady = false;    // parc
    public bool itemBarricade, itemSandWich, itemCrowbar = false;      // abocador
    public bool v7_001, v7_009, itemDeadGirl, itemChocolate = false;     // passeig
    public bool itemFirstTimePizza, itemGun, v5a7, itemPoison, v1a3 = false;
    public bool itemSchoolKey = false;

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
        str = "I went home and made sure everything was all right. My flat is small, so, living there all alone, not much tends to happen on it. After watering my sunflower, I decided to...";
        op1 = "... write down all the clues I had found so far.";
        op2 = "... spy on my neighbour.";
        op3 = "... search for cameras or traps.";
        if (itemBarricade) op4 = "... build a barricade.";
        pm.UpdateOptions(op1,op2,op3,op4);
        pm.ShowPanel(str);
    }
    public void GotoParque()
    {
        Debug.Log("Going to PARQUE");
        place = 2;
        lastText = "001";       //      PARK < 001 >
        str = "I decided to take a stroll through the town’s park, thinking that perhaps it would help me clear my thoughts. It was almost silent there, except for the refreshing sound of the wind through the leaves. I liked the park even though it had no sunflowers - I had looked.\nAs I was walking around, I spotted...";
        op1 = op2 = op3 = op4 = "";
        if (t < 5) op1 = "... a gardener, tending to his plants.";
        if (!itemKillLady) op2 = "... a really old lady sitting on a bench.";
        op3 = "... my favourite sitting spot.";
        if (t < 4 & !item2b1) op4 = "... a street sweeper, cleaning the park avenue.";
        else if (t > 3) op4 = "... a group of children chasing each other.";
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
        pm.ShowPanel(str);
    }
    public void GotoAlmacen()
    {
        Debug.Log("Going to ALMACEN");
        place = 4;
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      ALMACEN < 001 >
        str = "I went to the abandoned warehouses on the lonely side of town looking for clues, and ";
        if (t == 1) str = str + "... saw the sunrise on metal, rust and broken glass, wild dusty bushes, ragged quiet. Then I...";
        else if (t == 2) str = str + "... saw the sun Then I...";
        else if (t == 3) str = str + "... saw the sun Then I...";
        else if (t == 4) str = str + "... saw the sun directing a haze of floating orange dust soaked light towards me. Then I...";
        else if (t == 5) str = str + "... saw the street lights buzzing with electric delight over the abandoned and empty streets. I walked through thick darkness broken by cones of yellow. I walked through the futility of it all. Then  I...";
        op1 = "... sat on a dusty old sofa.";
        op2 = "... looked around for clues.";
        op3 = "... fed some cats.";
        if (infoWarehouse) op4 = "... went to the Roller Street warehouse.";
        pm.UpdateOptions(op1, op2, op3, op4);
        pm.ShowPanel(str);
    }
    public void GotoPizza()
    {
        Debug.Log("Going to PIZZA");
        place = 5;
        op1 = op2 = op3 = op4 = "";
        lastText = "001";       //      PIZZA < 001 >
        if (!itemFirstTimePizza)
        {
            str = "Fermat pizza shop has been there forever. Some say it is a hole full of cockroaches, which is true. It is also the best pizza you can find in town. And the place to be to gather information and gossip.";
            itemFirstTimePizza = true;
        }
        else str = "I went back to the pizza place. It was hot in there.";
        pm.UpdateOptions(continueText);
        pm.ShowPanel(str);
    }
    public void GotoAigua()
    {
        Debug.Log("Going to AIGUA");
        place = 6;
        op1 = ">" ;
           op2 = op3 = op4 = "";
        lastText = "intro";       //      AIGUA < 001 >
        str = "I decided to visit our town’s water processing plant. After all, sunflowers need nothing but two things to live: sunshine and water. Since the sun was probably out of reach, I figured the murderer might try to make his move on my sunflower’s only other vulnerability - water.";
        pm.UpdateOptions(op1);
        pm.ShowPanel(str);
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
            str = "I came back to the Avenue. I could feel there was something left for me to do there. As soon as I got there, I headed to...";
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
        str = "I strolled towards the school, an old brick building surrounded by a tall black iron fence.\nOne is never too old to learn, right? As I got closer I realized how good it felt knowing I was free to walk away whenever I wanted. Upon arriving, I...";
        op1 = "...walked up to the main entrance...";
        if (t<3) op2 = "...talked with some adults at the gate...";
        if (t==3) op3 = "... saw my neighbour talking with a young schoolgirl!";
        pm.UpdateOptions(op1, op2, op3);
        pm.ShowPanel(str);
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
                if (lastText == "001")
                {
                    lastText = "002";       //      HOME < 002 >
                    str = "... write down all the clues I had found so far, to get a clearer picture of my progress.";
                    if (infoGorra) str += " - I found a cap on some bushes next to the warehouses. It had a sign resembling a sunflower.\n";
                    if (infoWarehouse) str += " - I overheard the street sweeper talking over the phone about a warehouse on Roller Street.\n";
                    if (infoHoboSandwich) str += " - I gave a sandwich to the hobo, which he ate.\n";
                    if (infoCrash) str += " - I saw a car crashing against the mailbox in the main avenue on the afternoon.\n";
                    if (infoVistNena) str += " - I saw a little girl playing around the main avenue on the afternoon and evening.\n";
                    if (infoFermat) str += " - I saw Fermat looking away as I said ''sunflower''. He is hiding something!\n";
                    if (infoEvilGirl) str += " - I infiltrated the school and read the little girl’s notebook. She’s the actual mastermind behind the murder of my sunflower.\n";
                    if (infoNeighbour) str += " - I found out my neighbour is part of the complot. She will abseil down and immolate herself and the sunflower at midnight unless I stop her!\n";
                    if (infoLoop) str += " - Crazy as it sounds, I think I’m trapped in a time loop, reliving the same 24 hours over and over.\n";
                    if (infoAllergy) str += " - I saw my neighbour having an allergy attack because of some flowers. She and the street sweeper are lovers!\n";
                    if (infoSniper) str += " - A sniper is going to shoot my sunflower if I don’t stop it!\n";
                    if (infoPoison) str += " - Someone is going to poison my plant if I don’t stop it!\n";
                    if (infoWeapon) str += " - The sniper’s weapon is hidden in the warehouse!\n";
                    if (infoFinalboss) str += " - Even after I managed to dismantle all the her other plans, the Destroyer of Suns came herself to my flat at midnight, and murdered the sunflower. If only I found out her identity...\n";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "003")
                {
                    lastText = "004";       //      HOME < 004 >
                    str = "... knocked on her door. ";
                    if (t == 1 | t == 3 | t == 4) str += "She didn’t answer. I guess she wasn’t at home? I should try again later.";
                    else
                    {
                        if (!itemLove) str += "She opened it.\n''Hey, neighbour, it’s you'' she said, eyeing me suspiciously. ''Did you need anything in particular?''\nThe memories of her, dressed only with dynamite and abseiling down my flat, rushed into my mind. I won’t deny I got a tad nervous, and probably gave myself away by saying ''Eh...um... Hello! Where did you learn how to abseil?'' To which she answered \n''I’m a firefighter''\nThat was more that I could handle and rushed back home to the sweet solace of my sunflower.";
                        if (!v1a3)
                        {
                            str += ")She opened it.\n''Hey, it’s you!'' She said.\n''Err...um... Hello!'' I replied, not really knowing what to say ''Soo, what is that you do with your life?'' To which she answered \n''I’m a firefighter''\n That was more that I could handle and rushed back home to the solace of my sunflower.";
                            v1a3 = true;
                        }
                    }
                   
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "007") TimeTravel();    //  [NEXT LOOP]

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
                    op2 = "“Su... Roses”";
                    op3 = "“Hey, that’s what I wanted to ask!”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "001" & itemWater)
                {
                    lastText = "006";       // < 006 >
                    str = "... a gardener, tending to his plants, or at least trying to. At the moment, he was mostly looking at his empty water hose with a mourning face. \n“They cut the water”, he said sadly, as if he had just woken from a beautiful dream. “How am I supposed to water my plants now?”.";
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
                    lastText = "006b";       //      PARC < 007 >
                    str = "“I heard there was a problem at the water processing plant”. \nAs soon as I said those words, he looked up at me with a shine to his eyes. “Really? Well, we can’t allow that, can we? No, no, no. I will have to go there immediately. Oh, yes. They shall hear about this. What kind of water processing plant stops processing the water for my plants on such an important day? Oh, no, no, no, I will have none of that”.\n";
                    op1 = "I took both.";
                    op2 = "I took the sandwich";
                    op3 = "I took nothing.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "006b")
                {
                    lastText = "007";       //      PARC < 007b >
                    str = "“He kept on muttering to himself as he stood up and left in direction to the water plant, but all I heard were some isolated words like “fire”, “massacre” and “thermonuclear punishment”. \nAfter he left, I noticed he had forgotten some recently cut flowers and a sandwich. ";
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
                    str = "“Sure you can,” I said, not really knowing what I was talking about. All of my love has and shall always be for my sunflower. \n“Yeah, but what would happen then?”, he countered. “The world would be ruined. Everything would be lost. No, I just cannot do it. I can’t. It hurts and it’s unfair, but I have to suck it up and do what’s right”.\n”Uh...  okay”, I answered, not really knowing what else to say. And he left. What am I supposed to make of that that? This case needs someone who actually understands people...";
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
                    str = "“This... might help?”, I tried.\n“You really think so?”\n“Yes?” No.\n“Well, that’s beautiful. No one had ever given me flowers before. I... really, thanks. Maybe I should actually give love a try, you know. All my life I did what was expected of me as a member of a secret holy order, and what did I really get out of that? Yeah, saved the world a couple times, stopped one or two apocalypses. Well, that’s not the kind of thing that will warm me at night when I’m old, you know what I mean? No, I’ve had enough. I deserve this. I’ve got to think about myself, at least once in my life. Thank you, my friend, for showing me the way. I shall not forget this.”";
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

                if (lastText == "001")
                {
                    lastText = "002";       //      ABOCADOR < 002 >
                    str = "... find the murderer’s hideout. \nThe dumpster was quite big, but I had plenty of time. After hours of searching, I found a cat feeding her kittens, a wild raccoon, and two scorpions. I found a nest of mockingbirds. I found a pair of socks which seemed quite warm and comfortable, too. But no hideout. In the end, I had no option but to face the truth and go home. The murderer simply wasn’t here.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "003")
                {
                    lastText = "004";       //      ABOCADOR < 004 >
                    str = "... a neat pile of wooden planks, along with some tools. Nails, a hammer, etc. They could be useful to barricade my house. Or to build anything I needed in my quest, so I decided to take them with me.";
                    itemBarricade = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "008";       //      ABOCADOR < 008 >
                    str = "I kept listening to him.\n“Yes! it is the new ...mumblemumble ... loophole...the most efficient arrangement ... mumblemubmle.. quantum entanglement ...r(n) = √n  ... the Golden Angle ... φ = (1+√5)/2.. mimb... it is the only... 137,5°....the sunflower... AHHH! ike ike, one of a hundred ...mumblemumble... the Day finally has come...  the order of... mumble... fermat mumblmubmle ...the golden spiral... mumblemumb  how many times... need to find mumble... ”";
                    op1 = "“Hey, hold on! What did you say about sunflowers?”";
                    op2 = "“Hey, hold on! What was that loophole thing about?”";
                    if (itemSandWich) op3 = "Hey, dude! Fancy a sandwich?";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "009";       //      ABOCADOR < 009 >
                    str = "“Hey, hold on! What did you say about sunflowers?” I asked without much hope. Surprisingly, he stopped his nonsense and kept silent for much longer than I thought possible. Not only he was silent. Everything was still.";
                    op1 = "I kept listening.";
                    op2 = "I went home.";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "018";       //      ABOCADOR < 018 >
                    str = "“Hey dude! fancy a sandwich?” I handed him the sandwich. He ate it without a comment. After finishing it he took a sip of beer, eructed, and kept on mumbling. I decided to go home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "009")
                {
                    lastText = "009b";       //      ABOCADOR < 009b >
                    str = "Suddenly, I started hearing the voices once again. “Am I going crazy?” I thought. \n\n”...”\n\n “I must be dreaming all of this.”\n\n”...”\n\nMuch to my relief, I came back to reality when he suddenly spat out:\n“Sunflower.”\n“One of a hundred.”";
                    op1 = "I kept listening.";
                    op2 = "I went home.";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "009b")
                {
                    lastText = "010";       //      ABOCADOR < 010 >
                    str = "I kept listening, and he started vomiting words all over, shouting and moving his arms around. \n“will come the time and surely this time has come and past and come AGAIN till it passes away if only no one would PASS AWAY, y’know??\nplay would stop reap shot poison bomb the one we could keep doin keep gofin, keep moving forward! y'know? save it if you can save it yourself and don't waste my time, hey dude don’t waste my time, yesterday is gone tomorrow won't come just shut up SHUT UP and bend low bend down!!”";
                    op1 = "I kept listening.";
                 
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "010")
                {
                    lastText = "011";       //      ABOCADOR < 011 >
                    str = "He sat silent, eyes closed. I bent down and closed my eyes as well. Completely alienated from the world of cars and  pedestrians passing by, I thought of my sunflower. That pacified my mind. Pacified my mind. Pacified my mind. When I opened my eyes again I found some ugly letters carved in the pavement. They read:\nTo save the sunflower you must\nControl the water\nStop war\nSteal the food\nMake love stay\nDrink the poison\nThe hobo looked at me with sparkly eyes. “I made up the last one, so don’t take it so seriously haha” He explained proudly, grinning his rotten teeth at me. “Want some?” And he offered me a glass bottle reeking of alcohol.";
                    op1 = "“Sure.”";
                    op2 = "”I’ll pass this time.”";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "011")
                {
                    lastText = "012";       //      ABOCADOR < 012 >
                    str = "“Sure” I said, accepting the booze and taking a long gulp. “Y’now” He said eventually “I wouldn't like to be in your position, much responsibility. Anyway, no hurry eh, me I just chillin man, just take it easy. Take your time. It is not like we are going anywhere.” He told me. For once I forgot about it all.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "014")
                {
                    lastText = "016";       //      ABOCADOR < 016 >
                    str = "”Isn’t that your marker?” I asked\n”Well, that’s a really common marker,” he replied before falling soundly asleep. I went home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "012") TimeTravel();   //  [ END LOOP ]
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 4:                         //  >> MAGATZEM <<
                if (lastText == "001")
                {
                    if (t == 5)
                    {
                        lastText = "002";       //  Abocador < 002 >
                        str = "... sat on this dusty old sofa and did nothing till the moon peeked through the clouds.\nThe world seemed to be turning just fine.";
                    }
                    if (t != 5)
                    {
                        lastText = "002";
                        str = "... sat on this dusty old sofa and did nothing for a while til the shadows moved.//\nThe world seemed to be turning just fine.";
                    }

                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                
                else if (lastText == "006")
                {
                    lastText = "007";       //  WH< 007 >
                    str = "I walked in and stumbled upon the street sweeper.  The room was big and empty, and he was holding a gun!\n";
                    op1 = "“Holy sunflowers! I hope you’re not gonna kill me with that...”";
                    op2 = "“Uhm... I was just casually passing by...”";
                    op3 = "“You’re the sunflower murderer!”";
                    op4 = "“Yes! I knew something smelled fishy...”";

                    infoWeapon = true;
                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "008";       // wh < 008 >
                    str = "“Holly sunflowers, I hope you are not going to kill me with that!” I cried. He cried back.\n“Will you just chill down a second?I'm not killing anyone”\n";
                    op1 = "What are you doing here?";
                    op2 = "Why don’t you give me that weapon?";
                    op3 = "What are you going to do with that?";
                    op4 = "There must be a way I could open this door before this guy gets here";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "009";       // WH < 09 >
                    str = "“What are you doing here?” I asked the guy.";
                    op1 = "Are you dealing with weapons?.";
                    op2 = "Are you planning to kill my neighbour?.";
                    op3 = "Are you planning to kill my plant?";
                    op4 = "I trust you won't do anything stupid";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }
                else if (lastText == "009")
                {
                    lastText = "010";       // WH  < 10 >
                    str = "''Are you dealing with weapons?'' I guessed stupidly. His face relaxed and he giggled in relief.\n''Of course I'm not. I don’t like weapons myself. I’m here to destroy it and fulfill my sacred duty within the Order and the Sunflower. There’s no need to worry, my brother. The sunflower is safe, now. You should go home and be with who you love most.'' He said, tears in his eyes. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "020")
                {
                    lastText = "009";       // WH < 21 >
                    str = "I rushed in and stumbled upon him.";
                    op1 = "Are you dealing with weapons?";
                    op2 = "Are you planning to kill my neighbour?";
                    op3 = "Are you planning to kill my plant?";
                    op4 = "I trust you won't do anything stupid";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "023";       //  WH<023 >
                    str = "I kept looking for a few more sweaty minutes. Eventually the guy managed to start a fire and destroy whatever artifact he had been holding. I left before he could stumble upon me by the door, feeling quite unsure about what exactly had happened there.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                else if (lastText == "024")
                {
                    lastText = "025";       //  < 25 >
                    str = "... got the hell out of there before someone came and got the wrong idea.";

                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                else if (lastText == "005")
                {
                    lastText = "028";       //  < 028 >
                    str = "I tried to open it by pushing against it, but the door was locked solid. There was nothing I could do here without better tools.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 5:                         //  >> PIZZA <<
                if (lastText == "001" & !itemSandWich)
                {
                    lastText = "002";       //      PIZZA < 002 >
                    str = "Once I got there, I...";
                    op1 = "...went to get some pizza...";
                    op2 = "...went to the toilet...";
                    if (hobo) op3 = "...approached the hobo sitting on the sidewalk next door...";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "001" & itemSandWich)
                {
                    lastText = "003";       //      PIZZA < 003 >
                    str = "Once I got there, I...";
                    op1 = "...went to look for some pizza behind the counter...";
                    op2 = "...went to the toilet...";
                    if (hobo) op3 = "...approached the hobo sitting on the sidewalk next door...";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "003" | (!itemSandWich & (lastText == "018" | lastText == "020")))
                {
                    lastText = "004";       //      PIZZA < 004 >
                    str = "... went to look for some pizza behind the counter. In one of the cupboards I found a very suspicious bottle. I grabbed it and...";
                    op1 = "drank it...";
                    op2 = "... read the label...";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "002" | (!itemSandWich & (lastText == "017" | lastText == "019")))
                {
                    lastText = "007";       //      PIZZA < 007 >
                    str = "... went to get some pizza. I approached Fermat, who was sitting behind the counter, looking gloomy. ''I’d like some pizza'' I said. \n''Sure thing! What would you like in your pizza?'' he replied, fast and professional.";
                    if (!v5a7) op1 = "''The same as always, you know me.''";
                    v5a7 = true;
                    op2 = "''I would like something new, daring, fresh.''";
                    op3 = "''That’d be pepperoni, tomato, rucula... and sunflower.''";
                    op4 = "''Don’t you ever clean the toilet?''";
                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "008";       //      PIZZA < 008 >
                    str = "''The same as always, you know me''.\n''I don’t. Have we ever met before?'', he answered, sticking his head out and staring at me.";
                    op1 = "''... Yes, I’ve come here twice a week for the past 10 years...''";
                    op2 = "''Yes, I’m the guy with the sunflower.''";
                    op3 = "''Yes, and you should really clean your toilet.''";
                    op4 = "''Are you serious? Come on! It’s me.''";
                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "009";       //      PIZZA < 009 >
                    str = "Yes, I’ve come here twice a week for the past 10 years.''\n''I couldn't tell'' he shrugged ''there’s a lot of people passing by. What would you like in your pizza?''";
                    op1 = "“I would like something new, daring, fresh.”";
                    op2 = "“That’d be pepperoni, tomato, rucula... and sunflower.”";
                    op3 = "“Don’t you ever clean the toilet?”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "009" | lastText == "012")
                {
                    lastText = "013";       //      PIZZA < 013 >
                    str = "''I would like something new, daring, fresh.''\n ''All we have is pizza.'";
                    op1 = "''That’d be pepperoni, tomato, rucula... and sunflower.''";
                    op2 = "''Don’t you ever clean the toilet?''";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "014";       //      PIZZA < 014 >
                    str = "''That’d be pepperoni, tomato, rucula... and sunflower'' I added, hoping to catch him off guard.\n ''Umm, ehh... we, we don’t have any of that,'' he mumbled, looking down. He had to be hiding something there! ''And now, now get out of here, the restaurant is too full!''";
                    infoFermat = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "003")
                {
                    lastText = "021";       //      PIZZA < 021 >
                    str = "...approached the hobo sitting on the sidewalk next door. \nI figured that since he often spent the whole day sitting in the middle of the street, drugged on God knows what, he would know better than anyone what was going on inside the human soul, and thus could help me uncover the murderer. I sat next to him, but he didn’t seem to notice me. He was mumbling something to himself and making strange drawings on the pavement. On a second thought, he was probably just nuts.";
                    op1 = "I kept listening to him.";
                   
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "021")
                {
                    lastText = "022";       //      PIZZA < 022 >
                    str = "I kept listening to him.\n“Yes! it is the new ...mumblemumble ... loophole...the most efficient arrangement ... mumblemubmle.. quantum entanglement ...r(n) = √n  ... the Golden Angle ... φ = (1+√5)/2.. mimb... it is the only... 137,5°....the sunflower... AHHH! ike ike, one of a hundred ...mumblemumble... the Day finally has come...  the order of... mumble... fermat mumblmubmle ...the golden spiral... mumblemumb  how many times... need to find mumble... ”";
                    op1 = "“Hey, hold on! What did you say about sunflowers?”";
                    op2 = "“Hey, hold on! What was that loophole thing about?”";
                    if (itemSandWich) op3 = "Hey, dude! Fancy a sandwich?";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "023";       //      PIZZA < 023 >
                    str = "''Hey, hold on! What did you say about sunflowers?'' I asked without much hope. Surprisingly, he stopped his nonsense and kept silent for much longer than I thought possible. Not only he was silent. Everything was still.\n Suddenly, I started hearing the voices once again. ''Am I going crazy?'' I thought. \n\n''...''\n\n ''I must be dreaming all of this.''\n\n''...''\n\nMuch to my relief, I came back to reality when he suddenly spat out:\n''Sunflower.''\n''One of a hundred.''";
                    op1 = "I kept listening.";
                   
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "023")
                {
                    lastText = "024";       //      PIZZA < 024 >
                    str = "I kept listening, and he started vomiting words all over, shouting and moving his arms around. \n''will come the time and surely this time has come and past and come AGAIN till it passes away if only no one would PASS AWAY, y’know??\nplay would stop reap shot poison bomb the one we could keep doin keep gofin, keep moving forward! y'know? save it if you can save it yourself and don't waste my time, hey dude don’t waste my time, yesterday is gone tomorrow won't come just shut up SHUT UP and bend low bend down!!''";
                    op1 = "I bend down.";
                    
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "025";       //      PIZZA < 025 >
                    str = "He sat silent, eyes closed. I bent down and closed my eyes as well. Completely alienated from the world of cars and  pedestrians passing by, I thought of my sunflower. That pacified my mind. Pacified my mind. Pacified my mind. When I opened my eyes again I found some ugly letters carved in the pavement. They read:\nTo save the sunflower you must\nControl the water\nStop war\nSteal the food\nMake love stay\nDrink the poison\nThe hobo looked at me with sparkly eyes. ''I made up the last one, so don’t take it so seriously haha'' He explained proudly, grinning his rotten teeth at me. ''Want some?'' And he offered me a glass bottle reeking of alcohol.";
                    op1 = "''Sure.''";
                    op2 = "''I’ll pass this time.''";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "025")
                {
                    lastText = "026";       //      PIZZA < 026 >
                    str = "''Sure'' I said, accepting the booze and taking a long gulp. ''Y’now'' He said eventually ''I wouldn't like to be in your position, much responsibility. Anyway, no hurry eh, me I just chillin man, just take it easy. Take your time. It is not like we are going anywhere.'' He told me. For once I forgot about it all.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "026") TimeTravel();   //  [ END LOOP ]
                else if (lastText == "028")
                {
                    lastText = "029";       //      PIZZA < 029 >
                    str = "''Isn’t that your bed?'' I asked.\n''Yes indeed! The pictograms appeared in my bed this morning. A time traveler must have made them,'' he replied before falling soundly asleep. I went home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    str = "cleaning it, but instead I...";
                    if (itemSandWich)
                    {
                        lastText = "018";       //      PIZZA < 018 >
                        op1 = "... went back to look for some pizza behind the counter.";
                    }
                    else
                    {
                        lastText = "017";       //      PIZZA < 017 >
                        op1 = "... went to get some pizza.";
                    }
                    pm.UpdateOptions(op1);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "005";       //      PIZZA < 005 >
                    str = "drank it. \nIt tasted like death.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "005") TimeTravel();   //  [END OF LOOP]
                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 6:                         //  >> AIGUA <<



                if (lastText == "001" & !itemDeadGirl)
                {
                    lastText = "002";       //      AIGUA < 002 >
                    str = "infiltrate the plant through the public entrance! Full of bravery and determination, I nonchalantly strolled towards the gate of the public gate. My plan consisted on passing the barrier with casual confidence, as if I knew exactly what I was doing and it was the most natural thing on this world. \nMy plan failed miserably.\nAs soon as I reached the gate, a security guard yelled for me to stop. ''Sir, I will need a valid ID, government entry authorization, and reason of your visit!''. \n''I, err...'' I... ";
                    op1 = "Fought.";
                    op2 = "Fled.";
                    op3 = "... tried to talk my way in.";
                    pm.UpdateOptions(op1,op2,op3);
                    pm.UpdateText(str);
                }
                else if(lastText== "intro")
            {
                lastText = "001";      //AIGUA intro segona part
                
                str="The water processing plant formed a massive, heavily guarded structure, surrounded in its entirety by a spiked fence and security cameras.It had a public entrance for visitors, and a private, PIN-protected entrance for the employees. \nAfter a brief survey of the area, I was gripped with a doubtless certainty in regards to my upcoming plan.I would...";

                op1 = "... infiltrate the plant through the public entrance!";
                op2 = "... infiltrate the plant through the private entrance!";
                op3 = "... explore the outside of the water processing plant.";   
                pm.UpdateOptions(op1, op2, op3);
                pm.UpdateText(str);

            }
                else if (lastText == "002")
                {
                    lastText = "003";       //      AIGUA < 003 >
                    str = "... fought. What else was I going to do? If I had to go, I would go out it with a bang.\nUpon hearing his words, I dashed towards the barrier in an impressive sprint, expecting to be torn to pieces by heavy artillery at any moment. \nFortunately, reality wasn’t so dazzling. Rather than being shot down on sight, the security guard - who was a bit past his fifties, and packed a few extra pounds - managed to run me down and handcuff me. I received a sizable fine for resistance to authority, but was left otherwise unscathed at the door of my home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "005")
                {
                    lastText = "006";       //      AIGUA < 006 >
                    str = "''Certainly, sir!'', I replied with confidence. ''(541) 754-3010, lack of entry authorization due to jackal assault, and my visit is due to mandatory inspection of the facilities by member of licensed traveling circus''.\n''Finally. Five-four-one-s... wait, that’s a mobile phone number. Hold on, jackal what? Jim!'' he shouted through an intercom after dialing a number on a pad. ''Jim, we’ve got one of those. No, not the dangerous kind. Yep, just... disturbed. Be gentle, if you can''.\nI then received an invitation to leave the facilities, which I graciously accepted.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "008b";       //      AIGUA < 008b >
                    str = "''Really?'' he asked stupidly, and I could see the corners of his eyes beginning to water. ''I try to be a good father, of course, but I have to work so much... I never knew she valued... I never thought she... well, this is quite a surprise, sir'' he babbled a while before stopping, speechless.";
                    op1 = "''Yes, yes, she loves you dearly. Now, if I may...''";
                    pm.UpdateOptions(op1);
                    pm.UpdateText(str);
                }
                else if (lastText == "008b")
                {
                    lastText = "009";       //      AIGUA < 009 >
                    str = "''Yes, yes, she loves you dearly. Now, if I may go in for a minute...'' I said as I casually strolled towards the barrier.\n''Ah, no. I’m afraid that’s impossible. I understand you’re a good friend of my daughter, but I have strict orders to stop anyone trying to enter the facility without proper authorization. I’m so sorry, but there’s nothing I can do.''\nI decided not to tempt my luck any longer. Seems like I would have to find a more... impactful way to get rid of the girl’s father...";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "015" | lastText == "013")
                {
                    lastText = "016";       //      AIGUA < 016 >
                    str = "''Onwards, to destiny!'' I told myself as I finally entered the water processing plant. Near the entrance I found a closet with some worker clothes, so I put them on to better disguise myself. I crossed a couple employees, but they didn’t take a second glance at me. Now, if I were the sunflower murderer, where would I go?";
                    op1 = "The repository...";
                    op2 = "The treatment plant...";
                    op3 = "The control room...";
                    pm.UpdateOptions(op1,op2,op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    lastText = "017";       //      AIGUA < 017 >
                    str = "The repository was a huge storage room full with all the tools and materials needed for the proper functioning of the water processing plant. It was kind of boring, but at least I took the chance to pick up a crowbar I saw lying around. You never know when one of those will come in handy.\nAfterwards, I headed to...";
                    op1 = "The control room. ";
                    itemCrowbar = true;
                    pm.UpdateOptions(op1);
                    pm.UpdateText(str);
                }
                else if (lastText == "017" | lastText == "018")
                {
                    lastText = "019";       //      AIGUA < 019 >
                    str = "The control room was a big cubicle at the end of a long corridor, full of screens and beeping sounds and serious looking people doing serious looking things and bustling about. It didn’t really look like the kind of place where one could find a sunflower murderer, but what I did find was a big red button with the label “EMERGENCY STOP OF ALL WATER OPERATIONS”. I...";
                    op1 = "... pushed it.";
                    op2 = "didn’t push... nah, just kidding. Of course I pushed it.";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "019")
                {
                    lastText = "020";       //      AIGUA < 020 >
                    str = "... pushed it. The moment I did, a loud emergency alarm got activated, red lights started flashing all over the water treatment plant, and the serious looking people started looking less serious and more panicky. It didn’t seem like they would be too happy about me pushing their button, so I took the chaos and confusion as my cue to disappear from the water treatment plant before they checked their video feed recordings.";
                    itemWater = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "011")
                {
                    lastText = "012";       //      AIGUA < 012 >
                    str = "What had given me such ideas to begin with? The murderer was probably as clueless as I was. In fact, he might be standing around the water processing plant at this very moment, just like I was, failing to find a way to enter, just like I had. If anything, I had a higher chance of finding the murderer by continuing to wander aimlessly around the plant, as I had been doing for the last forty minutes!\nAfter two more hours like that, I left.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "007b";       //      AIGUA < 007b >
                    str = "The guard started dialing a number on a pad even before I could finished my sentence. ''Jim, we’ve got one of those,'' he shouted through an intercom. ''No, not the dangerous kind. Yep, just... disturbed. Be gentle, if you can''.\nI then received an invitation to leave the facilities, which I graciously accepted. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
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
                    str = "... a suspicious alleway. If I was a murderer of sunflowers, that’s clearly the kind of place where I would hide to plot my evil plans. \nThe alleway was empty except for a dirty dog and some broken bottles. I was about to leave when I heard a mysterious voice that seemed to come from nowhere in particular. \n“Pssst, you! Yeah, you! Do you know how many times the sun rose today?”";
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
                    str = "“I’d say you’re just an idiot hiding under a sewer door...” I replied, losing my temper. \n“Brother, you’re not really angry with me, but with yourself. Sunflowers, grant patience to this lost lamb. He’ll be back once he’s ready to hear the Truth”.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008") GotoMapa(); //  [ RETURN ]
                else if (lastText == "009")
                {
                    lastText = "010";       //  < 010 >
                    str = " “No... I’m just looking for someone, although I don’t really know who,” I answered feeling a bit down.\n“Oh, that seems tricky,” she said, and then her face lit up. “You know what? Maybe I can help you find this person!” she said brightly.";
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
                    str = "... his favourite chocolate. “Ahhh, hard to say, hard to say...” he muttered to himself, before finally handing me a bar of 80% homemade organic chocolate. \nI paid in cash and asked if he had seen anyone who looked like they might hate sunflowers, but the shopkeeper just stared blankly at me, so I left.";
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
                if (lastText == "001" & t <= 3)
                {
                    lastText = "002";       //      ESCOLA < 002 >
                    if (t == 3)
                    {
                        str = "walked up to the main entrance. There was a strong flow of kids running, yelling, jumping, fighting and rejoicing in their freedom as they went out the door. I tried to oppose the current but I was swept by it.";
                        pm.UpdateOptions(continueText);
                    }
                    else
                    {
                        str = "walked up to the main entrance.\nAs I went in, a woman welcomed me.  ''Good morning, sir. May I help you?'' It was obvious she expected some kind of comment about my visit.";
                        op1 = "Is it too late for me to sign in?";
                        op2 = "Have you seen anyone suspicious around the school lately?";
                        if (infoNeighbour) op3 = "Let me in, there’s a murderer inside the school!";
                        pm.UpdateOptions(op1, op2, op3);
                    }

                    pm.UpdateText(str);
                }
                else if (lastText == "002" & t == 3) GotoMapa();
                else if (lastText == "001" & t > 3)
                {
                    lastText = "004";       //      ESCOLA < 004 >
                    str = "walked up to the main entrance, but it was closed. A timetable said the school was open every weekday from dawn till noon.";
                    if (!itemSchoolKey)
                    {
                        str += "I had arrived too late.";
                        pm.UpdateOptions(continueText);
                    }
                    else
                    {
                        str += "I fished the school keys I had stolen that morning out of my pocket, and slowly opened the iron gates of the school. They made an ominous metal sound, and, just like that, I was inside. \nI finally had all the time in the world to uncover the secrets of the school - and Miss Summers. As soon as I was inside, I…";
                        op1 = "Headed back to the teacher’s room…";
                        op2 = "Tried to find my kin tribe again…";
                        op3 = "Started walking randomly.";
                        pm.UpdateOptions(op1, op2, op3);
                    }
                    pm.UpdateText(str);
                }
                else if (lastText == "004" & t > 3 & !itemSchoolKey) GotoMapa();
                else if (lastText == "005" & (!infoGirlParents | !infoSchoolNeighbour)) GotoMapa();
                else if (lastText == "002")
                {
                    lastText = "009";       //      ESCOLA < 009 >
                    str = "''Is it too late for me to sign in?'' I asked, feeling suddenly encouraged to resume my learning by the yells and shouts of schoolchildren, and the general mayhem of the school. After all, if these children managed to learn something despite having been immersed in such conditions almost since their birth and against their own will, then it couldn’t be so hard for me, right? \n Apparently, the school concierge disagreed.\n''Well… with all respect, I would say there are other learning centers that would prove more, uh, more appropriate for your… current age'', she answered. \nAh, the outrage, the shame. They say knowledge is the greatest gift, and to have it denied just like that, without even an apology. I had to go home and think about this.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "010")
                {
                    lastText = "011";       //      ESCOLA < 011 >
                    str = "I ran away. What had I been thinking, coming back here? After everything I’d suffered in this cage, after everything I had been through, had I somehow managed to forgot how utterly stupid and unforgiving adults actually are? While fleeing, the words ''run away, Simba. Run. Run away and never return'' kept echoing on my head, and they didn’t stop until I had been safely tucked under my own bed for over twenty minutes. Yikes.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "029";       //      ESCOLA < 029 >
                    str = "headed back to the teacher’s room. I believed this time, with no reason to hurry up, I might be able to find some clues related to Miss Summers. \nThe teacher’s room was barricaded against nocturnal children and beasts, but I managed to squeeze in through a loose plank.\nMiss Summer’s documents seemed perfectly normal. She looked like a regular teacher - stern and devoted to her work, yes, but not insane. Why did I still have this hunch, then, that I was getting closer and closer to the truth?";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "029")
                {
                    lastText = "032";       //      ESCOLA < 032 >
                    str = "I closed my eyes, trying to focus on the problem, to find the missing piece on this puzzle. And then I knew. Perhaps I had known all along, but I had been to stubborn to accept it. It was too far-fetched. Too monstruous. But it was the only option. \nStill, I had to see it by myself. I needed proof. \nI had to reach classroom 2B. I headed out of the teacher’s room and…";
                    op1 = "Went upstairs to the second floor.";
                    op2 = "Turn left before the fire exit. ";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "032")
                {
                    lastText = "033";       //      ESCOLA < 033 >
                    str = "Went upstairs to the second floor. Then I…";
                    op1 = "Turned left near the broom closet... ";
                    op2 = "Turned right near the cafeteria...";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "033")
                {
                    lastText = "035";       //      ESCOLA < 035 >
                    str = "Turned left near the broom closet, and realized I was lost.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "036")
                {
                    lastText = "039";       //      ESCOLA < 039 >
                    str = "039 Went down one floor and realized I was lost.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "040")
                {
                    lastText = "041";       //      ESCOLA < 041 >
                    str = "It was her. It had always been her. Inside the false bottom of Valentine Summers’ desk I found all her secret plans and schematics, her musings and calculations. She had planned everything, accounted for every setback. What kind of twisted, brilliant mind lay hidden inside that innocent-looking eight year old girl? I couldn’t follow her entire lines of thought, as there were too many ramifications and leaps of logic for me, but on those childish notebook pages I saw equations of M-theory and quantum physics that many accomplished theoretical physicists would have killed to read. During the following hours I understood everything, including why she wanted to murder my sunflower. Perhaps the simplest explanation was found on this old entry of her diary:";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "041")
                {
                    lastText = "042";       //      ESCOLA < 042 >
                    str = "Dear Diary,\nMy calculations have proven that the Iroquois legend is indeed real. There is a day, a single day every one hundred years, when a single sunflower on Earth becomes the Guiding Sunflower for an entire Earth rotation. Throughout these 24 hours, the Guiding Sunflower stops following the Sun’s trajectory, and instead it is the Sun that starts following the Sunflower. Of course, that sunflower is indistinguishable from any other by any conventional means. But if someone were to locate and destroy the Guiding Sunflower during the time of its awakening, then I have proven that not only would the Sun’s motion stop, but also the flow of Time itself. This would mean that I could live and play forever. I could eat candy forever. And what’s more: the date of awakening of the next Guiding Sunflower falls on a Saturday. That means that if I manage to destroy the Guiding Sunflower, I will never ever have to go back to school. Ever.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "042")
                {
                    lastText = "043";       //      ESCOLA < 043 >
                    str = "And now, finally, I realize. She didn’t expect any of this. She is trapped on this time loop just like I am, except she doesn’t know about it. Her plans to destroy the Guiding Sunflower, my sunflower, keep succeeding every time, and that resets the Time flux once again. Somehow I have to find the way to thwart the perfect plans of the evil genius who has managed to stop the flux of the universe’s space-time continuum, or we will all be trapped in here forever. We are doomed.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "034")
                {
                    lastText = "037";       //      ESCOLA < 037 >
                    str = "Went upstairs one floor and realized I was lost.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "005")
                {
                    lastText = "007";       //      ESCOLA < 007 >
                    str = "I rushed towards her, unwilling to leave her daughter alone with that monster for a minute longer than necessary. \n ''Miss! Miss!'' I screamed. She turned towards me, obviously startled by my tone of voice. ''There’s a dangerous individual inside the school. We have to find her and kick her out, no matter what''. \nShe looked alarmed by my words, ''Sir, I think you need to calm down. There is no danger, and all the staff of the school are qualified professionals. Is your child inside the school?''";
                    op1 = "''You don’t understand! Your own daughter is talking to the murderer!''";
                    op2 = "''I have no children, I came here to save my sunflower!''";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "014";       //      ESCOLA < 014 >
                    str = "“You don’t understand! Your own daughter is talking to the murderer!'', I screamed in panic. Surprisingly, Miss Summers stayed as calm as a cool breeze. “My daughter, you say? Well, you will find she’s quite mature for her age. Why don’t we call her and ask her about it?”. And that’s just what she did. Five minutes later her daughter was at the gate, wearing the same dress as the other day… which actually made sense, of course, considering we were reliving the same twenty-four hours over and over. “Dear, this man here says he saw you talking with a strange person a few minutes ago. Is that true?” said Miss Summers to her daughter.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "014")
                {
                    lastText = "015";       //      ESCOLA < 015 >
                    str = "Her daughter’s face lit up, delighted to know the answer to the question. “Strange? It was just Miss Montreau, the fire woman who’s been coming this week to prepare us for the fire emergency drills. She was telling me stories of the people she has saved, mom!” she yelled with wide eyes. \nMiss Summers made a dismissive gesture with her hand. “See? No reason to get so worked out. And now, if you’ll excuse me, I have quite a busy day ahead”.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "017";       //      ESCOLA < 017 >
                    str = "“Your daughter is in danger, Miss Summers”, I said. I was expecting her to panic at such an announcement, or at least get alarmed, but she stayed as calm as a cool breeze. “My daughter, you say? Well, you will find she’s quite mature for her age. Why don’t we call her and ask her about it?”. And that’s just what she did. Five minutes later her daughter was at the gate, wearing the same dress as the other day… which actually made sense, of course, considering we were reliving the same twenty-four hours over and over. “Dear, this man here says he saw you talking with a strange person a few minutes ago. Is that true?” said Miss Summers to her daughter.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "018")
                {
                    lastText = "018";       //      ESCOLA < 018 >
                    str = "Her daughter’s face lit up, delighted to know the answer to the question. “Strange? It was just Miss Montreau, the fire woman who’s been coming this week to prepare us for the fire emergency drills. She was telling me stories of the people she has saved, mom!” she yelled with wide eyes. \nMiss Summers made a dismissive gesture with her hand. “See? No reason to get so worked out. And now, if you’ll excuse me, I have quite a busy day ahead”.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "021")
                {
                    lastText = "022";       //      ESCOLA < 022 >
                    str = "“I’m sure a teacher with such good recommendations as yourself will know better than to start wandering about on a new School. As you know, Schools are no place for the faint of heart. Until you become familiar with our most dangerous regions and get acquainted with the main predators of our local fauna, please stick to my directions and you’ll have no trouble getting to your destination. Now I must excuse myself, as I have a parents meeting today. I’ll check on you by lunchtime, all right? Good luck with the class”.\nFeeling somewhat dazed by her unending stream of words, but also quite elated at the success of my infiltration attempt, I decided to…";
                    op1 = "find my students on 5B and give them a masterclass...";
                    op2 = "look for the teachers room…";
                    op3 = "spy on Miss Summer’s parent meeting…";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "023";       //      ESCOLA < 023 >
                    str = "find my students on 5B and give them a masterclass on ostrich reproduction. I’ve always believed that if someone had just done that for me when I was their age, they would have saved me from becoming the mental shipwreck I currently am. Unfortunately, class 5B wasn’t as easy to find as it seemed, and by the time I managed to reach it the class had already ended and children were running towards their freedom. I followed them to the main entrance and went home with a bitter feeling of disappointment at having wasted my one true chance in life at sacrificing myself for the greater good. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "026";       //      ESCOLA < 026 >
                    str = "ran away from him, afraid he would give me away to a teacher. In the end, though, I ended up getting so lost I wasn’t sure I would be able to get out of the school even if I wanted, so by the time I heard the lunch time bell and found a window that connecting to the outside, I gave a silent prayer of gratitude and escaped through through it, swearing never to set a foot on that accursed place again.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "030") TimeTravel();

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
                if (lastText == "001")
                {
                    lastText = "003";       //      HOME < 003 >
                    str = "... spy on my neighbour. She lives two floors up. I went out in my sleepers and";
                    op1 = "Knocked on her door...";
                    op2 = "Peeked through the keyhole...";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "003")
                {
                    lastText = "005";       //      HOME < 005 >
                    str = "... peeked through the keyhole. ";
                    if (t == 1) str += "It was just dark.";
                    if (t == 2) str += "I saw my neighbour. She was writing a note on a piece of paper.";
                    if (t == 3 | t == 4) str += "There was a long rope coiled on the ground and some red cylinders with a string sticking out of them next to it.";
                    if (t == 5)
                    {
                        if (!itemLove) str += "She was writing a note on a piece of paper.";
                        if (itemLove)
                        {
                            str += "I saw my neighbour on the ground with a red face fighting to breathe. The street sweeper was holding a phone in one hand and the bouquet of flowers in the other. Poor guy.";
                            infoAllergy = true;
                        }
                    }
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
              
                break;
            case 2:                         //  >> PARC <<
                if (lastText == "001")
                {
                    lastText = "024";       //      PARC < 024 >
                    str = "... a really old lady sitting in a bench, so peacefully. I went to sit next to her, and she seemed startled for a second until she squeezed her eyes and said, “Timothy? Is that you, dear?”";
                    op1 = "“Err, I... no.”";
                    op2 = "“Certainly.”";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "002")
                {
                    lastText = "004";       //      PARC < 004 >
                    itemFlowers = true;
                    str = "“Su... Roses,” I replied shrewdly. I wasn’t so dumb to reveal my true allegiances to a complete stranger just like that. What if he was the sunflower murderer?\n“Ah”, he said, looking somehow disappointed with my answer. “Well, I do have some roses, if you want them”. \nSeedless flowers hold no appeal to me, but I took the roses anyway, not wanting to give myself away.\nI was getting more and more uncomfortable with my charade, as if I had betrayed my pure devotion of sunflowers, so I thanked the gardener and walked away soon after that.";
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
                    str = "“You, uhm... what were you talking about just now?”, I tried to ask as casually as I could. \nHe was still startled, but he looked at me and sighed. \n“I, uh... it’s complicated,” he said.";
                    op1 = "“You’re right, I don’t wanna hear this”.";
                    op2 = "“I have time”.";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    lastText = "018";       //      PARC < 018 >
                    str = "“I have time”.\n “Well... I, I don’t know you, but I don’t really have anyone else to talk with. I, uh... it’s a woman. I love her, I truly do... but to be with her, I would have to betray everything I believe in. And I can’t just do that, can I?”";
                    op1 = "“Sure you can”";
                    op2 = "“That’s right. You have a duty”";
                    if (itemFlowers) op3 = "Flowers.";
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
                else if (lastText == "007" | lastText == "010" | lastText == "009" | lastText == "009b")
                {
                    GotoCasa();
                }

                break;
            case 3:                         //  >> ABOCADOR <<
                if (lastText == "001")
                {
                    lastText = "003";       //      ABOCADOR < 003 >
                    str = "... search for useful junk. \nIt wasn’t easy to find something I could use among the trash, but I persevered. As I was doing my third pass through the dumpster, I saw something that caught my eye. It was...";
                    op1 = "...a neat pile of wooden planks...";
                    op2 = "...a weird contraption...";
                    op3 = "...a sturdy-looking crowbar...";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "003")
                {
                    lastText = "005";       //      ABOCADOR < 005 >
                    str = "... a weird contraption made of wool, glass and copper tubes. After examining more closely, I realized it was actually a weird musical instrument I had never seen before. I didn’t know what it could be useful for, but I decided to bring it home with me anyway.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                 else if (lastText == "008")
                {
                    lastText = "014";       //      ABOCADOR < 014 >
                    str = "”Hey, hold on! What was that loophole thing about?”, I asked. \n“In a temporal loop let’s say you, particles cannot go back, the arrow of time won’t completely stop for them, follow me? if we think we are subatomic particles and because the quantum entanglement and the fractal nature of existence we can think that ‘kay? some things won’t reset every loop y‘know? as it is shown and revealed in this pictograms made by a sage.” \nA shaky finger and a broken nail pointed towards some ugly drawings made with a marker in a cardboard box.";
                    op1 = "“Isn’t that your bed?”";
                    op2 = "“Isn’t that your marker?”";
                    op3 = "“Isn’t that your handwriting?”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "011")
                {
                    lastText = "013";       //      ABOCADOR < 013 >
                    str = "Suddenly, I started hearing the voices once again. “Am I going crazy?” I thought. \n\n”...”\n\n “I must be dreaming all of this.”\n\n”...”\n\nMuch to my relief, I came back to reality when he suddenly spat out:\n“Sunflower.”\n“One of a hundred.”";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "014")
                {
                    lastText = "017";       //      ABOCADOR < 017 >
                    str = "“Isn’t that your handwritting?” I asked.\n“I have a very conventional handwritting,”he replied before falling soundly asleep.\nI went home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                break;
            case 4:                         //  >> MAGATZEM <<
                if (lastText == "001")
                {
                    lastText = "003";       // WH  < 003 >
                    str = "... looked around for clues. After searching for a couple hours, I found a cap between some bushes. I didn’t think much of it until I realized its logo depicted the exact pattern of sunflower seeds. This couldn’t be a coincidence. Shaken to the core, I decided to go back home and think about the implications of such a reveal.";
                    infoGorra = true;

                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "009")
                {
                    lastText = "011";       //  wh<  11>
                    str = "''Are you planning to kill my neighbour?'' I guessed. \n''Of course not! Why would I? I still love her!'' He yelled back, shaking and holding the shotgun tightly. ''I want to be alone. This is none of your bussiness. Your plant is safe now and that is all you need to know. Just go and forget you ever saw me.''";


                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "008";       // wh < 14 >
                    str = "''Why don’t you give me that weapon?'' I asked reasonably.\n''No way, I have to destroyt it'' he said.\n";
                    op1 = "What are you doing here?";
                    op2 = "";
                    op3 = "What are you going to do with that?";
                    op4 = "There must be a way I could open this door before this guy gets here";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);

                }

                else if (lastText == "007")
                {
                    lastText = "007";       //  < 17 >
                    str = "''Um... I was just casually passing by'' I told him innocently. \n''Don't lie to me.''\n";
                    op1 = "Holy sunflowers! I hope you’re not gonna kill me with that...";
                    op2 = "";
                    op3 = "'You’re the sunflower murderer!''";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }
                else if (lastText == "006")
                {
                    lastText = "020";       //  <020 >
                    str = "I peeked through the door. The street sweeper was holding something, but I couldn’t see it clearly. ";
                    op1 = "I rushed in!";
                    op2 = "I held my breath";


                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }

                else if (lastText == "020")
                {
                    lastText = "022";       // wh < 22 >
                    str = "I held my breath and kept my eyes open. The street sweeper was manipulating the object awkwardly. Breathing heavily he was turning it around and examining it, looking at it from all sides. \n";
                    op1 = "I kept looking";
                    op2 = "I yelled out";
                    op3 = "";
                    op4 = "";

                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "024";       //  wh < 24 >
                    str = " I yelled out of panic when a pigeon bumped against my back. Some other birds came out flying from their nests because of my scream, and then I heard a really loud ''BANG!'' echoing loudly. The street sweeper laid facing the ground in a pool of blood. The object he had been holding turned out to be a gun, and he had shoot himself by accident because of my noise. I...";
                    op1 = "... got the hell out of there";
                    op2 = "... went to check him up";

                    infoWeapon = true;
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }

                else if (lastText == "024")
                {
                    lastText = "026";       //  < 26 >
                    str = "... went to check him up. He was dead. I felt guilty for a second, at least until I realized that he would probably be fine by tomorrow if the time loop reset itself, so I decided to pick his pockets. I found a wallet, two rusty nails, some oily fish, a few coins, some matchsticks, a folded piece of paper, and an emblem of the order of the Sunflower with the following inscription carved ''The Sun follows, the Flower guides''\n";
                    op1 = "I opened the folded paper";
                    op2 = "";
                    op3 = "";
                    op4 = "";

                    pm.UpdateOptions(op2, op1);
                    pm.UpdateText(str);
                }

                else if (lastText == "026")
                {
                    lastText = "026b";       //  < 026b  >
                    str = "I opened the folded paper. It had some oil spots on it but I could still read it: \n''Darling, it is so sweet you finally decided to help me out with this. I want you to know that I really appreciate it. \nYou’ll find you-know-what behind some boxes, near the door. The target is located two balconies under mine, and you can easily hit it from the rooftop in the next building. I’ll be waiting for you. Love you''\nLooked like your typical cold-blooded murderer love letter. I got the idea that my neighbour was somehow involved in it. Anyway, she could do no harm anymore, so I took off before someone came and got the wrong idea. ";

                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                else if (lastText == "005")
                {
                    lastText = "005";       //  < 029 >
                    str = "I smelled it. It stinked of fish";
                    op1 = "I tried to open it by pushing against it...";
                    op2 = "";
                    if (itemCrowbar) op3 = "I tried to open it with my crowbar...";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                break;
            case 5:                         //  >> PIZZA <<
                if (lastText == "002" | lastText == "003")
                {
                    lastText = "016";       //      PIZZA < 016 >
                    str = "... went to the toilet. Nobody had cleaned in ages. The dirtiness made me think of...";
                    op1 = "... cleaning it.";
                    op2 = "... delicious pizza.";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "013";       //      PIZZA < 013 >
                    str = "''I would like something new, daring, fresh.''\n ''All we have is pizza.'";
                    op1 = "''That’d be pepperoni, tomato, rucula... and sunflower.''";
                    op2 = "''Don’t you ever clean the toilet?''";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "010";       //      PIZZA < 010 >
                    str = "''Yes, I’m the guy with the sunflower.''\n ''Oh yes, I might remember you'' He said looking suspicious. I paid and he handed me one of the best pizza in town.";
                    infoFermat = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "009" | lastText == "012")
                {
                    lastText = "014";       //      PIZZA < 014 >
                    str = "''That’d be pepperoni, tomato, rucula... and sunflower'' I added, hoping to catch him off guard.\n ''Umm, ehh... we, we don’t have any of that,'' he mumbled, looking down. He had to be hiding something there! ''And now, now get out of here, the restaurant is too full!''";
                    infoFermat = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "001")
                {
                    lastText = "024";       //      PIZZA < 024 >
                    str = "I kept listening, and he started vomiting words all over, shouting and moving his arms around. \n''will come the time and surely this time has come and past and come AGAIN till it passes away if only no one would PASS AWAY, y’know??\nplay would stop reap shot poison bomb the one we could keep doin keep gofin, keep moving forward! y'know? save it if you can save it yourself and don't waste my time, hey dude don’t waste my time, yesterday is gone tomorrow won't come just shut up SHUT UP and bend low bend down!!''";
                    op1 = "I bend down.";
                    op2 = "I went home.";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "013")
                {
                    lastText = "015";       //      PIZZA < 015 >
                    str = "''Don’t you ever clean the toilet?'' I inquired.\n ''No,'' he said. ''And if you’re not going to get anything, I’m going to have to ask you to leave.''";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "028";       //      PIZZA < 028 >
                    str = "''Hey, hold on! What was that loophole thing about?'', I asked. \n''In a temporal loop let’s say you, particles cannot go back, the arrow of time won’t completely stop for them, follow me? if we think we are subatomic particles and because the quantum entanglement and the fractal nature of existence we can think that ‘kay? some things won’t reset every loop y‘know? as it is shown and revealed in these pictograms made by a sage.'' \nA shaky finger and a broken nail pointed towards some ugly drawings made with a marker in a cardboard box.";
                    op1 = "''Isn’t that your bed?''";
                    op2 = "''Isn’t that your marker?''";
                    op3 = "''Isn’t that your handwriting?''";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "025")
                {
                    lastText = "027";       //      PIZZA < 027 >
                    str = "''I’ll pass this one'' I replied, excusing myself. I don’t think he even heard me. He had sunk into his nonsense talk again.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "028")
                {
                    lastText = "030";       //      PIZZA < 030 >
                    str = "''Isn’t that your marker?'' I asked\n''Well, that’s a really common marker,'' he replied before falling soundly asleep. I went home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    str = "... delicious pizza, so I...";
                    if (itemSandWich)
                    {
                        lastText = "020";       //      PIZZA < 020 >
                        op1 = "... went back to look for some pizza behind the counter.";
                    }
                    else
                    {
                        lastText = "019";       //      PIZZA < 019 >
                        op1 = "... went to get some pizza.";
                    }
                    pm.UpdateOptions(op1);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "006";       //      PIZZA < 006 >
                    str = "... read the label. There was enough herbicide in that bottle to kill a Baobab... Or to clean a toilet. ''Hehe, Fermat won’t be happy about this'', I thought. Once I finished cleaning the toilette, I replenished the bottle with plain water and left it where it was. I felt great. Not only I had helped cleanse the world, but I had also saved the sunflower from another deadly threat.";
                    itemPoison = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                break;
            case 6:                         //  >> AIGUA <<
                if (lastText == "001")
                {
                    lastText = "010";       //      AIGUA < 010 >
                    str = "Infiltrate the plant through the private entrance, of course! As Sun Tzu once said, ''Attack your enemy where he is unprepared, appear where you are not expected''. A perfect plan, indeed. \nExcept, for, well, that PIN code detail. Right. Well, the PIN had only four digits, whereas I had twenty. How hard could it be to defeat it with such an advantage?\nI reached the pad and looked around to make sure there was no one around, and then I input the super secret PIN number... ";
                    pm.UpdateOptions(1);
                    pm.UpdateText(str);
                }
                else if (lastText == "002")
                {
                    lastText = "004";       //      AIGUA < 004 >
                    str = "... fled. What else was I going to do? I’m a coward, yes, but at least I’ve never pretended otherwise.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "005")
                {
                    lastText = "008";       //      AIGUA < 008 >
                    str = "''Wouldn’t you happen to have an eight year old daughter?''\nThe guard looked at me with disbelief. ''You know my daughter?'' he asked, cautiously. \n''Well, of course! I’m a volunteer at the public school, and she’s always talking of you, and all the wonderful things you do together! She loves you very, very much''. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    lastText = "018";       //      AIGUA < 018 >
                    str = "The treatment plant was where all the fun really happened. Less than five minutes after arriving I was already swimming with all the algae and bacteria of the anoxic tank, and making sand castles on the sand filters. Had it not been for the toxic smells of all those chemicals making me kind of dizzy, I would have certainly stayed there way longer, and I might never have reached...";
                    op1 = "The control room.";
                    pm.UpdateOptions(op1);
                    pm.UpdateText(str);
                }
                else if (lastText == "019")
                {
                    lastText = "021";       //      AIGUA < 021 >
                    str = "... pushed it. The moment I did, a loud emergency alarm got activated, red lights started flashing all over the water treatment plant, and the serious looking people started looking less serious and more panicky. It didn’t seem like they would be too happy about me pushing their button, so I took the chaos and confusion as my cue to disappear from the water treatment plant before they checked their video feed recordings.";
                    itemWater = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                break;
            case 7:                         //  >> PASSEIG <<
                if (lastText == "001")
                {
                    lastText = "009";   //    < 009 >
                    if (!v7_001) str = "... an innocent looking girl, about eight or nine years old. She was jumping rope on the sidewalk, but as soon as I approached her she flashed me a charming smile. “Good evening, sir! Did you get lost?”, she asked with wide eyes.";
                    else str = "... an innocent looking girl. ”Hey, it’s you again!” she said, “Are you still lost?”";
                    op1 = "“No... I’m just looking for someone, although I don’t really know who.”";
                    op2 = "“All my life. How about you?”";
                    op3 = "“Do you like chocolate?”";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                else if (lastText == "002b")
                {
                    lastText = "004";      //    < 004 > 
                    str = "“And who the hell are you?”, I asked quite briskly. I admit I don’t take too kindly to invisible strangers startling me in small alleways. \n“Worry not, sunflower Brother. As I said, I am the Mysterious Voice™, Protector of the Poor and Helpless, Saver of Worlds, and Professional Adventure Advisor.”";
                    op1 = "“I’d say you’re just an idiot hiding under a sewer door...”";
                    op2 = "“If you say so...”";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "007";      //    < 007 >
                    str = "“If you say so...”, I said, hesitating. \n“Of course I say so”, replied the Voice with unwavering confidence. “Now go save a space-time continuum or two. And remember me when you find yourself in need of a friendly, mysterious Voice.”";
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
                    str = "... his most expensive chocolate. “Well, I have some Amedei Porcelana from Tuscana, Italy. It’s an amazing dark chocolate, but it’s certainly not cheap... “\nI paid in cash and asked the shopkeeper if he had seen anyone who looked like they might hate sunflowers, but he just stared blankly at me, so I left. ";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                break;
            case 8:                         //  >> ESCOLA <<
                if (lastText == "001")
                {
                    lastText = "005";       //      ESCOLA < 005 >
                    if (!infoGirlParents | !infoSchoolNeighbour)
                    {
                        str = "talked with some adults at the gate. Most of them were parents delivering or waiting to pick up their children, too busy to pay me any attention. I asked around, but no one had seen anyone suspicious, and although I managed to eavesdrop some conversations here and there, I learned nothing useful in relation to my sunflower.";
                        pm.UpdateOptions(continueText);
                    }
                    else
                    {
                        str = "talked with some adults at the gate. Most of them were parents delivering or waiting to pick up their children, too busy to pay me any attention. I was looking for a way to get inside the school and save the innocent girl from the main avenue when, suddenly, my attention was caught by a grown woman who looked just like the little girl. It had to be her mother!";
                        op1 = "I rushed towards her...";
                        op2 = "I asked a nearby father for her name…";
                        pm.UpdateOptions(op1,op2);
                    }
                    pm.UpdateText(str);
                }
                else if (lastText == "002")
                {
                    lastText = "010";       //      ESCOLA < 010 >
                    str = "'Have you seen anyone suspicious around the school lately?'' I asked nonchalantly. The concierge returned me a blank stare. ''I don’t really get your meaning, sir. I mean, in my eyes all children are clearly suspect of being bloodthirsty, uncivilized savages with no respect whatsoever for morality, dignity or the basic human need of not having the salt on your shaker secretly replaced with washing powder. So in a sense, yes, I’ve seen about two hundred suspicious persons around, although ''person'' may be an overstatement''.";
                    op1 = "I ran away.";
                    pm.UpdateOptions(op1);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "030";       //      ESCOLA < 030 >
                    str = "tried to locate my kin tribe again. I had a hunch they might have set camp in one of the rainforests on the eastern wings of the School.\nI lost most of my clothes and my left ear during a particularly violent attack by wildlings, but I managed to reach the eastern wings with my life intact. And, just as I had predicted, my tribe was camped right there in the rainforests, close to a huge waterfall. They made fluttering sounds and clapped their hands against their shoulders as a signal of welcome, and offered me some roasted leather, probably from the covers of wild books scavenged on the northern libraries. And I must say that sitting there in the campfire, roasting leatherbound volumes and listening to their wordless atonal songs, I felt home at last. Tomorrow I would wake up in my home and I would continue the quest to save my sunflower, but, at least today, I would stay here and sing battlesongs with my newfound family.";
                    pm.UpdateOptions(continueText); 
                    pm.UpdateText(str);
                }
                else if (lastText == "032")
                {
                    lastText = "034";       //      ESCOLA < 034 >
                    str = "Turn left before the fire exit. Then I…";
                    op1 = "Went upstairs one floor... ";
                    op2 = "Went down the double staircase...";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "033")
                {
                    lastText = "036";       //      ESCOLA < 036 >
                    str = "Turned right near the cafeteria, then I finally…";
                    op1 = "Went down one floor…";
                    op2 = "Followed straight…";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "036")
                {
                    lastText = "040";       //      ESCOLA < 040 >
                    str = "Followed straight until I reached classroom 2B. Miss Summers’ daughter’s class. \n I had to search desk by desk, as I had no idea which one was hers, but soon enough I found a desk with a pile of papers signed under the name “Valentine Summers”. She had a neat, regular handwriting, and the papers were all perfectly inconspicuous. Some watercolor drawings, a notebook page with substractions and additions for math class… I started to give up, thinking I was going mad, but my fingers kept prickling around the her desk, and then I felt it. A tiny hole under the table, almost too small to feel it with your own fingers. A false bottom. I took out the ink charge of one of her pens and used it to life the fake bottom of her desk drawer. And inside, I finally found what I had been looking for. The truth.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "034")
                {
                    lastText = "038";       //      ESCOLA < 038 >
                    str = "Went down the double staircase and realized I was lost.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "005")
                {
                    lastText = "008";       //      ESCOLA < 008 >
                    str = "I asked a nearby father for her surname, and he helpfully revealed it was ''Summers''.\n''Miss Summers, I presume? May I have a minute?'' I asked with a serious voice. She looked at me and nodded.";
                    op1 = "Your daughter is in danger, Miss Summers.";
                    op2 = "I’m the new substitute teacher.";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "016";       //      ESCOLA < 016 >
                    str = "''I have no children, I came here to save my sunflower!'', I screamed in panic. Miss Summers wrinkled her eyebrows. “Save your...? Sir, are you aware that you are not allowed to be here unless you are the legal guardian of one of the school students? I’m afraid I’ll have to ask you to leave the premises immediately. And don’t worry, if there was in fact a dangerous person in our school, which I doubt, we would take care of it.\nWith that she crossed the gate, and I was left by myself with nothing to do but go home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "019";       //      ESCOLA < 019 >
                    str = "“I’m the new substitute teacher,” I said confidently. Miss Summers shot me a look of appraisal, and then she nodded. \n“About time, I would say. And what was your name again, Mr…?”";
                    pm.UpdateOptions(1);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "024";       //      ESCOLA < 024 >
                    str = "look for the teachers room. Perhaps I could find some useful clues there. The problem was that I naturally had no idea about the location of the teacher’s room, so I started walking at random until I found a young boy, maybe five or six years old, sitting in one of the school staircases. I…";
                    op1 = "ran away from him…";
                    op2 = "tried to enlist his help…";
                    pm.UpdateOptions(op1,op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "024")
                {
                    lastText = "027";       //      ESCOLA < 027 >
                    str = "tried to enlist his help for my cause. “Well met, stranger”, I began, “I hail from distant lands with a proposal to you and your tribe, which I believe shall work towards the betterment and attainment of our mutual interests in these hostile wasteland known to some as School. Show me where the teacher’s room is, and we shall dance naked around a bonfire where we’ll burn the concierge’s purse and use its ashes to paint our faces as a sign of everlasting kinship and affiliation”.\nHe seemed to think about it for a few seconds, and then he nodded curtly before jumping out of the stairs, motioning for me to follow him.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

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
                if (lastText == "001")
                {
                    lastText = "006";       //      HOME < 006 >
                    str = "... search for cameras or traps around the house. All I found were some old donnuts, my favorite underwear, a lighter, the tv remote and a pregnant mouse.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                break;
            case 2:                         //  >> PARC <<
                if (lastText == "001")
                {
                    lastText = "028";       //      PARC < 028 >
                    str = "... my favourite sitting spot. \nAs I lay there, breathing slowly, drinking it all in, I could almost feel all my problems beginning to fade away. If only I could stay there forever, enjoying that nice breeze and thinking of nothing... \nBut I couldn’t. I still had a murderer to catch, and a sunflower to save.";
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
                    str = "“I like flowers”, I said. \nHe looked up at me, his eyes still unfocused, and slowly he came back to his senses. \n“Yes... yes, me too. Here, you can have some, if you want”, he muttered. \nI thanked him and left, as he seemed ill-disposed at the moment.";
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
                if (lastText == "001")
                {
                    lastText = "007";       //      ABOCADOR < 007 >
                    str = "... go talk to the hobo. \nI figured that since he often sat in the middle of the street all day, probably drugged on God knows what, he would know better than anyone what was going on inside the human soul, and thus could help me uncover the murderer. I sat next to him, but he didn’t seem to notice me. He was mumbling something to himself and making strange drawings on the pavement. On a second thought, he was probably just nuts.";
                    op1 = "I kept listening to him.";
                    
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "003")
                {
                    lastText = "006";       //      ABOCADOR < 006 >
                    str = "... a sturdy-looking crowbar, which I could probably use to open almost any locked door I encountered. Handy.";
                    itemCrowbar = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
               
                else if (lastText == "014")
                {
                    lastText = "015";       //      ABOCADOR < 015 >
                    str = "”Isn’t that your bed?” I asked.\n“Yes indeed! The pictograms appeared in my bed this morning. A time traveler must have made them,” he replied before falling soundly asleep. I went home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                break;
            case 4:                         //  >> MAGATZEM <<
                if (lastText == "001")
                {
                    lastText = "004";       //  WH< 004 >
                    if (itemSandWich)
                    {
                        str = " fed some cats I found lying around. Then I got bored of it went back home. ";
                        itemSandWich = false;
                    }
                    else { str = "Or I should say I would have fed them, except I had no food on me and didn’t feel like being eaten alive yet."; }
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }


                else if (lastText == "009")
                {
                    lastText = "012";       //  WH< 012 >
                    str = "''Are you planning to kill my plant?'' I asked full of accusation. \n''No, that’s not what I wanted! I was so confused..I was deeply in love, you see. But luckily I’ve come to my senses in time! Now I will destroy this firearm and save your sunflower from all danger. You should go home and be with who you love the most'' He said with tears in his eyes. What a sad story... but if his words were true, my sunflower was now safe.";

                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }


                else if (lastText == "008")
                {
                    lastText = "009";       // wh  <  15>
                    str = "''What are you going to do with that?'' I asked. \n ";
                    op1 = "Are you dealing with weapons?";
                    op2 = "Are you planning to kill my neighbour?";
                    op3 = "Are you planning to kill my plant?.";
                    op4 = "I trust you won't do anything stupid";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }

                else if (lastText == "007")
                {
                    lastText = "008";       // wh < 18 >
                    str = "'You’re the sunflower murderer!!'' I shouted. \n''This is not true! It’s not what it seems...'' He looked down, ashamed.\n";
                    op1 = "What are you doing here?";
                    op2 = "Why don’t you give me that weapon?";
                    op3 = "What are you going to do with that?";
                    op4 = "There must be a way I could open this door before this guy gets here";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }

                else if (lastText == "005")
                {
                    lastText = "005";       //  < 27 >
                    str = "I smelled it. It smelled almost unbearably fishy.\n";
                    op1 = "I tried to open it by pushing against it";
                    op2 = "";
                    if (itemCrowbar) op3 = "I tried to open it with my crowbar";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }


                else if (lastText == "005")
                {
                    lastText = "30";       //  < 30 >
                    str = " I tried to open it with my crowbar. I managed to injure myself with it and, much to my surprise, it worked. Inside the room I easily found the sniper’s gun hidden under a box. I picked it up and tossed it on a random potato field. Let the plants deal with it. My sunflower would be safe today.";

                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                else
                {
                    Debug.Log("Default caseA: Going to MAPA");
                    GotoMapa();  //  [ RETURN ]
                }
                break;
            case 5:                         //  >> PIZZA <<
                if (lastText == "002")
                {
                    lastText = "021";       //      PIZZA < 021 >
                    str = "... approached the hobo sitting on the sidewalk next door. \nI figured that since he often spent the whole day sitting in the middle of the street, drugged on God knows what, he would know better than anyone what was going on inside the human soul, and thus could help me uncover the murderer. I sat next to him, but he didn’t seem to notice me. He was mumbling something to himself and making strange drawings on the pavement. On a second thought, he was probably just nuts.";
                    op1 = "I kept listening to him. ";
                    op2 = "I went home.";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                else if (lastText == "007")
                {
                    lastText = "014";       //      PIZZA < 014 >
                    str = "''That’d be pepperoni, tomato, rucula... and sunflower'' I added, hoping to catch him off guard.\n ''Umm, ehh... we, we don’t have any of that,'' he mumbled, looking down. He had to be hiding something there! ''And now, now get out of here, the restaurant is too full!''";
                    infoFermat = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "011";       //      PIZZA < 011 >
                    str = "'Yes, and you should clean your toilet.'' \nHis eyes narrowed.\n ''If you’re not going to get anything, I’m going to have to ask you to leave.''";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "009" | lastText == "012")
                {
                    lastText = "015";       //      PIZZA < 015 >
                    str = "''Don’t you ever clean the toilet?'' I inquired.\n ''No,'' he said. ''And if you’re not going to get anything, I’m going to have to ask you to leave.''";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "032";       //      PIZZA < 032 >
                    str = "''Hey dude! fancy a sandwich?'' I handed him the sandwich. He ate it without a comment. After finishing it he took a sip of beer, eructed, and kept on mumbling. I decided to go home.";
                    infoHoboSandwich = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "028")
                {
                    lastText = "031";       //      PIZZA < 031 >
                    str = "''Isn’t that your handwritting?'' I asked\n''I have a very conventional handwritting,'' he replied before falling soundly asleep. I went home.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

                break;
            case 6:                         //  >> AIGUA <<
                if (lastText == "001")
                {
                    lastText = "011";       //      AIGUA < 011 >
                    str = "... explore the outside of the water processing plant. Yes, the world is full of thrilling tales of adventure, daring escapes and cunning infiltrations. Yes, those stories fill us all with awe and admiration towards their heroes. And no, I am not one of them. \nI had no intention whatsoever of ending in jail, even less so if it required trespassing a heavily armed government compound out of the nonsensical notion that the murderers of my sunflower might be found inside.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "005")
                {
                    lastText = "007";       //      AIGUA < 007 >
                    str = "''Err... Sunflower!'' \nYeah, I’ve never been able to lie. So what? Whenever I get too nervous or I feel questioned, the truth just comes out of my mouth out of its own will. It’s a compulsion. I can’t help it. \n''Su... what?'' asked the guard, perplexed. \n''Yes, sir. My sunflower. I have to save it. They want to murder it! If only you would let me in for a...";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "016")
                {
                    lastText = "024";       //      AIGUA < 019 >
                    str = "The control room was a big cubicle at the end of a long corridor, full of screens and beeping sounds and serious looking people doing serious looking things and bustling about. It didn’t really look like the kind of place where one could find a sunflower murderer, but what I did find was a big red button with the label “EMERGENCY STOP OF ALL WATER OPERATIONS”. I...";
                    op1 = "... pushed it.";
                    op2 = "... didn’t push... nah, just kidding. Of course I pushed it.";
                    pm.UpdateOptions(op1, op2);
                    pm.UpdateText(str);
                }
                break;
            case 7:                         //  >> PASSEIG <<
                if (lastText == "001")
                {
                    lastText = "024";       //  < 024 >
                    str = "... a chocolate store. What can I say - I may cherish sunflowers, but I have a love for all edible seeds, and chocolate is no exception. \nThe shop was well stocked, and the shopkeeper was a smiling old man with a bushy beard. I asked him for... ";
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
                    str = "... whatever a child might like, thinking of the little girl I had seen playing outside. \nI paid in cash and asked the shopkeeper if he had seen anyone who looked like they might hate sunflowers, but he just stared blankly at me, so I left.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                    itemChocolate = true; 
                }
                break;
            case 8:                         //  >> ESCOLA <<
                if (lastText == "001")
                {
                    lastText = "013";       //      ESCOLA < 013 >
                    str = "saw my neighbour talking with a young schoolgirl! How was this even possible? What was a cold-blooded murderer doing here? I leaned against the fence, and I realized the schoolgirl was the young girl I had seen playing at the main avenue. That was so strange… what was actually happening here? Was my evil neighbour somehow using this poor child for the purposes of her evil plans? I would have to find a way to get inside the school and unveil the truth.";
                    infoSchoolNeighbour = true;
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "002")
                {
                    lastText = "012";       //      ESCOLA < 012 >
                    str = "''Let me in, there’s a murderer inside the school!''. The concierge looked strangely serene given the situation.\n''Are you sure, sir?'' was all she asked.\n''Absolutely! I saw her with my own eyes''.\n''But sir, are you completely certain?'' she asked once more.\n''Completely''.\n''Finally'' sighed the concierge, and a tiny smile somehow managed to creep into the corners of her mouth. ''I can’t believe those little fuckers are finally going to get what they deserve'' And with that she locked the school fence and started whistling happily, locking me outside.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "004")
                {
                    lastText = "031";       //      ESCOLA < 031 >
                    str = "started walking randomly through the wastelands of a public School at night. What could ever go wrong, right?\nAt first I didn’t hear the noise, but after a while I became certain I was being followed. Far ahead I could hear a faint scraping of metal or bone against the wooden floor. Now that I paid attention, I became certain that the pack hunting me consisted of at least a dozen individuals, probably no longer human. It was an ambush. \nPerhaps a braver explorer would have stayed to find out what kind of abominable beasts were going to devour them, out of scientific curiosity if nothing else, but not me. I slit my wrists right there and then, the way I had been taught during my training, knowing I could always come back next loop.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "022")
                {
                    lastText = "025";       //      ESCOLA < 025 >
                    str = "spy on Miss Summer’s parent meeting. I felt like there was something off about that woman.\nAt first everything went just fine. I followed her through the school as silently as possible, and she kept on walking through corridors and staircases. Really, how big could that building be? But then after a while I lost track of her, and when I tried to retrace my steps to follow her, I ended up meeting her face to face. She didn’t seem pleased to find me there, and I fear she suspected I had been following her. After that, she insisted on keeping an eye on me for the rest of the school day, which made me lose any opportunity to investigate further.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }

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
                if (lastText == "001")
                {
                    lastText = "007";       //      HOME < 007 >
                    str = " build a barricade to block the door with my bed and a few wooden planches I found in the dumpster.. The door was locked, so I had to stay inside for the rest of the day.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "002") GotoMapa();
                break;
            case 2:                         //  >> PARC <<
                if (lastText == "001" & t < 4)
                {
                    lastText = "013";       //      PARC < 013 >
                    string s1 = "... a street sweeper, cleaning the park avenue. At the moment, he seemed to be talking very agitatedly with someone over the phone.";
                    string s2 = " A sudden realization hit me right then when I looked at him: his uniform showed the exact same sign I had found on that cap in the warehouse a while ago. The sign of the sunflower!";
                    string s3 = " I decided to...";
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
                    lastText = "027";       //      PARC < 027 >
                    str = "... a group of children chasing each other. They seemed so happy, there in the park, like they didn’t have a worry on this world.\nAs I approached and sat on a bench near the playground, some of them looked at me warily, but after a while they resumed their game.\nWhile sitting on the bench I could easily overhear their conversation, although most of it was of no interest to me, having nothing to do with sunflowers. Apparently, a substitute teacher named Martin had been expected at the school this morning, but in the end he had never showed up.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                break;
            case 3:                         //  >> ABOCADOR <<
                
            case 4:                         //  >> MAGATZEM <<
                if (lastText == "001" & t != 4)
                {
                    lastText = "005";       // WH < 005>
                    str = "... went to the Roller Street warehouse. It had just one door. It was hard, big and ugly. Probably nobody had ever loved it.";
                    op1 = "I tried to open it by pushing against it";
                    op2 = "I smelled it";
                    if (itemCrowbar) op3 = "I tried to open it with my crowbar";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }

                else if (lastText == "001" & t == 4)
                {
                    lastText = "006";       // wh  <006  >
                    str = "... went to the Roller Street warehouse. Once I got there, I walked towards the door. It was hard, big, ugly and open.\n";
                    op1 = "I walked in";
                    op2 = "I peeked through the door";
                    op3 = "I smelled it";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }

                else if (lastText == "009")
                {
                    lastText = "013";       //  <  13>
                    str = "I trust you won't do anything stupid.'' I told him.\n He smiled. ''I won’t. I must destroy this instrument of evil for the sake of everyone... It’ll all be alright. You should go home and take it easy'' He replied calmly. ";
                    op1 = "";
                    op2 = "";
                    op3 = "";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3, op4);
                    pm.UpdateText(str);
                }

                else if (lastText == "008")
                {
                    lastText = "008";       //  <  16 >
                    str = "There must be a way I could open this door before this guy gets here'' I thought out loud.\n''Excuse me?'' He said, confused.\n";
                    op1 = "What are you doing here?";
                    op2 = "Why don’t you give me that weapon? ";
                    op3 = "What are you going to do with that?";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }


                else if (lastText == "007")
                {
                    lastText = "007";       //  < 19 >
                    str = "''Yes, I knew something smelled fishy!'' I said triumphantly. \n''You mean the cats?'' He duly answered. ''I feed them every day.'' \n";
                    op1 = "Holy sunflowers! I hope you’re not gonna kill me with that...'";
                    op2 = "";
                    op3 = "You’re the sunflower murderer!";
                    op4 = "";

                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                
                break;
            case 5:                         //  >> PIZZA <<
                if (lastText == "007")
                {
                    lastText = "015";       //      PIZZA < 015 >
                    str = "''Don’t you ever clean the toilet?'' I inquired.\n ''No,'' he said. ''And if you’re not going to get anything, I’m going to have to ask you to leave.''";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
                else if (lastText == "008")
                {
                    lastText = "012";       //      PIZZA < 012 >
                    str = "''Are you serious? Come on! It’s me.'' \n ''Look'' he said ''your face does look familiar, ok?  What would you like in your pizza?''";
                    op1 = "''I would like something new, daring, fresh.''";
                    op2 = "''That’d be pepperoni, tomato, rucula... and sunflower.''";
                    op3 = "''Don’t you ever clean the toilet?''";
                    pm.UpdateOptions(op1, op2, op3);
                    pm.UpdateText(str);
                }
                break;
            case 6:                         //  >> AIGUA <<
                if (lastText == "001")
                {
                    lastText = "011";       //      AIGUA < 011 >
                    str = "... explore the outside of the water processing plant. Yes, the world is full of thrilling tales of adventure, daring escapes and cunning infiltrations. Yes, those stories fill us all with awe and admiration towards their heroes. And no, I am not one of them. \nI had no intention whatsoever of ending in jail, even less so if it required trespassing a heavily armed government compound out of the nonsensical notion that the murderers of my sunflower might be found inside.";
                    pm.UpdateOptions(continueText);
                    pm.UpdateText(str);
                }
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
            case 6:
                if (lastText == "010")
                {
                    if (ans == "8774")
                    {
                        lastText = "015";       //      AIGUA < 015 >
                        str = "Hah. I knew this puny PIN would be no match for me. True, I had to kill a perfectly innocent girl and take advantage of his father’s grief in order to defeat it, but hey, nothing good ever came out of dwelling in the past too much.";
                        op1 = "''Onwards, to destiny!''";
                        pm.UpdateOptions(op1);
                        pm.UpdateText(str);
                    }
                    else
                    {
                        lastText = "014";       //      AIGUA < 014 >
                        str = "You fought well, brave PIN, and you might have defeated me this time, but we shall see each other again. On this day I swear revenge on you. You may have won this battle, but I shall be the one to win the war.";
                        pm.UpdateOptions(continueText);
                        pm.UpdateText(str);

                    }
                }
                break;
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
                    s2 = "... you look kind of down. Seems like you might need some advise from your friendly next door mysterious voice, amirite?”\nAt first I thought I was imagining voices again, but this one seemed too real to be a figment. In fact, as I listened I realized the sound seemed to be coming from the sewer door directly under my feet. ";
                    str = s1 + s2;
                    // Prepara les noves opcions
                    
                    op1 = "Well, I am quite worried about my sunflower...";
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
            case 8:
                if (lastText == "019")
                {
                    if (ans == "Martin")
                    {
                        lastText = "021";       //      ESCOLA < 021 >
                        str = "“Martin. Pleased to meet you” I answered, hoping that was in fact the name I’d overheard at the park. It seemed to match what she was expecting, because she signaled me to follow her and started walking through the school at a brisk pace. \n“Please come with me, Mr Martin. We have no time to lose. You will be covering class 5B for today. Our school is in fact quite big, and new teachers have often mentioned difficulties getting around at first. For now, all you need to know is that in order to reach class 5B from the main entrance you should go upstairs to the second floor, then turn right near the cafeteria, follow straight past class 2B, then go up one more floor before taking your first turn to the left”.";
                        pm.UpdateOptions(continueText);
                    }
                    else
                    {
                        lastText = "020";       //      ESCOLA < 020 >
                        str = "“"+ans+ ". Pleased to meet you.” I answered, hoping for a fluke, but Miss Summers wrinkled her forehead as soon as she heard my name. “Really? Mr "+ans+ "? Seems like there’s been some kind of misunderstanding, then. This is Saint Nicolas Public Elementary School, and I’m afraid we are already expecting someone else to cover our vacant teaching spot. No doubt he will arrive soon, although he’s already seven minutes late, and I’m not one to approve of tardiness.";
                        pm.UpdateOptions(continueText);
                    }
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
        im.ShowIntro(loop);
        hobo = Random.value > 0.5f; // Mou el hobo

    }
    public void ResetItems()
    {
        // Reseteja variables temporals             ( aquesta funcio s'executa per IntroManager a dins de "HideIntro")

        item2b1 = itemWater = itemFlowers = itemLove = itemKillLady = false;    // parc
        itemBarricade = itemSandWich = itemCrowbar = false;      // abocador
        v7_001 = v7_009 = itemDeadGirl = itemChocolate = false;     // passeig
        itemFirstTimePizza = itemGun = v5a7 = itemPoison = v1a3 = false;
        itemSchoolKey = false;
}
}
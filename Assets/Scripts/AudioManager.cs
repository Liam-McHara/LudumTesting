using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // musica
    public AudioSource musicaJuego;
    public AudioSource musicaIntroEnding;

    // sonidos
    public AudioSource sonidoClic;


    public void InGame()
    {
        musicaJuego.Play();
        musicaIntroEnding.Stop();
    }
    public void IntroEnding()
    {
        musicaJuego.Stop();
        musicaIntroEnding.Play();
    }
    public void Click()
    {
        sonidoClic.Play();
    }
}


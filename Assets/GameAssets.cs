using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public AudioClip click;
    public AudioClip openingMusic;
    public AudioClip endingMusic;
    public AudioClip victoryMusic;
    public AudioClip mapaMusic;
    public AudioClip homeMusic;
    public AudioClip dumpsterMusic;
    public AudioClip wharehouseMusic;
    public AudioClip parkMusic;
    public AudioClip waterplantMusic;
    public AudioClip schoolMusic;
    public AudioClip pizzaMusic;
    public AudioClip avenueMusic;
}

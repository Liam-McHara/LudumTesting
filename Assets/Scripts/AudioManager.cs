using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static GameObject DJ;
    static int sueldoDJ = 1600;

    static GameObject soundGameObject;
    static AudioSource soundAudioSource;

    public enum Sound   // Sonidos del juego
    {
        click,
    }

    public enum Music   // Música del juego
    {
        opening,
        ending,
        victory,
        map,
        home,
        dumpster,
        wharehouse,
        park,
        waterplant,
        school,
        pizza,
        avenue
}

    public static void PlaySound(Sound sound)
    {
        Debug.Log("Play sound: " + sound);

        if (soundGameObject == null)
        {
            soundGameObject = new GameObject("Sound");
            soundAudioSource = soundGameObject.AddComponent<AudioSource>();
        }
        soundAudioSource.PlayOneShot(GetAudioClip(sound));
    }

    public static void PlayMusic(Music music)
    {
        Debug.Log("Play music: " + music);
        if (DJ == null)     // Si no hay DJ...
        {                   
            DJ = ContratarDJ(sueldoDJ); // contrata uno
        }
        DJ.GetComponent<DJScript>().PlayThisOne(GetAudioClip(music));   // Decirle al DJ que pinche la música
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (AudioResources.SoundAudioClip soundAudioClip in AudioResources.i.soundAudioClips)
        {
            if (soundAudioClip.sound == sound)
            {
                if (soundAudioClip.audioClip == null) Debug.LogError("Sound " + sound + " is empty! Go to AudioResources and fill it with some sound.");
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;
    }
    private static AudioClip GetAudioClip(Music music)
    {
        foreach(AudioResources.MusicAudioClip musicAudioClip in AudioResources.i.musicAudioClips)
        {
            if (musicAudioClip.music == music)
            {
                if (musicAudioClip.audioClip == null) Debug.LogError("Music " + music + " is empty! Go to AudioResources and fill it with some music.");
                return musicAudioClip.audioClip;
            }
        }
        Debug.LogError("Music " + music + " not found!");
        return null;
    }

    static GameObject ContratarDJ(int sueldo)
    {
        Debug.Log("Contratar DJ");
        sueldo = 0;     // Fumarse el sueldo del DJ
        GameObject go = new GameObject("DJ");   // Contratar un mindundi
        go.AddComponent<DJScript>();            // Enseñarle nociones básicas de DJ
        go.AddComponent<AudioSource>();         // Darle un equipo de música
        return go;
    }

}

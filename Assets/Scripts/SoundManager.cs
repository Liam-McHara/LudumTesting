using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    public enum Sound
    {
        click
    }

    public enum Music
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
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(AudioResources.i.click);
        Debug.Log("Playing: " + sound);
    }

    public static void PlayMusic(Music music)
    {
        GameObject DJ = GameObject.Find("Music");
        AudioSource audioSource;
        if (DJ == null)
        {
            DJ = new GameObject("Music");
            audioSource = DJ.AddComponent<AudioSource>();
        }
        else
        {
            audioSource = DJ.GetComponent<AudioSource>();
        }
        audioSource.clip = GetAudioClip(music);
        audioSource.loop = true;
        audioSource.Play();
        Debug.Log("Playing: " + music);
    }

    private static AudioClip GetAudioClip(Music music)
    {
        foreach(AudioResources.MusicAudioClip musicAudioClip in AudioResources.i.musicAudioClips)
        {
            if (musicAudioClip.music == music)
            {
                return musicAudioClip.audioClip;
            }
        }
        Debug.LogError("Music " + music + " not found!");
        return null;
    }
}

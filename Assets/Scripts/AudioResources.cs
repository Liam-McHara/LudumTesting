using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioResources : MonoBehaviour
{
    private static AudioResources _i;

    public static AudioResources i
    {
        get
        {
            if (_i == null) _i = (Instantiate(Resources.Load("AudioResources")) as GameObject).GetComponent<AudioResources>();
            return _i;
        }
    }

    [Header("Sounds")]
    public AudioClip click;

    [Header("Music")]
    public MusicAudioClip[] musicAudioClips;
    
    [System.Serializable]
    public class MusicAudioClip
    {
        public SoundManager.Music music;
        public AudioClip audioClip;
    }
}

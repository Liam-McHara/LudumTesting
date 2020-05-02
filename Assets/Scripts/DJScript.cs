using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJScript : MonoBehaviour
{
    [SerializeField]
    static float fadeStep = .1f;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Cambiar de música con estilo (fadein&fadeout)
    public void PlayThisOne(AudioClip music, float vol = 1f)
    {
        audioSource = GetComponent<AudioSource>();
        // Mira si está sonando algo...
        if (audioSource.isPlaying)
        {
            // Mira si lo que está sonando es diferente...
            if (audioSource.clip != music)
            {
                Debug.Log("Cambiando de " + audioSource.clip + " a " + music);
                StartCoroutine(FadeOutFadeIn(music, vol));
            }
            else
            {   // Si la canción que piden ya está sonando, suda.
                Debug.Log("DJ: Esa ya me la has pedido");
            }
        }
        else
        {   // Si es la primera canción de la noche...
            Debug.Log("DJ: Playing track " + music);
            StartCoroutine(FadeIn(music));
        }
    }

    // Transiciona haciendo fade-out&fade-in a un nuevo clip newMusic al volumen targetVol (100% por defecto). 
    //      Pre: la variable local audioSource está asignada un componente habilitado.
    //      Post: audioSource reproduce newMusic a volumen targetVol después de una transición suave.
    IEnumerator FadeOutFadeIn(AudioClip newMusic, float targetVol = 1f)  
    {
        yield return StartCoroutine(FadeOut());
        yield return StartCoroutine(FadeIn(newMusic, targetVol));
    }

    IEnumerator FadeOut()
    {
        for (float ft = audioSource.volume; ft >= 0; ft -= 0.1f)
        {
            audioSource.volume = ft;
            yield return new WaitForSeconds(fadeStep);
        }
        audioSource.Stop();
    }
    IEnumerator FadeIn(AudioClip music, float targetVol = 1f)
    {
        audioSource.clip = music;
        audioSource.Play();
        Debug.Log("Target Volume: " + targetVol);
        for (float ft = 0; ft < targetVol; ft += 0.1f)
        {
            Debug.Log("DJ: Playing at volume: " + ft);
            audioSource.volume = ft;
            yield return new WaitForSeconds(fadeStep);
        }
    }
    


}

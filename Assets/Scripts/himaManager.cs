using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class himaManager : MonoBehaviour
{
    public Sprite hima1, hima2, hima3, hima4, hima5;
    GameController gc;
    Image img;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        img = GetComponent<Image>();
    }

    void Update()
    {
        switch (gc.t)
        {
            case 1:
                img.sprite = hima1;
                break;
            case 2:
                img.sprite = hima2;
                break;
            case 3:
                img.sprite = hima3;
                break;
            case 4:
                img.sprite = hima4;
                break;
            case 5:
                img.sprite = hima5;
                break;
        }
    }
}

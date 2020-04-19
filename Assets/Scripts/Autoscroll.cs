using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Autoscroll : MonoBehaviour
{
    float h;  // height of the textView
    public float heightLimit;

    // Start is called before the first frame update
    void Start()
    {
        h = GetComponent<RectTransform>().rect.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.hasChanged)
        {
            print("The transform has changed!");
            transform.hasChanged = false;
        }
    }
}

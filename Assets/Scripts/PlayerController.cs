using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float force = 3;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // La funció FixedUpdate s'executa a intervals regulars (no com Update, que s'executa a cada frame) Es perfecta per fer 
    private void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 impulse = new Vector3(hInput, vInput, vInput);
        rb.AddForce(impulse*force);
    }
}

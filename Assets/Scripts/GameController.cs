using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    AudioManager am;
    PanelManager pm;

    
    // VARIABLES
    public int fase;    // fase del día (1 - 5)
    public int resets = 0;

    /*  0 - mapa
     *  1 - casa
     *  2 - parc
     *  3 - abocador
     *  4 - almacen
     *  5 - pizzeria
     *  6 - planta processament d'aigua
     */
    public int place = 0;

    // Variables de coneixement (permanents)
    public bool knowX = false;

    // Character paths  // DEPRECATED???
    public int charAPath = 1;

    // Condicions temporals (es resetejen a cada bucle)
    public bool tempConA = false;



    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponentInChildren<AudioManager>();
        pm = FindObjectOfType<PanelManager>();
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
        
    }
    public void GotoParque()
    {
        Debug.Log("Going to PARQUE");

    }
    public void GotoAbocador()
    {
        Debug.Log("Going to ABOCADOR");

    }
    public void GotoAlmacen()
    {
        Debug.Log("Going to ALMACEN");

    }
    public void GotoPizza()
    {
        Debug.Log("Going to PIZZA");

    }
    public void GotoAigua()
    {
        Debug.Log("Going to AIGUA");

    }

    public void GotoMapa()
    {
        Debug.Log("Going to MAPA");
        ++fase;
        if (fase > 5) TimeTravel();
        pm.HidePanel();
    }

    public void TimeTravel()
    {
        ++resets;   // Actualitza el contador de resets
        fase = 1;   // Torna a la fase 1

        //Reseteja condicions temporals
        tempConA = false;
    }
}
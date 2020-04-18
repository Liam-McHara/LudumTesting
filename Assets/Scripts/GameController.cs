using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    AudioManager am;
    public TextScript ts;
    
    // VARIABLES
    public int fase;    // fase del día (1 - 5)

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

    // Character paths
    public int charAPath = 1;

    // Condicions temporals (es resetejen a cada bucle)
    public bool tempConA = false;



    // Start is called before the first frame update
    void Start()
    {
        am = this.GetComponentInChildren<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    // MAPA
    public void GotoCasa()
    {
        ts.UpdateText("aaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
    }
    public void GotoParque()
    {

    }
    public void GotoAbocador()
    {

    }
    public void GotoAlmacen()
    {

    }
    public void GotoPizza()
    {

    }
    public void GotoAigua()
    {

    }

    public void GotoMapa()
    {

    }
}
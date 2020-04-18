using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSelector : MonoBehaviour
{
    GameController gc;

    void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<GameController>();
    }

    public void GotoCasa()
    {
        gc.GotoCasa();
    }
    public void GotoParque()
    {
        gc.GotoParque();
    }
    public void GotoAbocador()
    {
        gc.GotoAbocador();
    }
    public void GotoAlmacen()
    {
        gc.GotoAlmacen();
    }
    public void GotoPizza()
    {
        gc.GotoPizza();
    }
    public void GotoAigua()
    {
        gc.GotoAigua();
    }
}
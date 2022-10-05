using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Text EnemigoText;
    public Text TipoArmaText;

    private int puntaje;
    void Start()
    {
        puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int GetPuntaje()
    {
        return this.puntaje;
    }

    public void TextArmaDisparo()
    {
        TipoArmaText.text = "Arma: disparo";
    }
   public void TextArmaKatana()
    {
        TipoArmaText.text = "Arma: katana";
    }
    public void PuntajeEnemigo(int puntos)
    {
        this.puntaje += puntos;
        PrintInScreenScore();
    }

    private void PrintInScreenScore()
    {
      //  puntajeText.text = "PUNTAJE: " + puntaje;
        EnemigoText.text = "ENEMIGO:" + puntaje;
    }
}

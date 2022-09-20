using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text balaText;
    private int bala;
    // Start is called before the first frame update
    void Start()
    {
        bala = 5;
    }

    // Update is called once per frame
    public int GetScore()
    {
        return this.bala;
    }
    public void PerderVida()
    {
        this.bala -= 1;
        balaText.text = "bala: " + bala;
        PrintLifes();
    }

    private void PrintLifes()
    {
        balaText.text = "vidas: " + bala;
    }
}

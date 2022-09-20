using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text mon1Text;
    public Text mon2Text;
    public Text mon3Text;
    public Text puntajeText;

    private int mon1;
    private int mon2;
    private int mon3;
    private int puntaje;
    // Start is called before the first frame update
    void Start()
    {
      mon1=0;
     mon2=0;
     mon3=0;
     puntaje=0;
        PrintLifes1();
        LoadGame();
    }

   

    public void SaveGame()
    {

        var filePath = Application.persistentDataPath + "/saves.dat";
        FileStream file;
        if (File.Exists(filePath))
        {
            file = File.OpenWrite(filePath);
        }
        else
        {
            file = File.Create(filePath);
        }

        GameDatas datas = new GameDatas();
        datas.moned1 = mon1;
        datas.moned2 = mon2;
        datas.moned3 = mon3;
        datas.puntaje = puntaje;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file,datas);
        file.Close();
    }
    public void LoadGame()
    {
        var filePath = Application.persistentDataPath + "/saves.dat";
        FileStream file;
        if (File.Exists(filePath))
        {
            file = File.OpenRead(filePath);
        }
        else
        {
            Debug.LogError("no se encontrado archivo");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        GameDatas datas = (GameDatas)bf.Deserialize(file);
        file.Close();
        mon1 = datas.moned1;
        mon2 = datas.moned2;
        mon3 = datas.moned3;
        puntaje = datas.puntaje;
        PrintLifes1();
        PrintLifesmon2();
        PrintLifesmon3();
        PrintInScreenScore();
    }
    public int GetPuntaje()
    {
        return this.puntaje;
    }
    public void PlusScorte(int puntos)
    {
        this.puntaje += puntos;
        PrintInScreenScore();
    }
    private void PrintInScreenScore()
    {
        puntajeText.text = "PUNTAJE: " + puntaje;
    }
   

    public int getMoned1()
    {
        return this.mon1;
    }
    public void moneda1()
    {
        mon1 += 1;
        PrintLifes1();
    }

    public void PrintLifes1()
    {
        mon1Text.text = "MONEDA 1: " + mon1;

    }
    public int getMoned2()
    {
        return this.mon2;
    }
    public void moneda2()
    {
        mon2 += 1;
        PrintLifesmon2();
    }
   

    public void PrintLifesmon2()
    {
        mon2Text.text = "MONEDA 2: " + mon2;

    }
    public int getMoned3()
    {
        return this.mon3;
    }
    public void moneda3()
    {
        mon3 += 1;
        PrintLifesmon3();
    }
    
    public void PrintLifesmon3()
    {
        mon3Text.text = "MONEDA 3: " + mon3;

    }
}

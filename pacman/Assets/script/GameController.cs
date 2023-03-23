using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public static GameController instance;
    public int puntos = 0;
    public int puntos2 = 0;
    public bool canEat;// boolean que dice si te puedes comer fantasmas o no
    public float caneatcount;//contador float

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canEat)//can eat de este script = true
        {
            caneatcount += Time.deltaTime;
            if (caneatcount > 8)// contador de 8 segundos
            {
                CanEatRestart();// can eat se pone en falso
            }
        }
        if (puntos >= 4200)
        {
                SceneManager.LoadScene("win");  
        }
    }
    public void SumarPuntos(int valorpuntos)//suma puntos desde script "puntos"
    {
        puntos = puntos + valorpuntos;
        Debug.Log(puntos);
    }
    public void SumarPuntos2(int valorpuntos)//suma puntos desde script "puntos"
    {
        puntos2 = puntos2 + valorpuntos;
        Debug.Log(puntos2);
    }
    public void CanEat()// can eat del script puntos
    {
        canEat = true;
    }
    public void CanEatRestart()// vuelve a poner el can eat de este script en falso
    {
        canEat = false;
        caneatcount = 0;
    }

}

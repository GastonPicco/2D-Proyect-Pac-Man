using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class puntaje : MonoBehaviour
{
    [SerializeField] public int puntajeContador = 0;
    public TextMeshProUGUI puntos;
    void Start()
    {
        puntos = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        puntos.text = (GameController.instance.puntos + GameController.instance.puntos2 + "");

    }
}

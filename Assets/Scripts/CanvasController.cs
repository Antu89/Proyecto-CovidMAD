using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{

    public Text cajaPuntos;
    public Text cajaTotalPuntos;
    public Text cajaVida;
    public Text cajaTiempo;
    

    public int tiempoInicial;

    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = -3;

    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoSegundos = 0f;
    private float escalaTiempoPausa, escalaTiempoInicial;
    private bool estarPausado = false;

    public GameObject gameController;

    void Start()
    {
        escalaTiempoInicial = escalaDeTiempo;

        cajaTiempo = GetComponent<Text>();

        tiempoSegundos = tiempoInicial;

        
        ActualizarReloj(tiempoInicial);
        gameController = GameObject.FindGameObjectWithTag("GameController");

        

     

    }


    void Update()
    {
        cajaPuntos.text = " x  " + PointsController.puntos;
        cajaTotalPuntos.text = "PUNTOS: " + PointsController.totalPuntos;
        cajaVida.text = "VIDAS: " + PointsController.vida;

        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
        tiempoSegundos += tiempoDelFrameConTimeScale;
        
        ActualizarReloj(tiempoSegundos);

        gameController.SendMessage("MaxScore");


    }


    public void Reiniciar()
    {
        PointsController.vida = 3;
        PointsController.puntos = 0;
        PointsController.totalPuntos = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
    }

    public void Salir()
    {
        SceneManager.LoadScene("Start");
    }

    public void ActualizarDatos()
    {

        int reVida = 3;
        int rePuntos = 0;
        int rePuntosTotales = 0;

        if (PointsController.vida == 0)
        {
            cajaPuntos.text = " x  " + rePuntos.ToString("0");
            cajaTotalPuntos.text = "PUNTOS: " + rePuntosTotales.ToString("0");
            cajaVida.text = "VIDAS: " + reVida.ToString("3");
        }
        
     
    }

    public void ActualizarReloj(float tiempoSegundos)
    {
        int segundos = 0;
        string textoReloj;

        if (tiempoSegundos <= 0)
        {
            segundos = (int)tiempoSegundos;
            
            textoReloj = "TIEMPO: " + segundos.ToString("000");

            cajaTiempo.text = textoReloj;
        }

    }
}



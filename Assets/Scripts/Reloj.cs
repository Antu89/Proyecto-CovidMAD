using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reloj : MonoBehaviour
{

    public int tiempoInicial;

    [Range(-10.0f, 10.0f)]
    public float escalaDeTiempo = -3;

    private Text tiempo;
    private float tiempoDelFrameConTimeScale = 0f;
    private float tiempoSegundos= 0f;
    private float escalaTiempoPausa, escalaTiempoInicial;
    private bool estarPausado = false;



    // Start is called before the first frame update
    void Start()
    {
        escalaTiempoInicial = escalaDeTiempo;

        tiempo = GetComponent<Text>();

        tiempoSegundos = tiempoInicial;


        ActualizarReloj(tiempoInicial);

    }

    // Update is called once per frame
    void Update()
    {
        tiempoDelFrameConTimeScale = Time.deltaTime * escalaDeTiempo;
        tiempoSegundos += tiempoDelFrameConTimeScale;
        ActualizarReloj(tiempoSegundos);



    }

    public void ActualizarReloj(float tiempoSegundos)
    {
        int segundos = 0;
        string textoReloj;

        if (tiempoSegundos < 0) tiempoSegundos = 0;
        {
            segundos = (int)tiempoSegundos;
            textoReloj = "Tiempo: " + segundos.ToString("000");

            tiempo.text = textoReloj;
        }

    }

    public void Pausar()
    {
        if (!estarPausado)
        {
            estarPausado = true;
            escalaTiempoPausa = escalaDeTiempo;
            escalaDeTiempo = 0;
        }

    }

}

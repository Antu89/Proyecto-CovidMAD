using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    private float initialPositionX, initialPositionY;

    public GameObject panel;
    
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void ReinicioAraceli(float x, float y)
    {
        PlayerPrefs.SetFloat("initialPositionX", x);
        PlayerPrefs.SetFloat("initialPositionY", y);
    }

    public void Cancelar()
    {
        StartCoroutine("FinJuego");
    }

    IEnumerator FinJuego()
    {
        yield return new WaitForSeconds(1.5f);
        panel.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SceneController : MonoBehaviour
{
    public AudioSource audio;

    private void Start()
    {
        audio.Play();
    }
    public void Inicio()
    {
        SceneManager.LoadScene("Start");
    }

    public void Jugar()
    {
        SceneManager.LoadScene("Game");
    }

    public void Info()
    {
        SceneManager.LoadScene("CovidInfo");
    }

    public void Salir()
    {
        Application.Quit();
    }


}

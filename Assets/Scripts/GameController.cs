using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private AudioSource audio;
    public AudioClip clip;
    public Text maxScore;


    void Start()
    {
        audio = GetComponent<AudioSource>();
        maxScore.text = "Max Score: " + GetMaxScore();

    }

    
    void Update()
    {
        
    }

    public void SonidoMasc()
    {
        audio.Play();
    }

    public void SonidoArma()
    {
        audio.clip = clip;
        audio.Play();
    }

    public void MaxScore()
    {
        if (PointsController.totalPuntos > GetMaxScore())
        {
            maxScore.text = "Max Score: " + PointsController.totalPuntos.ToString();
            GuardarMaxScore(PointsController.totalPuntos);
        }
    }

    public int GetMaxScore()
    {
        return PlayerPrefs.GetInt("MaxScore",0);
    }

    public void GuardarMaxScore(int puntos)
    {
        PlayerPrefs.SetInt("MaxScore", puntos);
    }
}

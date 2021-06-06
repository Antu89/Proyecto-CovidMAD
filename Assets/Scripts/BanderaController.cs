using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class BanderaController : MonoBehaviour
{
    public AudioSource audio;
    Reloj tiempo;
    public GameObject mensajeFin;

    private void Start()
    {
        tiempo = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Reloj>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PointsController.totalPuntos += 150;
            GetComponent<Animator>().enabled = true;
            audio.Play();
            mensajeFin.SetActive(true);
            tiempo.Pausar();
            StartCoroutine("Ganar");

        }
    }


    IEnumerator Ganar()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Creditos");
    }

}

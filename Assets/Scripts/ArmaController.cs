using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ArmaController : MonoBehaviour
{

    public AudioSource audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            PointsController.totalPuntos += 100;
            Destroy(collision.gameObject);

            audio.Play();
        }
            
    }
}

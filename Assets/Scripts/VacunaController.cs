using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VacunaController : MonoBehaviour
{

    public AudioSource audio;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag ("Player"))
        {
            
            PointsController.vida++;
            Destroy(gameObject, 0.2f);
            

            audio.Play();
        }

    }
}

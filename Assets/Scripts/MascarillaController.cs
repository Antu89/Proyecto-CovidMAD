using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MascarillaController : MonoBehaviour
{
    private float Velocidad;
    public AudioSource audio;


    void Start()
    {
        Velocidad = 90f;
        
    }

    void Update()
    {

        transform.Rotate(Vector3.down*Velocidad*Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag =="Player")
        {
            
            PointsController.puntos++;
            PointsController.totalPuntos+=50;
            Destroy(gameObject, 0.2f);

            audio.Play();
            
        }
        
    }


}

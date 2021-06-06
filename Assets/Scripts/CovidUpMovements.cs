using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CovidUpMovements : MonoBehaviour
{
    public GameObject Araceli;
    public AudioSource audio;

    public Transform target;
    public float velocidad;
    private Vector3 start, end;

    void Start()
    {
        
        start = transform.position;
        end = target.position;


    }

    void Update()
    {

       

        if (Araceli != null)
        {
            Vector3 direction = Araceli.transform.position - transform.position;
            if (direction.x >= 0) transform.localScale = new Vector3(-1, 1, 1);
            else transform.localScale = new Vector3(1, 1, 1);
        }

        
            transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);

            if (transform.position == target.position)
            {
                if (target.position == start)
                {
                    target.position = end;
                }
                else
                {
                    target.position = start;
                }
            }
       
    }

   

    
}



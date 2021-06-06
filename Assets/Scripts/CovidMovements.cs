using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidMovements : MonoBehaviour
{

    public GameObject Araceli;



    void Update()
    {
       
        if (Araceli != null)
        {
            Vector3 direction = Araceli.transform.position - transform.position;
            if (direction.x >= 0) transform.localScale = new Vector3(-1, 1, 1);
            else transform.localScale = new Vector3(1, 1, 1);
        }
        
    }

    
}

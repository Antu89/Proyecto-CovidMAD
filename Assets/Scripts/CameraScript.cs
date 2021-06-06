using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Araceli;
   

    void Update()
    {
        if (Araceli != null)
        {
            Vector3 position = transform.position;
            position.x = Araceli.transform.position.x;
            transform.position = position;
        }
        
        
    }
}

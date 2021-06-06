using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{

    void Start()
    {
        Invoke("Inicio",100);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("Start");
        }
        
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Start");
    }
}

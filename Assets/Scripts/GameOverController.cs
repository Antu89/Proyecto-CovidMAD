using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverController : MonoBehaviour
{
    public GameObject gameOverText;
    public static GameObject gameOverStatic;

    // Start is called before the first frame update
    void Start()
    {
        GameOverController.gameOverStatic = gameOverText;
        GameOverController.gameOverStatic.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Show()
    {
        GameOverController.gameOverStatic.gameObject.SetActive(true);
    }

}

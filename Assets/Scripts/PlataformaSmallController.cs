using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaSmallController : MonoBehaviour
{
    public Transform target;
    public float velocidad;
    private Vector3 start, end;


    // Start is called before the first frame update
    void Start()
    {
        velocidad = 2f;
        start = transform.position;
        end = target.position;


    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.parent = transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.parent = null;
    }
}

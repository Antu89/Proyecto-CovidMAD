using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusMovil : MonoBehaviour
{

    public Transform target;
    public float velocidad;
    private Vector3 start, end;
    private SpriteRenderer spriteRenderer;
    private float waitTime;
    private float startWaitTime = 2;
    public GameObject Araceli;



    // Start is called before the first frame update
    void Start()
    {
        
        start = transform.position;
        end = target.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        waitTime = startWaitTime;

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, velocidad * Time.deltaTime);

        if (transform.position == target.position)
        {
            if (waitTime<=0)
            {
                if (target.position == start)
                {
                    target.position = end;
                    spriteRenderer.flipX = false;

                }
                else
                {
                    target.position = start;
                    spriteRenderer.flipX = true;

                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
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

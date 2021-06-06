using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AraceliMovements : MonoBehaviour
{
    public float Speed;
    public float JumpForce;


    private SpriteRenderer spriteRenderer;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public GameObject panel;
    public GameObject arma;
    public Transform inicio;
    Reloj tiempo;
    
    

    public bool betterJump = false;
    public float fallMultiplayer = 0.5f;
    public float lowJumpMultiplayer = 1f;
    Vector2 posicionInicial;

    public AudioSource audio;
    public GameObject gameController;

    public UnityEngine.UI.Image telaNegra;
    float valorAlfaTelaNegra;

  



    void Start()
    {
        audio = GetComponent<AudioSource>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        tiempo = GameObject.FindGameObjectWithTag("Tiempo").GetComponent<Reloj>();
        gameController = GameObject.FindGameObjectWithTag("GameController");

        telaNegra.color = new Color(0, 0, 0, 1);
        valorAlfaTelaNegra = 0;

        
    }

    private void Update()
    {
        
    }

    void FixedUpdate()
    {
        arma.SetActive(false);

        //Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);

               
         if (Input.GetKey("d") || Input.GetKey("right"))
         {
            Rigidbody2D.velocity = new Vector2(Speed, Rigidbody2D.velocity.y);
            spriteRenderer.flipX = false;
            Animator.SetBool("Run", true);
         } 

         else if (Input.GetKey("a") || Input.GetKey("left"))
         {
            Rigidbody2D.velocity = new Vector2(-Speed, Rigidbody2D.velocity.y);
            spriteRenderer.flipX = true;
            Animator.SetBool("Run", true);
            }
         else
         {
            Rigidbody2D.velocity = new Vector2(0, Rigidbody2D.velocity.y);
            Animator.SetBool("Run", false);
         }

         if (Input.GetKey("up") && CheckGround.isGrounded || Input.GetKey("w") && CheckGround.isGrounded)
         {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, JumpForce);
            audio.Play();

         }

         if (Input.GetKey("space"))
         {
            Animator.SetTrigger("Attack");
            gameController.SendMessage("SonidoArma");
            arma.SetActive(true);
            
         }

            if (CheckGround.isGrounded == false)
         {
            Animator.SetBool("Jump", true);
            Animator.SetBool("Run", false);
         }

         if (CheckGround.isGrounded == true)
         {
            Animator.SetBool("Jump", false);
            Animator.SetBool("Fall", false);

         }

          if (Rigidbody2D.velocity.y < 0)
          {
            Animator.SetBool("Fall", true);
          }
            else if (Rigidbody2D.velocity.y > 0)
         {
            Animator.SetBool("Fall", false);
            }

      
            if (betterJump)
            {
             if (Rigidbody2D.velocity.y<0)
                {
                Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplayer)*Time.deltaTime;
             }

             if (Rigidbody2D.velocity.y>0 && !Input.GetKeyDown(KeyCode.UpArrow))
              {
                Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplayer) * Time.deltaTime;
             }
        

        float valorAlfa = Mathf.Lerp(telaNegra.color.a, valorAlfaTelaNegra, .01f);
        telaNegra.color = new Color(0, 0, 0, valorAlfa);
        }

    }
    public void Reset()
    {
        posicionInicial = transform.position;
    }
    public void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }

    public void Respawn()
    {
        this.transform.position = inicio.position;
        telaNegra.color = new Color(0, 0, 0, 1);
        valorAlfaTelaNegra = 0;
    }

    public void IniciarFadeOut()
    {
        valorAlfaTelaNegra = 1;
    }


    IEnumerator Espera()
    {
        yield return new WaitForSeconds(5f);

    }

   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag ("Acido"))
        {
            
            PointsController.vida--;
            StartCoroutine("Espera");
            IniciarFadeOut();

        
            if (PointsController.vida >= 0)
            {
                Respawn();
            }
          

            else
            {
                PointsController.vida++;
                GetComponentInChildren<ParticleSystem>().Play();
                GetComponentInChildren<ParticleSystem>().transform.parent = null;
                Destroy(gameObject);
                tiempo.Pausar();
                panel.SetActive(true);
            }
            

        }


    }
    
 
}

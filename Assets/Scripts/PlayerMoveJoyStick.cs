using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoyStick : MonoBehaviour
{

    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    public Joystick joystick;

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
        if (horizontalMove>0)
        {
            spriteRenderer.flipX = false;
            Animator.SetBool("Run", true);
        }

        else if (horizontalMove<0)
        {
            spriteRenderer.flipX = true;
            Animator.SetBool("Run", true);
        }
        else
        {
            Animator.SetBool("Run", false);
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

    }

    void FixedUpdate()
    {
        arma.SetActive(false);

        horizontalMove = joystick.Horizontal * Speed;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * Speed;

        float valorAlfa = Mathf.Lerp(telaNegra.color.a, valorAlfaTelaNegra, .01f);
        telaNegra.color = new Color(0, 0, 0, valorAlfa);

    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, JumpForce);
        }


    }

    public void Attack()
    {
        Animator.SetTrigger("Attack");
        arma.SetActive(true);
    }

    public void Reset()
    {
        posicionInicial = transform.position;
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
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Acido"))
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

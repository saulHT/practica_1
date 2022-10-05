using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour
{
    menu menus;

     const string ARMA_ESPADA= "espada";
     const string ARMA_Disparo= "pistola";

       float tiempoCatana =0;
       bool  atacaCatana=false ;

    SpriteRenderer sp;
    Rigidbody2D rb;
    Animator animator;

    public int velocidad = 0;
    public int defaulvelocidad = 10;
    [Range(1, 10)]
    public float jumFor = 10;

   // public float JumFor = 30;
    bool puedeSaltar = true;

    public GameObject bala;
    public GameObject lefbala;

    private float timer = 0;
    private bool contar = false;

    //->1 balas
    //->2 espada

    private string arma=ARMA_Disparo;

    private int animacion_quieto = 0;
    private int animacion_saltar = 1;
    private int animacion_correr = 2;
    private int animacion_deslizar = 3;
    private int animacion_escalera = 4;
    private int animacion_ataca = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        menus = FindObjectOfType<menu>();
    }

    // Update is called once per frame
    void Update()
    {
        //  rb.velocity = new Vector2(0, rb.velocity.y);
        //  changeAnimation(animacion_quieto);

        if (atacaCatana)
        {
            tiempoCatana += Time.deltaTime;
        }
        if (tiempoCatana >= 0.5)
        {
            tiempoCatana = 0;
            atacaCatana = false;
            Debug.Log("resetear katana");
        }
        Debug.Log(arma);
        mover();
      //  Timer();

       

        if (Input.GetKeyDown(KeyCode.X))
        {
            StartTimer();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            StopTimer();
            Debug.Log(timer);
            ResetTimer();
        }
     //   if (Input.GetKey(KeyCode.LeftArrow))
     //   {
        //    rb.velocity = new Vector2(-6, rb.velocity.y);
         //   sp.flipX = true;
         //   changeAnimation(animacion_correr);

       // }

       // if (Input.GetKey(KeyCode.RightArrow))
       // {
          //  rb.velocity = new Vector2(6, rb.velocity.y);
          //  sp.flipX = false;
          //  changeAnimation(animacion_correr);
      //  }

      //  if (Input.GetKeyUp(KeyCode.Space) && puedeSaltar)
        //   {
          //  rb.AddForce(new Vector2(0, JumFor), ForceMode2D.Impulse);
          //  rb.AddForce(Vector2.up * JumFor, ForceMode2D.Impulse);
             // changeAnimation(animacion_saltar);
        // }
    }

    private void ResetTimer()
    {
        timer = 0;
    }

    private void StopTimer()
    {
        contar = false;
    }

    private void StartTimer()
    {
        contar = true;
    }

    private void Timer()
    {
        if (contar)
            timer += Time.deltaTime;
    }

    private void mover()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            walkToLeft();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            stopWalk();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //velocidad = defaulvelocidad;
            walkToRight();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            velocidad = 0;
        }

        walk();
        BestJump();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void BestJump()
    {
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity*(2.5f-1)*Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity*(2f-1)*Time.deltaTime;
        }
    }

    public void Jump()
    {
        changeAnimation(animacion_saltar);
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.velocity += Vector2.up * jumFor;
    }

    private void walk()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if (velocidad < 0)
        {
            sp.flipX = true;
        }
        if (velocidad > 0)
        {
            sp.flipX = false;
        }
    }

    public void stopWalk()
    {
        velocidad = 0;
        changeAnimation(animacion_quieto);
    }

    public void walkToRight()
    {
        velocidad = defaulvelocidad;
        changeAnimation(animacion_correr);
    }

    public void walkToLeft()
    {
        changeAnimation(animacion_correr);
        velocidad = -defaulvelocidad;
    }
    public void cambioArma()
    {
        if (arma==ARMA_Disparo)
        {
            menus.TextArmaKatana();
            arma = ARMA_ESPADA;
        }
       else if (arma==ARMA_ESPADA)
        {
            menus.TextArmaDisparo();
            arma = ARMA_Disparo;
        }
    }
    public void ataque()
    {
        //  var balas = sp.flipX ? lefbala : bala;
        // var position =transform.position+ new Vector3(3,0,0);
        //var position = new Vector2(transform.position.x, transform.position.y);
        //var rotacion = bala.transform.rotation;
        //Instantiate(balas, position, rotacion);

        if (arma==ARMA_Disparo)
        {
             var balas = sp.flipX ? lefbala : bala;
          
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotacion = bala.transform.rotation;
            Instantiate(balas, position, rotacion);


        }
        if (arma==ARMA_ESPADA)
        {
            Debug.Log("espada");
            //   tiempoCatana += Time.deltaTime;
            changeAnimation(animacion_ataca);
            atacaCatana = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="enemigo" && atacaCatana)
        {
            //destroy
            atacaCatana = false;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        puedeSaltar = true;
    }
    void changeAnimation(int animation)
    {
        animator.SetInteger("estado", animation);
    }
}

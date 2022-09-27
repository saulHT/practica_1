using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mega : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator animator;
    public GameObject bala;
    public GameObject bala2;
    public GameObject bala3;
    public float JumFor = 30;

    Color cambioColor = new Color(0,0,0);
    Color temp = new Color(112f,166f,90f,255f);

    bool puedeSaltar = true;
    float tiempoDisparo = 0;
    float velocidad = 10;

    private int animacion_quieto = 0;
    private int animacion_cargar = 1;
    private int animacion_dispara = 2;
    private int animacion_run = 3;
    private int animacion_salta = 4;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
        changeAnimation(animacion_quieto);
        gameObject.GetComponent<Renderer>().material.color = Color.white;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-6, rb.velocity.y);
            sp.flipX = true;
            changeAnimation(animacion_run);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(6, rb.velocity.y);
            sp.flipX = false;
            changeAnimation(animacion_run);


        }
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            rb.AddForce(new Vector2(0, JumFor), ForceMode2D.Impulse);
            changeAnimation(animacion_salta);
            puedeSaltar = false;
        }

        if (Input.GetKey(KeyCode.X))
        {
            Debug.Log("cargando.....");
            tiempoDisparo += Time.deltaTime;
            //  Debug.Log(Time.deltaTime);
            gameObject.GetComponent<Renderer>().material.color = Color.red;
           // sp.enabled = !sp.enabled;
            changeAnimation(animacion_cargar);
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            if (tiempoDisparo < 3)
            {
                var balas = sp.flipX ? bala : bala;
                // var position =transform.position+ new Vector3(3,0,0);
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotacion = bala.transform.rotation;
                Instantiate(balas, position, rotacion);
                changeAnimation(animacion_dispara);
                Debug.Log("bala 1");
            }
            if (tiempoDisparo < 5 && tiempoDisparo > 3)
            {
                var balas = sp.flipX ? bala2 : bala2;
                // var position =transform.position+ new Vector3(3,0,0);
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotacion = bala.transform.rotation;
                Instantiate(balas, position, rotacion);
                changeAnimation(animacion_dispara);
                Debug.Log("bala 2");
            }
            if ( tiempoDisparo > 5)
            {
                var balas = sp.flipX ? bala3 : bala3;
                // var position =transform.position+ new Vector3(3,0,0);
                var position = new Vector2(transform.position.x, transform.position.y);
                var rotacion = bala.transform.rotation;
                Instantiate(balas, position, rotacion);
                changeAnimation(animacion_dispara);
                Debug.Log("bala 3");
            }
            tiempoDisparo = 0;
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

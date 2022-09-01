using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;
    bool activa = true;
    public float JumFor = 30;
    private Vector3 laPositionCkeckpoint;

    private bool dobleSalto;
    private bool grounded;

    public Transform GroundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int animacion_quieto = 0;
    private int animacion_caminar = 1;
    private int animacion_correr = 2;
    private int animacion_saltar = 3;
    private int animacion_atacar = 4;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, whatIsGround);
    }
    // Update is called once per frame

    void Update()
    {
        if (grounded)
            dobleSalto = false;

        rb.velocity = new Vector2(0,rb.velocity.y);
        changeAnimation(animacion_quieto);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-6,rb.velocity.y);
            sprite.flipX = true;
            changeAnimation(animacion_caminar);
        }
        if (Input.GetKey(KeyCode.LeftArrow)&& Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(-10, rb.velocity.y);
            sprite.flipX = true;
            changeAnimation(animacion_correr);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(6, rb.velocity.y);
            sprite.flipX = false;
            changeAnimation(animacion_caminar);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.X))
        {
            rb.velocity = new Vector2(10, rb.velocity.y);
            sprite.flipX = false;
            changeAnimation(animacion_correr);
        }

        //   if (Input.GetKeyUp(KeyCode.Space))
        //   {
        // rb.AddForce(new Vector2(0, jumFor), ForceMode2D.Impulse);
        //     rb.AddForce(Vector2.up * JumFor, ForceMode2D.Impulse);
        //      changeAnimation(animacion_saltar);
        //  }


        if (Input.GetKeyDown(KeyCode.Space)&& !dobleSalto && !grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x,JumFor);
            dobleSalto = true;
        }
         if (Input.GetKeyDown(KeyCode.Space) &&  !grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumFor);
            
        }

        if (Input.GetKey(KeyCode.Z))
        {
            changeAnimation(animacion_atacar);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name=="A")
        {
            transform.position = laPositionCkeckpoint;
            Debug.Log("A");
        }
        if (collision.gameObject.name=="B")
        {
            Debug.Log("B");
            transform.position = laPositionCkeckpoint;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activa==true)
        {
            if (collision.gameObject.tag == "1")
            {
                Debug.Log("aparece 1");
                laPositionCkeckpoint = transform.position;
            }
        }
        
        if (collision.gameObject.tag=="2")
        {
            Debug.Log("aparece 2");
            laPositionCkeckpoint = transform.position;
            activa = false;
            Debug.Log("desactiva 1");
        }
    }

    void changeAnimation(int animation)
    {
        animator.SetInteger("estado",animation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaFe : MonoBehaviour
{
    SpriteRenderer sp;
    Rigidbody2D rb;
    Animator animator;

    public float JumFor = 30;
    bool puedeSaltar = true;

    private int animacion_quieto = 0;
    private int animacion_correr = 1;
    private int animacion_saltar = 2;
    private int animacion_escalera = 3;
    private int animacion_desliza = 4;
    private int animacion_muere = 5;
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


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-6, rb.velocity.y);
            sp.flipX = true;
            changeAnimation(animacion_correr);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(6, rb.velocity.y);
            sp.flipX = false;
            changeAnimation(animacion_correr);
        }

        if (Input.GetKeyUp(KeyCode.Space) && puedeSaltar)
        {
            rb.AddForce(new Vector2(0, JumFor), ForceMode2D.Impulse);
            //  rb.AddForce(Vector2.up * JumFor, ForceMode2D.Impulse);
            changeAnimation(animacion_saltar);
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

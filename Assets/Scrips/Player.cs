using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    SpriteRenderer sprite;
    Animator animator;

    public float JumFor = 30;

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

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0,rb.velocity.y);
        changeAnimation(animacion_quieto);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-6,rb.velocity.y);
            changeAnimation(animacion_caminar);
            sprite.flipX = true;
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

        if (Input.GetKeyUp(KeyCode.Space))
        {
           // rb.AddForce(new Vector2(0, jumFor), ForceMode2D.Impulse);
            rb.AddForce(Vector2.up * JumFor, ForceMode2D.Impulse);
            changeAnimation(animacion_saltar);
        }
        if (Input.GetKey(KeyCode.Z))
        {

            changeAnimation(animacion_atacar);
        }
    }

    void changeAnimation(int animation)
    {
        animator.SetInteger("estado",animation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    bool estado;
    public int velocidadx = 3;
    public int velocidady = -3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
            //rb.velocity = new Vector2(3, 0);
        if (estado==true)
        {
            spriteRenderer.flipX = false;
            rb.velocity = new Vector2(3, 0);
        }
        if (estado==false)
        {
            spriteRenderer.flipX = true;
            rb.velocity = new Vector2(-3, 0);
        }
        
    }

    private void  OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="q")
        {
            rb.velocity = new Vector2(-3,0);
            estado = true;
            Debug.Log("izquierda");
        }
        if (collision.gameObject.tag == "w")
        {
            // spriteRenderer.flipX = false;
            // rb.velocity = new Vector2(3,0);
            estado = false;
            Debug.Log("derecha");

        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    bool estado;
    public int velocidad= 3;
    public int velocidady = -3;
    int vidas=5;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (estado == false)
      //  {
      //      spriteRenderer.flipX = false;
      //  }
      //  if (estado==true)
      //  {
      //      spriteRenderer.flipX = true;
      //  }
        
           
            rb.velocity = new Vector2(-velocidad, 0);
        spriteRenderer.flipX = true;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="1")
        {
        //    Debug.Log("bala1....collision");
           // vidas--;
           // Debug.Log(vidas);
           
           // if (vidas==2)
          //  {
             //   Destroy(this.gameObject);
            //    Destroy(gameObject);
           // }
        }
        if (collision.gameObject.tag == "2")
        {
         //   Debug.Log("bala2..collision");
         //   vidas = vidas - 3;
          //  if (vidas<=0)
          //  {
          //      Destroy(this.gameObject);
          //  }
        }
        if (collision.gameObject.tag == "3")
        {
          //  Debug.Log("bala3..collision");
         ///   vidas = vidas - 6;
          //  if (vidas<=0)
         //   {
          //      Destroy(gameObject);
          //      Destroy(this.gameObject);
           // }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "q")
        {
           // rb.velocity = new Vector2(-velocidad, 0);
            velocidad = -4;
            //  spriteRenderer.flipX = true;
            estado = true;
            Debug.Log("izquierda");
        }
        if (collision.gameObject.tag == "w")
        {
            //spriteRenderer.flipX = false;
            velocidad = 4;
            estado = false;
           // rb.velocity = new Vector2(velocidady, 0);
            Debug.Log("derecha");

        }
    }
}

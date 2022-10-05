using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private menu menu;
    Rigidbody2D rb;
    private Score score;
    public int velocidad = 10;
    int vida=1;
    //int contador2=0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 1);
        menu = FindObjectOfType<menu>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidad, 0);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "z")
        {
          //  menu.PuntajeEnemigo(1);
            //     Destroy(this.gameObject);
            //    contador2++;
            // Debug.Log("...collision bala1 ");
            Debug.Log("...collision bala1 " + vida);
            vida--;
            if (vida < 1)
            {
                menu.PuntajeEnemigo(1);
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "z")
        {
            //     Destroy(this.gameObject);
            //    contador2++;
           // Debug.Log("...collision bala1 ");
            Debug.Log("...collision bala1 "+vida);
            vida--;
            if (vida <=0)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }

        }
     }
       
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Game Game;
    Rigidbody2D rb;
    private Score score;
    public int velocidad = 10;
    int vida=2;
    //int contador2=0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2);
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidad, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "A")
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

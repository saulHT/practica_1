using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala2 : MonoBehaviour
{
    Rigidbody2D rb;
    private Score score;
    public int velocidad = 10;
    int vida = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
        score = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocidad, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="B")
        {
           
            vida--;
            Debug.Log("...collision bala2 " + vida);
            if (vida<0)
            {
                Destroy(this.gameObject);
                Destroy(gameObject);
            }
           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Game Game;
    Rigidbody2D rb;
    private Score score;
    public int velocidad = 30;
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
        if (collision.gameObject.tag=="z")
        {
            Debug.Log("muerte zombi");
            Destroy(collision.gameObject);
            score.PlusScorte(10);
            score.SaveGame();
            Destroy(this.gameObject);
          //  Game.PerderVida(1);
        }
    }
}

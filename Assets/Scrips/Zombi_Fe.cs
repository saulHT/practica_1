using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi_Fe : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sp;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

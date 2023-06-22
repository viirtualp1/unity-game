using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    private Transform Player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Flip();
    }

    void Flip()
    {
        if (Player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (Player.position.x > transform.position.x)
        {    
            transform.localScale = new Vector2(-1, 1);
        }
    }
}

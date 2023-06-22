using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

    }

    void FlipEnemy()
    {
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (player.position.x > transform.position.x)
        {    
            transform.localScale = new Vector2(-1, 1);
        }
    }
}

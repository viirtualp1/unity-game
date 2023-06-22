using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform player;

    public float speed;
    public float agrDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float distTopPlayer = Vector2.Distance(transform.position, player.position);
    
        if (distTopPlayer < agrDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }

    void StartHunting()
    {
        if (player.position.x < transform.position.x)
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        else if (player.position.x > transform.position.x)
        {    
            rb.velocity = new Vector2(-speed, 0);
        }
    }

    void StopHunting()
    {
        rb.velocity = new Vector2(0, 0);
    }
}

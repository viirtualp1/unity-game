using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform Player;
    [SerializeField] private float speed;
    [SerializeField] private float agrDistance;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckMilfHunter();
    }

    void CheckMilfHunter()
    {
        float distTopPlayer = Vector2.Distance(transform.position, Player.position);
    
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
        if (isGrounded() == true){
            if (Player.position.x < transform.position.x)
            {
                rb.velocity = new Vector2(-speed, 0);
            }
            else if (Player.position.x > transform.position.x)
            {    
                rb.velocity = new Vector2(speed, 0);
            }
        }       
    }

    void StopHunting()
    {
        rb.velocity = new Vector2(0, 0);
    }

    private bool isGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}

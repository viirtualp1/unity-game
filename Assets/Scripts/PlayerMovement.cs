using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float speed = 6f;
    [SerializeField] private float jumpingScale = 12f;
    private float horizontalAxis;
    private bool isFacingRight = true;

    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float mx = 0;
    public float dashDistance = 15f;
    private bool isDashing = false;
    private float doubleTapTime = 0f;
    private KeyCode lastKeyCode;

    private void Update() {
        mx = Input.GetAxis("Horizontal");

        Movement();
        Dash();
        Jump();
    }

    private void Dash() {
        if (Input.GetKeyDown(KeyCode.D)) {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A) {
                StartCoroutine(PlayerDash(1f));
            } else {
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.A;
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            if (doubleTapTime > Time.time && lastKeyCode == KeyCode.A) {
                StartCoroutine(PlayerDash(-1f));
            } else {
                doubleTapTime = Time.time + 0.5f;
            }

            lastKeyCode = KeyCode.A;
        }      
    }

    IEnumerator PlayerDash (float direction) {
        isDashing = true;
        playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 0f);
        playerRigidBody.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = playerRigidBody.gravityScale;
        playerRigidBody.gravityScale = 0;
        yield return new WaitForSeconds(0.4f);
        isDashing = false;
        playerRigidBody.gravityScale = gravity;
    }

    private void FixedUpdate() {
        if (!isDashing) {
            playerRigidBody.velocity = new Vector2(mx * speed, playerRigidBody.velocity.y);
        }

        playerRigidBody.velocity = new Vector2(horizontalAxis * speed, playerRigidBody.velocity.y);    
    }

    public void Movement() {
        horizontalAxis = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private bool isGrounded() {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    
    private void Jump() {
        if (Input.GetButtonDown("Jump") && isGrounded()) {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, jumpingScale);
        }

        if (Input.GetButtonUp("Jump") && playerRigidBody.velocity.y > 0f) {
            playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.y * 0.5f);
        }
    }

    private void Flip() {
        if (isFacingRight && horizontalAxis < 0f || !isFacingRight && horizontalAxis > 0f) {
            isFacingRight = !isFacingRight;

            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            
            transform.localScale = localScale;
        }
    }
}
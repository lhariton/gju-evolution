using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;

    public float speed = 8f;

    public float jumpingPower = 16f;

    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        //jump if on ground
        var jump = Input.GetButtonDown("Jump");
        if (jump && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        //jump if in air
        jump = Input.GetButtonUp("Jump");
        if (jump && rb.velocity.y > 0f)
        {
            float slowerJump = rb.velocity.y * 0.5f;
            rb.velocity = new Vector2(rb.velocity.x, slowerJump);
        }

        Flip();
    }

    void FixedUpdate() {
        float x = horizontal * speed;
        float y = rb.velocity.y;
        rb.velocity = new Vector2(x, y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f
            || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public IEnumerator Knockback(float knockDuration, float knockbackPower, Vector3 knockbackDirection) {
        float timer = 0;
        // Debug.Log("knockback");
        while (knockDuration > timer) {
            timer += Time.deltaTime;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector3(knockbackDirection.x * -200, knockbackDirection.y * knockbackPower, transform.position.z));
            //TODO add damage animation + sound
        }

        yield return 0;
    }
}

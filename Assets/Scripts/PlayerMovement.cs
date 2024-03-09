using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;

    public float speed = 16f;

    public float jumpingPower = 32f;

    private bool isFacingRight = false;
    private bool isGrounded;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public Animator animator;
   

    [SerializeField] private AudioClip jumpAudioClip;
    [SerializeField] private AudioClip moveAudioClip;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //jump if on ground
        var jump = Input.GetButtonDown("Jump");
        
        if (jump && IsGrounded())
        {
            animator.SetBool("isJump", true);
            // Debug.Log("jump true");
            SoundFXManager.instance.PlaySoundFXClip(jumpAudioClip, transform, 1f);
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

        var wasGrounded = isGrounded;
        isGrounded = false;
        if(IsGrounded())
        {
            isGrounded = true;
            if(!wasGrounded)
            {
                animator.SetBool("isJump", false);
                // Debug.Log("jump false");

            }
        }
        //TODO
        //SoundFXManager.instance.PlaySoundFXClip(moveAudioClip, transform, 1f);
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
        // Color originColor = spriteRenderer.color;

        // tint the sprite with damage color
        // spriteRenderer.color = Color.red;

        // spriteRenderer.color = Color.Lerp(Color.red, originColor, knockDuration);
        // Debug.Log("knockback");
        while (knockDuration > timer) {
            timer += Time.deltaTime;
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector3(knockbackDirection.x * -100, knockbackDirection.y * knockbackPower, transform.position.z));
            //TODO add damage animation + sound
        }
        // spriteRenderer.color = originColor;

        yield return 0;
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileShoot : MonoBehaviour
{
    public PlayerHealth playerHealth;
    private Rigidbody2D rb;
    public float angle;
    public float speed;
    public bool isWave;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float angleRadians = angle * Mathf.Deg2Rad;
        Vector2 velocityDirection = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));
        rb.velocity = velocityDirection.normalized * speed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Debug.Log("collision.gameObject.tag " + collision.gameObject.tag);
        // Debug.Log("gameObject.tag " + gameObject.tag);
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth.takeDamage(1);
            Debug.Log("playerHealth.health " + playerHealth.health);
            if (!isWave)
            {
                Destroy(gameObject);

            }
        }
    }
}

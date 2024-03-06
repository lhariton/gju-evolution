using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision with player detected!");
            Debug.Log("Health: " + health);
            health -= 1;
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        // Call your function or perform actions
    //        Debug.Log("Collision with player detected!");
    //        Debug.Log("Health: "+health);
    //        health -= 1;
    //    }
    //}
}

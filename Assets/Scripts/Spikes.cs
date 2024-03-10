using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("SPIKE!");
            playerHealth.takeDamage(1);
            StartCoroutine(playerMovement.Knockback(0.03f, 6, playerMovement.transform.position));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private AudioClip dmgAudioClip;
    [SerializeField] private AudioClip deathAudioClip;
    // Start is called before the first frame update
    public float health = 3;
    public Animator animatorPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            animatorPlayer.SetBool("isLevelDone", true);
            SoundFXManager.instance.PlaySoundFXClip(dmgAudioClip, transform, 1f);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //StartCoroutine(playerMovement.Knockback(0.03f, 350, playerMovement.transform.position));
            Debug.Log("Collision with player detected!");
            SoundFXManager.instance.PlaySoundFXClip(dmgAudioClip, transform, 1f);
            health -= 1;
            Debug.Log("Health: " + health);
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

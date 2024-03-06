using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioClip dmgAudioClip;
    [SerializeField] private AudioClip deathAudioClip;
    public int health=10;
    //TODO add health bar
    // public TextMeshProUGUI textBox;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // textBox.text = "HEALTH: " + health;
        if(health==0)
        {
            SoundFXManager.instance.PlaySoundFXClip(dmgAudioClip, transform, 1f);
            SceneManager.LoadSceneAsync("DeathScene");

        }

    }

    public void takeDamage(int damage)
    {
        SoundFXManager.instance.PlaySoundFXClip(dmgAudioClip, transform, 1f);
        health -=damage;
    }
}

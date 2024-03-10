using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private AudioClip dmgAudioClip;
    [SerializeField] private AudioClip deathAudioClip;
    private SpriteRenderer spriteRenderer;

    public int health=10;
    //TODO add health bar
    // public TextMeshProUGUI textBox;

    public void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public IEnumerator flashRed() {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = Color.white;
    }

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
        StartCoroutine(flashRed());
        health -=damage;
        PlayerStats.Instance.TakeDamage(1);

    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public int health=10;
    public TextMeshProUGUI textBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textBox.text = "HEALTH: " + health;
        if(health<0)
        {
            SceneManager.LoadSceneAsync("DeathScene");

        }

    }
}

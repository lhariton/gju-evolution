using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPermaMove : MonoBehaviour
{
    public float speed;

    [SerializeField] public Rigidbody2D bossLevel;

    [SerializeField] public GameObject bossLevelPlatform;
    [SerializeField] public GameObject newPlatform1;
    [SerializeField] public GameObject newPlatform2;
    [SerializeField] public GameObject newPlatform3;
    [SerializeField] public GameObject newPlatform4;
    [SerializeField] public GameObject newPlatform5;
    [SerializeField] public GameObject newPlatform6;
    [SerializeField] public GameObject spawner;

    [SerializeField] public GameObject oldPlatform1;
    [SerializeField] public GameObject oldPlatform2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var positionY = transform.position.y;
        // Debug.Log(positionY);
        if (positionY > bossLevel.transform.position.y)
        {
            // Debug.Log("stopped at boss");
            ActivateBossLevel();
            DisableLevelPlatforms();
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void DisableLevelPlatforms()
    {
        oldPlatform1.SetActive(false);
        oldPlatform2.SetActive(false);
    }

    private void ActivateBossLevel()
    {
        bossLevelPlatform.SetActive(true);
        newPlatform1.SetActive(true);
        newPlatform2.SetActive(true);
        newPlatform3.SetActive(true);
        newPlatform4.SetActive(true);
        newPlatform5.SetActive(true);
        newPlatform6.SetActive(true);
        spawner.SetActive(true);


        // to send projectiles only in boss fight
        var spawnerScript = spawner.GetComponent<SpawnerScript>();
        spawnerScript.isBossFight = true;
    }
}

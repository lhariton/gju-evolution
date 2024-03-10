using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraPermaMove : MonoBehaviour
{
    public float speed;

    private bool gracePeriodOver = false;

    [SerializeField] public Rigidbody2D bossLevel;

    // [SerializeField] public GameObject hpCanvas;

    [SerializeField] public GameObject bossLevelPlatform;
    [SerializeField] public GameObject newPlatform1;
    [SerializeField] public GameObject newPlatform2;
    [SerializeField] public GameObject newPlatform3;
    [SerializeField] public GameObject newPlatform4;
    [SerializeField] public GameObject newPlatform5;
    [SerializeField] public GameObject newPlatform6;
    [SerializeField] public GameObject newPlatform7;
    [SerializeField] public GameObject newPlatform11;
    [SerializeField] public GameObject newPlatform21;
    [SerializeField] public GameObject newPlatform31;
    [SerializeField] public GameObject newPlatform41;
    [SerializeField] public GameObject newPlatform51;
    [SerializeField] public GameObject newPlatform61;
    [SerializeField] public GameObject newPlatform71;
    [SerializeField] public GameObject spawner;

    [SerializeField] public GameObject oldPlatform1;
    [SerializeField] public GameObject oldPlatform2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        if (gracePeriodOver)
        {
            moveCamera();
        }
    }

    private void moveCamera()
    {
        var positionY = transform.position.y;
        // Debug.Log(positionY);
        if (positionY > bossLevel.transform.position.y)
        {
            // Debug.Log("stopped at boss");
            ActivateBossLevel();
            DisableLevelPlatforms();
            Camera.main.orthographicSize = 380f;
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }

    public IEnumerator wait() {
        yield return new WaitForSeconds(3);
        gracePeriodOver = true;
    }

    private void DisableLevelPlatforms()
    {
        oldPlatform1.SetActive(false);
        oldPlatform2.SetActive(false);
    }

    private void ActivateBossLevel()
    {
        bossLevelPlatform.SetActive(true);

        var activeScene = SceneManager.GetActiveScene();
        if (!activeScene.name.Contains("3"))
        {
            spawnBossPlatforms();
        }
        spawner.SetActive(true);
        // to send projectiles only in boss fight
        var spawnerScript = spawner.GetComponent<SpawnerScript>();
        spawnerScript.isBossFight = true;
    }

    private void spawnBossPlatforms()
    {
        newPlatform1.SetActive(true);
        newPlatform2.SetActive(true);
        newPlatform3.SetActive(true);
        newPlatform4.SetActive(true);
        newPlatform5.SetActive(true);
        newPlatform6.SetActive(true);
        newPlatform7.SetActive(true);
        newPlatform11.SetActive(true);
        newPlatform21.SetActive(true);
        newPlatform31.SetActive(true);
        newPlatform41.SetActive(true);
        newPlatform51.SetActive(true);
        newPlatform61.SetActive(true);
        newPlatform71.SetActive(true);
    }
}

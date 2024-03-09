using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;

    private int maxScenes = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkGameState();


        var activeScene = SceneManager.GetActiveScene();
        var bossOnLevel = isBossOnLevel(activeScene);
        if (!bossOnLevel)
        {
            playerVictory(activeScene);
            StartCoroutine(playerVictory(activeScene, 7f));
        }
    }

    private bool isBossOnLevel(Scene activeScene) {
        var isBossAlive = false;
        var bosses = GameObject.FindGameObjectsWithTag("Boss");
        foreach (var coin in bosses) {
            if (coin.scene == activeScene) {
                isBossAlive = true;
            }
        }

        return isBossAlive;
    }

    IEnumerator playerVictory(Scene activeScene, float delay) {
        yield return new WaitForSeconds(delay);

        
        changLevel(activeScene);
    }

    private void changLevel(Scene activeScene) {
        int currenSceneIndex = activeScene.buildIndex;
        if (currenSceneIndex > 0) {
            int nextScene = currenSceneIndex + 1;
            String nextLevel = "Level" + nextScene.ToString();

            print("nextScene:" + nextScene);
            print("activeScene:" + activeScene.ToString());
            print("activeIndex:" + currenSceneIndex);
            // print("maxScenes:" + maxScenes);

            if (nextScene <= maxScenes) {
                // PauseGame();
                SceneManager.LoadScene(nextLevel);
            } else {
                print("GG WP");
                SceneManager.LoadScene("Credits");
            }
        }
    }

    private void playerVictory(Scene activeScene) {
        GameObject player = getPlayer(activeScene);
        if (player != null) {
            // player.GetComponent<ParticleSystem>().Emit(20);
            if (activeScene.buildIndex == 1)
            {
                player.GetComponent<Animator>().Play("Omida_Transform");
            } else if (activeScene.buildIndex == 2)
            {
                player.GetComponent<Animator>().Play("Cocon_Transform");

            }
        }
    }


    private GameObject getPlayer(Scene activeScene) {
        var players = GameObject.FindGameObjectsWithTag("Player");
        return players.FirstOrDefault(player => player.scene == activeScene);
    }

    private void checkGameState() {
        if (Input.GetKeyDown("escape")) {
            var timeScale = Time.timeScale;
            print(timeScale);
            if (timeScale == 0) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }


    private void PauseGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    private void ResumeGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}

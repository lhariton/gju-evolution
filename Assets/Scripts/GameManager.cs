using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkGameState();
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

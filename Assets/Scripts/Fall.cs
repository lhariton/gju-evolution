using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    [SerializeField] public Rigidbody2D player;
    [SerializeField] public Camera camera;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var positionY = camera.transform.position.y;
        Debug.Log(positionY + " : " + player.transform.position.y);
        if (positionY - 250 > player.transform.position.y) {
            // Debug.Log("works");
            SceneManager.LoadSceneAsync("DeathScene");
        }
    }
}
  
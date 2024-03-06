using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class SpawnPoints
{
    public GameObject projectile;
    public Transform spawnPoint;
    public float nextSpawn;
    public float angle;
    public float speed;
}

public class SpawnerScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public SpawnPoints[] spawnPoints;
    public bool isBossFight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBossFight)
        {
            SpawnProjectile();
        }
    }
    
    void SpawnProjectile()
    {
        // for spawning all at different random tmes
       
        foreach (SpawnPoints sp in spawnPoints)
        {
            if(sp.nextSpawn < Time.time)
            {
                GameObject currentProjectile = sp.projectile;
                Transform spawn = sp.spawnPoint;
                GameObject InstantiatedProjectile = Instantiate(currentProjectile, spawn);
                    
                float angleRadians = sp.angle * Mathf.Deg2Rad;
                Vector2 velocityDirection = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));

                Rigidbody2D rb = InstantiatedProjectile.GetComponent<Rigidbody2D>();
                rb.velocity = velocityDirection.normalized * sp.speed;

                var script = InstantiatedProjectile.GetComponent<projectileShoot>();
                script.angle = sp.angle;
                script.speed = sp.speed;
                script.playerHealth = playerHealth;


                //rnadom time between shoots, range can change
                sp.nextSpawn = Time.time + Random.Range(1.0f, 3.0f);
            }
        }

    }
}

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
[System.Serializable]

public class WaveAttack
{
    public GameObject projectile;
    public Transform spawnPoint;
    public float speed;
    public float spawnTimeForWave;

}

public class SpawnerScript : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public SpawnPoints[] spawnPoints;
    public WaveAttack waveAttack;
    public bool isBossFight;
    private float nextSpawnTimeForWave;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBossFight)
        {
            nextSpawnTimeForWave += Time.deltaTime;
            if (nextSpawnTimeForWave >= waveAttack.spawnTimeForWave)
            {
                // ifffy 
                SpawnWaveAttack();
                nextSpawnTimeForWave = 0f;


            }
            else
            {
                SpawnProjectiles();
            }
            
            
        }
    }
    
    void SpawnProjectiles()
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
                script.isWave = false;


                //rnadom time between shoots, range can change
                sp.nextSpawn = Time.time + Random.Range(1.0f, 3.0f);
            }
        }
    }
   
    void SpawnWaveAttack()
    {
        
        GameObject wave = waveAttack.projectile;
        Transform spawn = waveAttack.spawnPoint;
        GameObject InstantiatedProjectile = Instantiate(wave, spawn);

        float angleRadians = (-90) * Mathf.Deg2Rad;
        Vector2 velocityDirection = new Vector2(Mathf.Cos(angleRadians), Mathf.Sin(angleRadians));

        Rigidbody2D rb = InstantiatedProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = velocityDirection.normalized * waveAttack.speed;

        var script = InstantiatedProjectile.GetComponent<projectileShoot>();
        script.angle = -90;
        script.speed = waveAttack.speed;
        script.playerHealth = playerHealth;
        script.isWave = true;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    [SerializeField] int scorePerHit = 5;
    [SerializeField] int hitPoints = 4;
 
    ScoreBoard scoreBoard;
    GameObject parentGameObject;
    
    
    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();

        if (hitPoints < 1) 
        {
            KillEnemy();
        }
    }

    void AddRigidbody() 
    {
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void ProcessHit() 
    {
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        hitPoints--;                        //same as hitPoints = hitPoints - 1;
    }

    void KillEnemy() 
    {
        scoreBoard.IncreaseScore(scorePerHit);
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);
    }
}

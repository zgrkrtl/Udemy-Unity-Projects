using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemyFX;
    [SerializeField] GameObject HitVFX;
    GameObject parentGameObject;
    [SerializeField] int PointPerHit = 15;
    Scoreboard scoreboard;
    [SerializeField] int hitpoint = 3;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        gameObject.AddComponent<Rigidbody>();
        GetComponent<Rigidbody>().useGravity = false;
    }
    void OnParticleCollision(GameObject other)
    {
        int before = hitpoint;
        if (hitpoint < 1)
        {
            scoreboard.IncreaseScore(PointPerHit);
            GameObject vfx = Instantiate(enemyFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parentGameObject.transform;
            Destroy(gameObject);
            hitpoint = before;
        }
        else
        {
            GameObject vfx = Instantiate(HitVFX, transform.position, Quaternion.identity);
            vfx.transform.parent = parentGameObject.transform;
            hitpoint--;
        }
    }
}

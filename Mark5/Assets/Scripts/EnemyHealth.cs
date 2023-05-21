using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitPoint = 5;
    [Tooltip("EnemyHealth+=1 when they die")]
    [SerializeField] int difficultyRamp = 1;
    int CurrenthitPoints = 0;
    Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        CurrenthitPoints = maxHitPoint;
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        CurrenthitPoints--;
        if (CurrenthitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoint += difficultyRamp;
            enemy.rewardGold();
        }
    }
}

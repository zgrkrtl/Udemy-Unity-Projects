using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0f, 5f)] float speed = 1f;
    Enemy enemy;
    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(Followpath());

    }
    void FindPath()
    {
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            if (waypoint != null)
            { path.Add(waypoint); }
        }
    }
    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }
    void FinishPath()
    {
        enemy.stealGold();
        gameObject.SetActive(false);
    }
    IEnumerator Followpath()
    {
        foreach (Waypoint waypoint in path)
        {
            Vector3 StartPosition = transform.position;
            Vector3 EndPosition = waypoint.transform.position;
            float TravelPercent = 0f;

            transform.LookAt(EndPosition);
            while (TravelPercent < 1f)
            {
                TravelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(StartPosition, EndPosition, TravelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        FinishPath();

    }

}

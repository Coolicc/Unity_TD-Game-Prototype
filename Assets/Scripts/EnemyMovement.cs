using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {

    private Transform targetWaypoint;
    private int waypointIndex = 0;
    private Enemy enemy;
    public AudioSource baseReachedAudioSource;
    private bool endReached = false;
    private int waypointListIndex;

    void Start() {
        enemy = GetComponent<Enemy>();
    }

    void Update() {
        if (endReached || targetWaypoint == null) {
            return;
        }

        Vector3 direction = targetWaypoint.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, targetWaypoint.position) <= 0.5f) {
            GetNextWaypoint();
        }

        enemy.speed = enemy.startSpeed;
    }

    void GetNextWaypoint() {
        waypointIndex++;
        if (waypointIndex == WaveSpawner.waypoints[waypointListIndex].Length) {
            BaseReached();
            return;
        }
        targetWaypoint = WaveSpawner.waypoints[waypointListIndex][waypointIndex];
    }

    void BaseReached() {
        endReached = true;
        PlayerStats.Lives--;
        WaveSpawner.enemiesAlive--;
        baseReachedAudioSource.Play();
        Destroy(gameObject, 1f);
    }

    public void SetWaypointListIndex(int waypointListIndex) {
        this.waypointListIndex = waypointListIndex;
        targetWaypoint = WaveSpawner.waypoints[waypointListIndex][waypointIndex];
    }
}

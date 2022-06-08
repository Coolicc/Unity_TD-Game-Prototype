using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    public static int enemiesAlive = 0;

    [Tooltip("Array of wave arrays. Each wave array represents the current wave for each spawn point. Number of wave arrays must be the same as the number of spawn points and" +
        "the number of waypoint arrays.")]
    public WaveList[] waves;

    public Transform[] spawnPoints;

    [Tooltip("Array of waypoints parent objects that correspond to the spawn point with the same index. Size must be the same as the size of spawn points array.")]
    public GameObject[] waypointLists;

    [HideInInspector]
    public static Transform[][] waypoints;

    public Text waveCountdownText;

    public GameManager gameManager;

    public float waveCooldown = 5.5f;
    public float waveSpawnTimer = 2f;
    private int waveIndex = 0;

    void Awake() {
        waypoints = new Transform[waypointLists.Length][];

        for (int i = 0; i < waypointLists.Length; i++) {
            waypoints[i] = new Transform[waypointLists[i].transform.childCount];
            for (int j = 0; j < waypoints[i].Length; j++) {
                waypoints[i][j] = waypointLists[i].transform.GetChild(j);
            }
        }
    }

    void Update() {

        if (enemiesAlive > 0 || GameManager.gameEnded) {
            return;
        }

        if (waveIndex == waves.Length) {
            gameManager.LevelWon();
            this.enabled = false;
        }

        if (waveSpawnTimer <= 0f) {
            WaveList waveList = waves[waveIndex];
            foreach (Wave wave in waveList.wavesPerSpawn) {
                enemiesAlive += wave.count;
            }
            for (int i = 0; i < spawnPoints.Length; i++) {
                StartCoroutine(SpawnWave(spawnPoints[i], i));
            }
            waveIndex++;
            PlayerStats.wavesSurvived++;
            waveSpawnTimer = waveCooldown;
            return;
        }
        waveSpawnTimer -= Time.deltaTime;

        waveSpawnTimer = Mathf.Clamp(waveSpawnTimer, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", waveSpawnTimer);
    }

    IEnumerator SpawnWave(Transform spawnPoint, int spawnPointIndex) {

        Wave wave = waves[waveIndex].wavesPerSpawn[spawnPointIndex];
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy, spawnPoint, spawnPointIndex);
            yield return new WaitForSeconds(1f / wave.spawnRate);
        }
    }

    void SpawnEnemy(GameObject enemy, Transform spawnPoint, int spawnPointIndex) {
        GameObject enemyInst = (GameObject) Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemyMovement mov = enemyInst.GetComponent<EnemyMovement>();
        mov.SetWaypointListIndex(spawnPointIndex);
    }

    void OnEnable() {
        enemiesAlive = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Turret : MonoBehaviour {

    private Transform target;
    private Enemy targetEnemy;

    [Header("General Turret Attributes")]
    public float range = 15f;

    [Header("Bullet Settings (Default)")]
    public float fireRate = 1f;
    private float fireTimer = 0f;
    public GameObject bulletPrefab;

    [Header("Beam Settings (Optional)")]
    public bool useLaser = false;
    public float damageOverTime = 30f;
    public float slow = 0.3f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Unity Script Setup")]
    public Transform rotationJoint;
    public string enemyTag = "Enemy";
    public float rotationSpeed = 10f;
    public Transform firePoint;
    public AudioSource audioSource;

	// Use this for initialization
	void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (target == null) {
            if (useLaser) {
                lineRenderer.enabled = false;
                impactLight.enabled = false;
                impactEffect.Stop();
                audioSource.Stop();
            }
            return;
        }

        LockOnTarget();

        if (useLaser) {
            ShootLaser();
        } else {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f) {
                Shoot();
                fireTimer = 1f / fireRate;
            }
        }

	}

    void LockOnTarget() {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(rotationJoint.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        rotationJoint.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void ShootLaser() {

        targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        targetEnemy.Slow(slow);

        if (!audioSource.isPlaying) {
            audioSource.Play();
        }

        if (!lineRenderer.enabled) {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 direction = firePoint.position - target.position;
        impactEffect.transform.position = target.position + direction.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(direction);
    }

    void Shoot() {
        GameObject bulletO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletO.GetComponent<Bullet>();
        audioSource.Play();

        if (bullet != null) {
            bullet.Seek(target);
        }
    }

    void UpdateTarget() {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = Mathf.Infinity;
        GameObject closestEnemy = null;
        foreach (GameObject enemy in enemies) {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < minDistance) {
                minDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }
        if (closestEnemy != null && minDistance <= range) {
            target = closestEnemy.transform;
            targetEnemy = target.GetComponent<Enemy>();
        } else {
            target = null;
            targetEnemy = null;
        }
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

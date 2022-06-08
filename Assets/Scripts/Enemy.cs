using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [Header("Enemy Attributes")]
    public float startSpeed = 10f;
    public float maxHealth = 100f;
    public int bounty = 50;
    [HideInInspector]
    public float speed;
    private float health;
    public GameObject deathEffect;
    private bool dead = false;

    [Header("Unity Setup")]
    public Image healthBar;

    void Start() {
        speed = startSpeed;
        health = maxHealth;
    }

    public void TakeDamage(float damage) {
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0 && !dead) {
            Die();
        }
    }

    void Die() {
        dead = true;

        PlayerStats.Money += bounty;
        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.enemiesAlive--;

        Destroy(this.gameObject);
    }

    public void Slow(float slowPercent) {
        speed = startSpeed * (1f - slowPercent);
    }
}

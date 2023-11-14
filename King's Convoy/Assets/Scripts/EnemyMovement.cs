using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float startSpeed = 10f;

    [HideInInspector]
    public float speed;

    public int startHealth = 100;
    private float health;

    public int value = 20;

    public GameObject deathEffect;

    [Header("Unity Stuff")]
    public Image healthBar;

    private Transform target;
    private int wavepointIndex = 0;

    private void Start()
    {
        speed = startSpeed;
        health = startHealth;
        target = Waypoints.points[0];
    }

    public void TakeDamage(int amount)
    {
        health -= amount;

        healthBar.fillAmount = health / startHealth;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoints.points.Length - 1)
        {
            EndPath();
            return;
        }

        wavepointIndex++;
        target = Waypoints.points[wavepointIndex];
    }

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}

using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [Header("Health")]
    public float health = 50f;

    public Slider healthBar;

    [Header("Manager")]
    public LevelManager levelManager;

    void Awake()
    {
        levelManager       = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        healthBar.maxValue = health;
        healthBar.value    = health;
    }

    public void TakeDamage (string tag, float damage)
    {
        health -= (tag == "Enemy Head" ? damage * 2 : damage);
        healthBar.value = health;

        if (health <= 0f)
            Die();
    }

    void Die ()
    {
        Destroy(gameObject);
        levelManager.IncreaseTime();
    }
}

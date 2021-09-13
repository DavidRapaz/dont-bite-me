using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [Header("Health")]
    public float health = 50f;

    public Slider healthBar;

    [Header("Timer")]
    public TimerManager timeManager;

    void Start()
    {
        timeManager = GameObject.Find("TimeManager").GetComponent<TimerManager>();
        healthBar.maxValue = health;
    }

    public void TakeDamage (string tag, float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0f)
            Die();
    }

    void Die ()
    {
        Destroy(gameObject);
        timeManager.IncreaseTime();
    }
}

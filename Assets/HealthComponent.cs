using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    float health = 10;
    public float maxHealth = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    public void RemoveDamage(float heal)
    {
        health += heal;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        Debug.Log(health);
    }
}

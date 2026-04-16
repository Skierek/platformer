using System.Collections;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    float health = 10;
    public float maxHealth = 10;
    private bool invincibility;

    public delegate void OnHealthChangeHandler(float newHealth, float amountChanged);
    public event OnHealthChangeHandler OnHealthChanged;

    public delegate void OnHealthInitialisedHandler(float newHealth);
    public event OnHealthInitialisedHandler OnHealthInitialised;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnHealthInitialised?.Invoke(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if (!invincibility)
        {

            health -= damage;
            //Debug.Log(health);
            OnHealthChanged?.Invoke(health, damage);
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            invincibility = true;
            StartCoroutine(ResetInvincibility(3));
        }
    }
    IEnumerator ResetInvincibility(float resetTime)
    {
        yield return new WaitForSeconds(resetTime);
        invincibility = false;
    }
    public void RemoveDamage(float heal)
    {
        health += heal;
        OnHealthChanged?.Invoke(health, heal);
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        //Debug.Log(health);
    }
}

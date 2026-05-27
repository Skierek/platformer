using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                SceneManager.LoadScene("EndGameUI");
            }
            invincibility = true;
            StartCoroutine(ResetInvincibility(1));
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
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
        OnHealthChanged?.Invoke(health, heal);
        //Debug.Log(health);
    }
}

using UnityEngine;

public class healthPack : MonoBehaviour
{
    public float heal = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<HealthComponent>().RemoveDamage(heal);
        Destroy(this.gameObject);
    }
}

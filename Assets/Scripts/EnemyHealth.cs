using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth = 5f;
    private float currentHealth;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //play hurt animation
        }
        else
        {
            Die();
        }
    }

    public void Die()
    {
        //play death animation
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Health : MonoBehaviour
{
    private float _health;
    public float HealthValue { get => _health; }

    public float maxHealth = 10;

    [SerializeField]
    private GameObject explosion;

    void Awake()
    {
        _health = maxHealth;
    }

    void Update()
    {
        if (_health <= 0f)
        {
            var exp = Instantiate(explosion, transform.position, Quaternion.identity);
            var sprRnd = exp.GetComponent<SpriteRenderer>();

            exp.transform.localScale = transform.localScale;
            if (sprRnd != null )
            {
                sprRnd.flipX = Random.Range(0f, 100f) < 50f;
                sprRnd.flipY = Random.Range(0f, 100f) < 50f;
            }

            Destroy(gameObject);
        }
    }

    public void IncrementHealth(float amount)
    {
        _health += amount;

        if (_health > maxHealth)
        {
            _health = maxHealth;
        }
    }

    public void DecrementHealth(float amount)
    {
        _health -= amount;

        if (_health < 0f)
        {
            _health = 0f;
        }
    }

    public void IncrementMaxHealth(float amount)
    {
        maxHealth += amount;
        _health = maxHealth;
    }

    public void DecrementMaxHealth(float amount)
    {
        maxHealth -= amount;

        if (maxHealth < 1f)
        {
            maxHealth = 1f;
        }

        _health = maxHealth;
    }
}

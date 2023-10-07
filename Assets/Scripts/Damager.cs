using UnityEngine;

public class Damager : MonoBehaviour
{
    public float damage = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            health.DecrementHealth(damage);
        }
    }
}

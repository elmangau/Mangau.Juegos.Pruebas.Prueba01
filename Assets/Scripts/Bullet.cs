using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 min = new(-12f, -7f);
    public Vector2 max = new(+12f, +7f);
    public bool destroyOnHit = true; 

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var temp = transform.position;
        temp.x += speed * Time.deltaTime;

        if (temp.x < min.x || temp.x > max.x || temp.y < min.y || temp.y > max.y)
        {
            Destroy(gameObject);
        }

        transform.position = temp;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destroyOnHit)
        {
            Destroy(gameObject);
        }


    }
}

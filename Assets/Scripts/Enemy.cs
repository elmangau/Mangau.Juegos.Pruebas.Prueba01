using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 min = new(-12f, -7f);
    public Vector2 max = new(+15f, +7f);
    private Shooter _shooter;

    [SerializeField]
    private GameObject gunPoint;

    void Update()
    {
        GetShooter();

        Move();
    }

    private void GetShooter()
    {
        if (_shooter == null && gunPoint != null)
        {
            _shooter = gunPoint.GetComponent<Shooter>();
            _shooter.canShoot = true;
        }
    }

    private void Move()
    {
        var temp = transform.position;
        temp.x -= speed * Time.deltaTime;

        if (temp.x < min.x || temp.x > max.x || temp.y < min.y || temp.y > max.y)
        {
            Destroy(gameObject);
        }

        transform.position = temp;
    }
}

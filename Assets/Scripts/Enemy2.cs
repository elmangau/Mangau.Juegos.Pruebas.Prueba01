using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private Shooter _shooter;
    private float _y = 0f;
    private float _r = 0f;

    public float speed = 5f;
    public Vector2 min = new(-12f, -7f);
    public Vector2 max = new(+15f, +7f);

    [SerializeField]
    private GameObject gunPoint;

    void Awake()
    {
        _shooter = gunPoint.GetComponent<Shooter>();
        _shooter.canShoot = true;

        _y = transform.position.y;
    }

    void Update()
    {
        var ta = speed * Time.deltaTime;
        var temp = transform.position;

        _r += ta;

        temp.x -= ta;
        temp.y = _y + Mathf.Sin(_r);

        if (temp.x < min.x || temp.x > max.x || _y < min.y || _y > max.y)
        {
            Destroy(gameObject);
        }

        transform.position = temp;
    }
}

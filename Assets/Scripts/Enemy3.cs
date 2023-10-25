using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    private Shooter _shooter;
    private float _y = 0f;
    private float _x = 0f;
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
        _x = transform.position.x;
    }

    void Update()
    {
        var ta = speed * Time.deltaTime;
        _x -= ta;
        _r += ta;

        var temp = transform.position;
        temp.x = _x  + Mathf.Cos(_r);
        temp.y = _y + Mathf.Sin(_r);

        if (_x < min.x || _x > max.x || _y < min.y || _y > max.y)
        {
            Destroy(gameObject);
        }

        transform.position = temp;
    }
}

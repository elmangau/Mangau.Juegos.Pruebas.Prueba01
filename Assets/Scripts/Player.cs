using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public Vector2 min = new(-9f, -4f);
    public Vector2 max = new(+9f, +4f);

    private Animator _animator;
    private Shooter _shooter;

    [SerializeField]
    private GameObject gunPoint;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        GetShooter();

        Move();

        Shoot();
    }

    private void GetShooter()
    {
        if (_shooter == null && gunPoint != null)
        {
            _shooter = gunPoint.GetComponent<Shooter>();
        }
    }

    void Move()
    {
        var yAxis = Mathf.Clamp(Input.GetAxisRaw("Vertical"), -1f, +1f);
        var xAxis = Mathf.Clamp(Input.GetAxisRaw("Horizontal"), -1f, +1f);
        var direction = new Vector3(xAxis, yAxis, 0f);

        direction.Normalize();

        var pos = transform.position + (direction * speed * Time.deltaTime);

        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        transform.position = pos;

        var dir = yAxis > 0f ? 1 : (yAxis < 0f ? -1 : 0);
        _animator.SetInteger("direction", dir);
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _shooter.canShoot = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _shooter.canShoot = false;
        }
    }
}

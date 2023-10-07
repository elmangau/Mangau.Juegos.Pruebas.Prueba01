using UnityEngine;

public class Cloud : MonoBehaviour
{
    private static readonly Color Color1 = Color.gray;
    private static readonly Color Color2 = Color.white;

    private SpriteRenderer _sr;
    private float _speed = -1f;
    public float minSize = 0.33f;
    public float maxSize = 3f;

    public Vector2 min = new(-12f, -7f);
    public Vector2 max = new(+14f, +7f);

    private void Awake()
    {
        if (TryGetComponent<SpriteRenderer>(out _sr))
        {
            var color = Color.Lerp(Color1, Color2, Random.Range(0f, 1f));
            color.a = Random.Range(0.3f, 0.8f);

            _sr.flipX = Random.Range(0f, 100f) < 50f;
            _sr.flipY = Random.Range(0f, 100f) < 50f;
            _sr.color = color;
        }

        _speed = Random.Range(minSize, maxSize) * -1f;
        var size = Random.Range(minSize, maxSize);
        transform.localScale = new Vector2(size, size);
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        var temp = transform.position;
        temp.x += _speed * Time.deltaTime;

        if (temp.x < min.x || temp.x > max.x || temp.y < min.y || temp.y > max.y)
        {
            Destroy(gameObject);
        }

        transform.position = temp;
    }
}

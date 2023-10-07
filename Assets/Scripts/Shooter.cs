using UnityEngine;

public class Shooter : MonoBehaviour
{
    private AudioSource _audioSource;

    [SerializeField]
    private GameObject bullet;

    private bool _canShoot = false;
    private float _shootTimer;
    public float shootTimer = 0.33f;
    
    public bool canShoot
    {
        get => _canShoot;
        set
        {
            _canShoot = value;
            _shootTimer = 0f;
        }
    }

    private void Awake()
    {
        
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_canShoot)
        {
            _shootTimer -= Time.deltaTime;

            if (_shootTimer < 0f)
            {
                _shootTimer = shootTimer;
                Instantiate(bullet, transform.position, Quaternion.identity);
                _audioSource.Play();
            }
        }
    }
}

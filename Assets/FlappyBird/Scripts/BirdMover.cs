using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    //В скрипт с ракетой
    [SerializeField] private GameObject _rocket;
    [SerializeField] private float _speedRocket;
    private Transform _rocketTransform;

    private void Start()
    {
        _startPosition = transform.position;
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.linearVelocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);

        //В скрипт с ракетой
        if (Input.GetMouseButtonDown(0))
        {
            _rocketTransform = Instantiate(_rocket, transform.position, transform.rotation).transform;
            Debug.Log("Нажата кнопка ЛКМ");
        }

        if (_rocketTransform != null)
        {
            _rocketTransform.position += _rocketTransform.right * Time.deltaTime * _speedRocket;
        }

    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.identity;
        _rigidbody2D.linearVelocity = Vector2.zero;
    }
}

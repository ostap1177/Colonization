using UnityEngine;

public class Soldier : MonoBehaviour
{
    private float _speed;
    private bool _isDirected = false;
    private bool _isDirectionNewBase = false;
    private Ore _ore;
    private Transform _targetTransform;
    private Transform _baseTransform;
    private Transform _transform;

    public bool IsDirected => _isDirected;
    public bool IsDirectionNewBase => _isDirectionNewBase;

    private void Awake()
    {
        _transform = transform;
        _baseTransform = transform;
    }

    private void Update()
    {
        Move();
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetDirection(Transform targetTransform, Transform baseTransform)
    {
        if (targetTransform != null && baseTransform != null && targetTransform != baseTransform)
        {
            _isDirected = true;
            _targetTransform = targetTransform;
            _baseTransform = baseTransform;

            if (targetTransform.TryGetComponent(out Flag flag) == true)
            {
                _isDirectionNewBase = true;
            }
        }
    }

    private void Move()
    {
        if (_targetTransform != null)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _targetTransform.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (_ore == null && collider.TryGetComponent(out Ore ore) == true && ore.IsDelivered==false)
        {   
            ore.IsTaken();
            ore.gameObject.transform.parent = _transform;
            _ore = ore;
            _targetTransform = _baseTransform;
        }

        if (collider.TryGetComponent(out OreCounter oreCounter) == true && _ore !=null)
        {
            _isDirected = false;
            _ore.DestroyOre();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : MonoBehaviour
{
    private float _speed;
    private bool _isDirected = false;
    private Ore _ore;
    private Transform _targetTransform;
    private Transform _baseTransform;
    private Transform _transform;

    public bool IsDirected => _isDirected;

    private void Start()
    {
        _transform = transform;
        _baseTransform = transform;
    }

    private void Update()
    {
        Move(_targetTransform);
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
        }
    }

    private void Move(Transform targetTransform)
    {
        if (_targetTransform != null)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _targetTransform.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Ore>(out Ore ore) == true && ore.IsDelivered==false)
        {   
            ore.IsTaken();
            ore.gameObject.transform.parent = _transform;
            _ore = ore;
            _targetTransform = _baseTransform;
        }

        if (other.TryGetComponent<Base>(out Base Base) == true && _ore !=null)
        {
            _isDirected = false;
            _ore.DestroyOre();
        }
    }
}

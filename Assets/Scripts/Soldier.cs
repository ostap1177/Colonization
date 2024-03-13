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
        }
    }

    private void Move()
    {
        if (_targetTransform != null)
        {
            _transform.position = Vector3.MoveTowards(_transform.position, _targetTransform.position, _speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
<<<<<<< HEAD
        if (other.TryGetComponent<Ore>(out Ore ore) == true && ore.IsDelivered==false)
=======
        if (other.TryGetComponent(out Ore ore) == true && ore.IsDelivered==false)
>>>>>>> parent of 1a32865 (Colonization)
=======
        if (other.TryGetComponent(out Ore ore) == true && ore.IsDelivered==false)
>>>>>>> parent of 1a32865 (Colonization)
        {   
            ore.IsTaken();
            ore.gameObject.transform.parent = _transform;
            _ore = ore;
            _targetTransform = _baseTransform;
        }

<<<<<<< HEAD
<<<<<<< HEAD
        if (other.TryGetComponent<Base>(out Base Base) == true && _ore !=null)
=======
        if (other.TryGetComponent(out Base Base) == true && _ore !=null)
>>>>>>> parent of 1a32865 (Colonization)
=======
        if (other.TryGetComponent(out Base Base) == true && _ore !=null)
>>>>>>> parent of 1a32865 (Colonization)
        {
            _isDirected = false;
            _ore.DestroyOre();
        }
    }
}

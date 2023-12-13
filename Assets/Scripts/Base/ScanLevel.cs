using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class ScanLevel : MonoBehaviour
{
    [SerializeField] private Vector3 _maximumScanSize;

    private BoxCollider _collider;
    private Vector3 _startScaleScan;
    private bool _isScaning = false;
    private WaitForSeconds _waitForSeconds;
    private float _seconds = 1;
    private float _stepScan = 2;
    private Coroutine _coroutine;

    public event UnityAction<Transform> OreFounded;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();
        _collider.isTrigger = true;
        _startScaleScan = _collider.transform.localScale;
        _waitForSeconds = new WaitForSeconds(_seconds);
    }

    private void FixedUpdate()
    {
        if (_isScaning != true)
        {
            Scaning();
        }
    }

    private void OnTriggerEnter(Collider trigger)
    {
        if (trigger.TryGetComponent(out Ore ore))
        {
            OreFounded?.Invoke(ore.transform);
        }
    }

    private void Scaning()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Scaned());
    }

    private IEnumerator Scaned()
    {
        _isScaning = true;

        while (_collider.size.x < _maximumScanSize.x)
        {
            _collider.size = new Vector3( _collider.size.x*_stepScan,_collider.size.y, _collider.size.z * _stepScan) ;
            yield return _waitForSeconds;
            Debug.Log(_collider.size);
        }

        _collider.size = _startScaleScan;
        _isScaning = false;
    }
}

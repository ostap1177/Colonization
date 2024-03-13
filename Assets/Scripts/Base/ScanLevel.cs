using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        
=======
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
>>>>>>> parent of 1a32865 (Colonization)
    }
}

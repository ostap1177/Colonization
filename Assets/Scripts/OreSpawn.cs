using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OreSpawn : MonoBehaviour
{
    [SerializeField] private Collider _spawnTerritory;
    [SerializeField] private Ore _ore;
    [SerializeField] private int _oreLimit;
    [SerializeField] private int _delaySpawn;
    private Transform _transform;
    private int _childCountOnStart;
    private Vector3 _spawnBound;
    private float _transformOreY;
    private bool _isSpawnDelay;

    private Coroutine _spawnCoroutine;
    private WaitForSeconds _waitForSeconds;

    public event UnityAction<Transform> OreSpawned;

    private void Start()
    {
        _transform = transform;
        _childCountOnStart = _transform.childCount;

        _waitForSeconds = new WaitForSeconds(_delaySpawn);

        _spawnBound = _spawnTerritory.bounds.extents;
        _transformOreY = -0.5f;
    }

    private void FixedUpdate()
    {
        if (_transform.childCount < _oreLimit+_childCountOnStart && _isSpawnDelay == false)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        if (_spawnCoroutine != null)
        {
           StopCoroutine(_spawnCoroutine);
        }

        _spawnCoroutine = StartCoroutine(DelaySpawnOre());
    }

    private IEnumerator DelaySpawnOre()
    {
        _isSpawnDelay = true;

        yield return _waitForSeconds;

        SpawnOre(GetSpawtPosition());
        _isSpawnDelay = false;
    }

    private void SpawnOre(Vector3 spawtPosition)
    {
        Ore ore = Instantiate(_ore, spawtPosition, Quaternion.identity);
        ore.transform.parent = _transform;

        OreSpawned?.Invoke(ore.gameObject.transform);
    }

    private Vector3 GetSpawtPosition()
    {
        float vectorX = Random.Range(_spawnBound.x, -_spawnBound.x);
        float vectorZ = Random.Range(_spawnBound.z, -_spawnBound.z);

        Vector3 spawtPosition = new Vector3(vectorX, _transformOreY, vectorZ);

        return spawtPosition;
    }
}
